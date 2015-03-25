using strange.extensions.signal.impl;

namespace Demonstration.Echo
{
  public interface IWebSocketService
  {
    void Connect ();

    void Disconnect ();

    void SendMessage (string message);
  }
}
