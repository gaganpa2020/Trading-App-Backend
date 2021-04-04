using System;
using System.Collections.Generic;
using System.Text;

namespace TradingCompany.Models
{
	public class BankAccount
	{
		public int BankAccountId { get; set; }
		public string CustomerName { get; set; }
		public string AccountNumber { get; set; }
		public string RoutingNumber { get; set; }
		public long AccountBalance { get; set; } // Initial request can have some balance while creating account.
	}
}
