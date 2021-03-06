namespace TradingCompany.Business
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TradingCompany.Integration;
	using TradingCompany.Models;
	using TradingCompany.Repository;
	using TradingCompany.Shared;

	public class BankAccountBDC : IBankAccountBDC
	{
		private readonly IBankAccountRepository bankAccountRepository;
		private readonly IAccountRepository accountRepository;
		private readonly IPaymentGateway paymentGateway;
		private readonly IRequestValidator requestValidator;
		private readonly INotificationServiceProvider notificationServiceProvider;
		private readonly ITradingHistoryServiceProvider tradingHistoryServiceProvider;

		public BankAccountBDC(IBankAccountRepository bankAccountRepository
			, IPaymentGateway paymentGateway
			, IRequestValidator requestValidator
			, INotificationServiceProvider notificationServiceProvider
			, ITradingHistoryServiceProvider tradingHistoryServiceProvider
			, IAccountRepository accountRepository)
		{
			this.bankAccountRepository = bankAccountRepository;
			this.accountRepository = accountRepository;
			this.paymentGateway = paymentGateway;
			this.requestValidator = requestValidator;
			this.notificationServiceProvider = notificationServiceProvider;
			this.tradingHistoryServiceProvider = tradingHistoryServiceProvider;
		}

		public void LinkBankAccount(BankAccount bankAccount)
		{
			IList<BankAccount> bankAccounts = bankAccountRepository.GetAllBankAccounts(); //This could be a better individual validations for existing bank account.

			if (bankAccounts.Any(x => x.BankAccountId == bankAccount.BankAccountId))
			{
				throw new CustomException("Duplicate account found");
			}

			if (paymentGateway.ValidateBandAccountDetails(bankAccount.AccountNumber
				, bankAccount.RoutingNumber
				, bankAccount.CustomerName)) // This mock is responsible for bank account validation for customer.
			{
				bankAccountRepository.LinkMyBankAccount(bankAccount);
				notificationServiceProvider.SendNotification("transaction successful."); // Send message in the queue for notification
			}
			else
			{
				throw new CustomException("Invalid account information provided");
			}
		}

		public bool RunTransaction(BankAccountRequest request)
		{
			bool result = false;

			BankAccount bankAccount = bankAccountRepository.GetBankAccount(request.BankAccountId);

			try
			{
				if (request.TransactionType == TransactionType.Credit)
				{
					if (requestValidator.ValidateCreditRequest(bankAccount, request))
					{
						bankAccountRepository.AddMoney(request);
						accountRepository.UpdateBalance(request.AccountId, request.Amount);
						notificationServiceProvider.SendNotification("credit transaction successful."); // Send message in the queue for notification
						this.tradingHistoryServiceProvider.AddBankTransactionEvent(request); // Send message in the quest for transaction history
						result = true;
					}
				}
				else
				{
					if (requestValidator.ValidateDebitRequest(bankAccount, request))
					{
						bankAccountRepository.WithdrawMoeny(request);
						accountRepository.UpdateBalance(request.AccountId, (-1 * request.Amount));
						notificationServiceProvider.SendNotification("debit transaction successful."); // Send message in the queue for notification
						this.tradingHistoryServiceProvider.AddBankTransactionEvent(request); // Send message in the queue for transaction history
						result = true;
					}
				}
			}
			catch (System.Exception ex)
			{
				notificationServiceProvider.SendNotification("transaction failed."); // Send message in the queue for failed transaction notification
				throw new CustomException("Error in process transaction.", string.Empty, ex);
			}

			return result;
		}

		public IList<BankAccount> GetBankAccounts()
		{
			return bankAccountRepository.GetAllBankAccounts();
		}
	}
}
