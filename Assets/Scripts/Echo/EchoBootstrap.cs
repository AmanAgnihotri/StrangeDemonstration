using strange.extensions.context.impl;

namespace Demonstration.Echo
{
  public class EchoBootstrap : ContextView
  {
    private void Awake ()
    {
      context = new EchoContext (this);
    }
  }
}
