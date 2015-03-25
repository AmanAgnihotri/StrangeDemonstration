using strange.extensions.mediation.impl;

namespace Demonstration.Echo
{
  public class EchoMediator : Mediator
  {
    [Inject]
    public EchoView EchoView { get; set; }

    [Inject]
    public ConnectSignal ConnectSignal { get; set; }

    [Inject]
    public DisconnectSignal DisconnectSignal { get; set; }

    [Inject]
    public SendMessageSignal SendMessageSignal { get; set; }

    [Inject]
    public LogSignal LogSignal { get; set; }

    [Inject]
    public IWebSocketService WebSocketService { get; set; }

    public override void OnRegister ()
    {
      EchoView.Initialize ();

      SetCanConnect (true);

      EchoView.InputSignal.AddListener (ProcessInput);

      LogSignal.AddListener (Log);
    }

    public override void OnRemove ()
    {
      EchoView.InputSignal.RemoveListener (ProcessInput);

      LogSignal.RemoveListener (Log);
    }

    private void ProcessInput (InputType type)
    {
      switch (type)
      {
        case InputType.Connect:
          LogMessage ("Trying to connect...");
          ConnectSignal.Dispatch ();
          break;
        case InputType.Disconnect:
          LogMessage ("Trying to disconnect...");
          DisconnectSignal.Dispatch ();
          break;
        case InputType.SendMessage:
          TrySendMessage ();
          break;
        case InputType.ClearLog:
          ClearLog ();
          break;
      }
    }

    private void Log (LogType logType, string message)
    {
      switch (logType)
      {
        case LogType.Connected:
          SetCanConnect (false);
          break;
        case LogType.Disconnected:
          SetCanConnect (true);
          break;
      }

      LogMessage (message);
    }

    private void TrySendMessage ()
    {
      var message = EchoView.Mesasge.text;

      if (!string.IsNullOrEmpty (message))
      {
        SendMessageSignal.Dispatch (message);
      }
    }

    private void LogMessage (string message)
    {
      EchoView.Log.text += message + "\n";
    }

    private void ClearLog ()
    {
      EchoView.Log.text = string.Empty;
    }

    private void SetCanConnect (bool value)
    {
      EchoView.ConnectButton.interactable = value;
      EchoView.SendMessageButton.interactable = !value;
      EchoView.DisconnectButton.interactable = !value;
    }
  }
}
