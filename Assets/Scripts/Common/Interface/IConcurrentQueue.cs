namespace Demonstration.Common
{
  public interface IConcurrentQueue<T>
  {
    int Count { get; }

    void Enqueue (T item);

    T Dequeue () ;

    T Peek ();

    void Clear ();
  }
}
