using UnityEngine.UI;
using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace Demonstration.Persist
{
  public class PersistView : View
  {
    public InputField Name;
    public InputField Age;

    internal Signal<InputType> InputSignal;

    public void Initialize ()
    {
      InputSignal = new Signal<InputType> ();
    }

    public void Clear ()
    {
      InputSignal.Dispatch (InputType.Clear);
    }

    public void Delete ()
    {
      InputSignal.Dispatch (InputType.Delete);
    }

    public void Load ()
    {
      InputSignal.Dispatch (InputType.Load);
    }

    public void Save ()
    {
      InputSignal.Dispatch (InputType.Save);
    }
  }
}
