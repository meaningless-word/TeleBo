namespace TelegramBot
{
	public class SayHiCommand: AbstractCommand, IChatTextCommand
	{
		public SayHiCommand()
		{
			CommandText = "/saymehi";
		}

		public string ReturnText()
		{
			return "привет!";
		}
	}
}
