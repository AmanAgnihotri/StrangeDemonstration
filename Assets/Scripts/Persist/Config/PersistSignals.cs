using strange.extensions.signal.impl;

namespace Demonstration.Persist
{
  public class DeleteSignal : Signal
  {
  }

  public class LoadSignal : Signal
  {
  }

  public class SaveSignal : Signal<IPerson>
  {
  }

  public class LoadedSignal : Signal<IPerson>
  {
  }
}
