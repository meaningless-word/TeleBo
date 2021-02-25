namespace TelegramBot
{
	public interface IChatCommand
	{
		bool CheckMessage(string message);
	}
}
