using WebSocketSharp;
using System.Collections;
using Demonstration.Common;
using strange.extensions.signal.impl;

namespace Demonstration.Echo
{
  public class EchoService : IWebSocketService
  {
    public const string ECHO_URL = "ws://echo.websocket.org/";

    [Inject]
    public LogSignal LogSignal { get; set; }

    [Inject]
    public IRoutineRunner RoutineRunner { get; set; }

    private WebSocket EchoSocket { get; set; }

    private bool IsRunning { get; set; }

    private IConcurrentQueue<string> LogQueue { get; set; }

    [PostConstruct]
    public void PostConstruct ()
    {
      EchoSocket = new WebSocket (ECHO_URL);

      LogQueue = new ConcurrentQueue<string> ();

      EchoSocket.OnOpen += (sender, e) => LogQueue.Enqueue ("0Connected to: " + ECHO_URL);

      EchoSocket.OnMessage += (sender, e) => LogQueue.Enqueue ("1Received: " + e.Data);

      EchoSocket.OnError += (sender, e) => LogQueue.Enqueue ("1Error Occurred");

      EchoSocket.OnClose += (sender, e) => LogQueue.Enqueue ("2Disconnected With Code: " + e.Code);
    }

    public void Connect ()
    {
      EchoSocket.ConnectAsync ();

      if (!IsRunning)
      {
        IsRunning = true;
        RoutineRunner.StartCoroutine (LogRoutine ());
      }
    }

    public void Disconnect ()
    {
      EchoSocket.CloseAsync (CloseStatusCode.Normal);
    }

    public void SendMessage (string message)
    {
      EchoSocket.SendAsync (message, success =>
      {
        if (success)
        {
          LogQueue.Enqueue ("1Sent: " + message);
        }
        else
        {
          LogQueue.Enqueue ("1Failed to Send: " + message);
        }
      });
    }

    private IEnumerator LogRoutine ()
    {
      while (IsRunning)
      {
        if (LogQueue.Count > 0)
        {
          var data = LogQueue.Dequeue ();

          char logType = data [0];
          var message = data.Substring (1);

          switch (logType)
          {
            case '0':
              LogSignal.Dispatch (LogType.Connected, message);
              break;
            case '1':
              LogSignal.Dispatch (LogType.Message, message);
              break;
            case '2':
              LogSignal.Dispatch (LogType.Disconnected, message);
              IsRunning = false;
              break;
          }
        }

        yield return null;
      }
    }
  }
}
