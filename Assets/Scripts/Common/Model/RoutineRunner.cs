using UnityEngine;
using System.Collections;
using strange.extensions.context.api;
using strange.extensions.injector.api;

namespace Demonstration.Common
{
  public class RoutineRunner : IRoutineRunner
  {
    [Inject (ContextKeys.CONTEXT_VIEW)]
    public GameObject ContextView { get; set; }

    private RoutineRunnerBehaviour runner;

    [PostConstruct]
    public void PostConstruct ()
    {
      runner = ContextView.AddComponent<RoutineRunnerBehaviour> ();
    }

    public Coroutine StartCoroutine (IEnumerator routine)
    {
      return runner.StartCoroutine (routine);
    }

    private class RoutineRunnerBehaviour : MonoBehaviour
    {
    }
  }
}
