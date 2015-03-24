using UnityEngine;
using strange.extensions.command.impl;

namespace Demonstration.Log
{
  public class LogCommand : Command
  {
    [Inject]
    public string Text { get; set; }

    public override void Execute ()
    {
      Debug.Log (Text);
    }
  }
}
