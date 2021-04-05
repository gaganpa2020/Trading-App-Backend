namespace TradingCompany.Models
{
	using System;
	using System.Collections.Generic;

	public class UserAccountEntity
	{
		public int AccountId { get; set; }
		public string Email { get; set; }
		public string SSN { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Phone { get; set; }
		public double Balance { get; set; }
		public IDictionary<string, int> stocks { get; set; }
	}
}
