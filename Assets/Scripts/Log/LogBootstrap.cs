using strange.extensions.context.impl;

namespace Demonstration.Log
{
  public class LogBootstrap : ContextView
  {
    private void Awake ()
    {
      context = new LogContext (this);
    }
  }
}
