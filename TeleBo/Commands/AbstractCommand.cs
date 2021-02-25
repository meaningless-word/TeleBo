namespace TelegramBot
{
	public class AbstractCommand : IChatCommand
	{
		public string CommandText;

		public bool CheckMessage(string message)
		{
			return CommandText == message;
		}
	}
}
