namespace TradingCompany.Models
{
	public class BankAccountRequest
	{
		public int AccountId { get; set; }
		public int BankAccountId { get; set; }
		public TransactionType TransactionType { get; set; }
		public int Amount { get; set; }
	}
}
