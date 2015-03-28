using strange.extensions.signal.impl;

namespace Demonstration.Persist
{
  public class DeleteSignal<T> : Signal
  {
  }

  public class LoadSignal<T> : Signal
  {
  }

  public class SaveSignal<T> : Signal<T>
  {
  }

  public class LoadedSignal<T> : Signal<T>
  {
  }
}
