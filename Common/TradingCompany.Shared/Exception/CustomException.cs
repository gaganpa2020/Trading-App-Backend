namespace TradingCompany.Shared
{
	using System;

	public class CustomException : Exception
	{
		public CustomException(string Message)
		{
			this.Message = Message;
		}

		public CustomException(string Message, string ErrorCode)
		{
			this.Message = Message;
			this.ErrorCode = ErrorCode;
		}

		public CustomException(string Message, string ErrorCode, Exception OriginalException)
		{
			this.Message = Message;
			this.ErrorCode = ErrorCode;
			this.OriginalException = OriginalException;
		}

		public string Message { get; set; }
		public string ErrorCode { get; set; }
		public Exception OriginalException { get; set; }
	}
}
