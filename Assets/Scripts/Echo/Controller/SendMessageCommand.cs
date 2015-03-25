using strange.extensions.command.impl;

namespace Demonstration.Echo
{
  public class SendMessageCommand : Command
  {
    [Inject]
    public string Mesasge { get; set; }

    [Inject]
    public IWebSocketService WebSocketService { get; set; }

    public override void Execute ()
    {
      WebSocketService.SendMessage (Mesasge);
    }
  }
}
