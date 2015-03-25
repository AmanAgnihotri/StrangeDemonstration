using System.Collections.Generic;

namespace Demonstration.Common
{
  internal class ConcurrentQueue<T> : IConcurrentQueue<T>
  {
    private readonly object syncLock = new object ();

    private Queue<T> Queue { get; set; }

    public int Count
    {
      get
      {
        lock (syncLock)
        {
          return Queue.Count;
        }
      }
    }

    public ConcurrentQueue ()
    {
      Queue = new Queue<T> ();
    }

    public void Enqueue (T obj)
    {
      lock (syncLock)
      {
        Queue.Enqueue (obj);
      }
    }

    public T Dequeue ()
    {
      lock (syncLock)
      {
        return Queue.Dequeue ();
      }
    }

    public T Peek ()
    {
      lock (syncLock)
      {
        return Queue.Peek ();
      }
    }

    public void Clear ()
    {
      lock (syncLock)
      {
        Queue.Clear ();
      }
    }
  }
}
