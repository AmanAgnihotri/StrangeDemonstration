using strange.extensions.signal.impl;

namespace Demonstration.Echo
{
  public class ConnectSignal : Signal
  {
  }

  public class DisconnectSignal : Signal
  {
  }

  public class SendMessageSignal : Signal<string>
  {
  }

  public class LogSignal : Signal<LogType, string>
  {
  }
}
