using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
	public class Messenger
	{
		private ITelegramBotClient botClient;
		private CommandParser parser;

		public Messenger(ITelegramBotClient botClient)
		{
			this.botClient = botClient;
			parser = new CommandParser();

			RegisterCommands();
		}

		private void RegisterCommands()
		{
			parser.AddCommand(new SayHiCommand());
			parser.AddCommand(new PoemButtonCommand(botClient));
		}

		public async Task MakeAnswer(Conversation chat)
		{
			var lastMessage = chat.GetLastMessage();

			if (parser.IsMessageCommand(lastMessage))
			{
				await ExecCommand(chat, lastMessage);
			}
			else
			{
				var text = CreateTextMessage();
				await SendText(chat, text);
			}
		}

		private async Task ExecCommand(Conversation chat, string command)
		{
			if (parser.IsTextCommand(command))
			{
				var text = parser.GetMessageText(command);

				await SendText(chat, text);
			}

			if (parser.IsButtonCommand(command))
			{
				var keys = parser.GetKeyboard(command);
				var text = parser.GetInformationalMessage(command);
				parser.AddCallback(command, chat.GetId());

				await SendTextWithKeyBoard(chat, text, keys);
			}
		}

		private string CreateTextMessage()
		{
			var text = "Not a command";

			return text;
		}

		private async Task SendText(Conversation chat, string text)
		{
			await botClient.SendTextMessageAsync(
				chatId: chat.GetId(),
				text: text
				);
		}

		private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
		{
			await botClient.SendTextMessageAsync(
				chatId: chat.GetId(),
				text: text,
				replyMarkup: keyboard
				);
		}
	}
}