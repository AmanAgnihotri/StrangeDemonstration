using strange.extensions.context.impl;

namespace Demonstration.Rest
{
  public class RestBootstrap : ContextView
  {
    private void Awake ()
    {
      context = new RestContext (this);
    }
  }
}
