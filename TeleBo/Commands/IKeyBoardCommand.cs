using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
	public interface IKeyBoardCommand
	{
		public InlineKeyboardMarkup ReturnKeyBoard();

		void AddCallback(long chatId);

		string InformationalMessage();
	}
}
