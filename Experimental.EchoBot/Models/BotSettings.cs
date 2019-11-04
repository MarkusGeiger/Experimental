namespace Experimental.EchoBot.Models
{
  public class BotSettings : IBotSettings
  {
    public string Token { get; set; }
    public int[] BroadcastList { get; set; }
  }

  public interface IBotSettings
  {
    string Token { get; set; }
    int[] BroadcastList { get; set; }
  }
}
