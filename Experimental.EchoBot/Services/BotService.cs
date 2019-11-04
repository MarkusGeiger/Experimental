using Experimental.EchoBot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Experimental.EchoBot.Services
{
  public class BotService
  {
    static ITelegramBotClient _botClient;
    static List<int> _broadcastList;

    public BotService(IBotSettings botSettings)
    {
      _broadcastList = new List<int>(botSettings.BroadcastList);

      _botClient = new TelegramBotClient(botSettings.Token);

      var me = _botClient.GetMeAsync().Result;
      Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

      _botClient.OnMessage += OnMessage;
      _botClient.StartReceiving();
    }

    public async Task BroadcastMessage(string message, bool disableNotification = true)
    {
      if (!string.IsNullOrWhiteSpace(message))
      {
        foreach (var user in _broadcastList)
        {
          try
          {
            await _botClient.SendTextMessageAsync(
              chatId: user,
              disableNotification: disableNotification,
              parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
              text: "BROADCAST:\n" + message);
          }
          catch (Exception exc)
          {
            Console.WriteLine($"ERROR broadcasting message '{message}' to user '{user}'. Details: \n\n{exc}");
          }
        }
      }
    }

    public async void BroadcastException(Exception exception)
    {
      await BroadcastMessage(
        $"*{DateTime.Now}*\n" +
        $"*{exception.Source}*: Unhandled {exception.GetType()} exception: " +
        $"'{exception.Message} @ `{exception.TargetSite}`'\n" +
        $"Stacktrace:\n\t`{exception.StackTrace}`",
        disableNotification: false
        );
    }

    private async void OnMessage(object sender, MessageEventArgs e)
    {
      if(e.Message.Text != null)
      {
        Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id} from {e.Message.From}.");
        Console.WriteLine($"{e.Message}");

        var message = "Message Info:\n" +
            e.Message.Text + Environment.NewLine +
            e.Message.From + Environment.NewLine +
            (e.Message.Chat.Description ?? "null") + Environment.NewLine +
            (e.Message.Chat.Title ?? "null") + Environment.NewLine +
            (e.Message.Chat.Username ?? "null") + Environment.NewLine +
            (e.Message.Chat.Type.ToString() ?? "null") + Environment.NewLine +
            (e.Message.Chat.Id.ToString() ?? "null") + Environment.NewLine;

        await BroadcastMessage(message);

        await _botClient.SendTextMessageAsync(
          chatId: e.Message.Chat,
          disableNotification: true,
          replyToMessageId: e.Message.MessageId,
          text: message);
      }
    }
  }
}
