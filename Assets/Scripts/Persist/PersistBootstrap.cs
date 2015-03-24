using strange.extensions.context.impl;

namespace Demonstration.Persist
{
  public class PersistBootstrap : ContextView
  {
    private void Awake ()
    {
      context = new PersistContext (this);
    }
  }
}
