using UnityEngine.UI;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Demonstration.Echo
{
  public class EchoView : View
  {
    public Text Log;
    public InputField Mesasge;

    public Button ConnectButton;
    public Button DisconnectButton;
    public Button SendMessageButton;

    internal Signal<InputType> InputSignal;

    public void Initialize ()
    {
      InputSignal = new Signal<InputType> ();
    }

    public void Connect ()
    {
      InputSignal.Dispatch (InputType.Connect);
    }

    public void Disconnect ()
    {
      InputSignal.Dispatch (InputType.Disconnect);
    }

    public void SendMessage ()
    {
      InputSignal.Dispatch (InputType.SendMessage);
    }

    public void ClearLog ()
    {
      InputSignal.Dispatch (InputType.ClearLog);
    }
  }
}
