using strange.extensions.command.impl;

namespace Demonstration.Echo
{
  public class DisconnectCommand : Command
  {
    [Inject]
    public IWebSocketService WebSocketService { get; set; }

    public override void Execute ()
    {
      WebSocketService.Disconnect ();
    }
  }
}
