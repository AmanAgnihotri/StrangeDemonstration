using UnityEngine;
using System.Collections;

namespace Demonstration.Common
{
  public interface IRoutineRunner
  {
    Coroutine StartCoroutine (IEnumerator method);
  }
}
