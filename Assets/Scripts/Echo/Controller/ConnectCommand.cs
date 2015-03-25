using strange.extensions.command.impl;

namespace Demonstration.Echo
{
  public class ConnectCommand : Command
  {
    [Inject]
    public IWebSocketService WebSocketService { get; set; }

    public override void Execute ()
    {
      WebSocketService.Connect ();
    }
  }
}
