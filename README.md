# StrangeDemonstration

StrangeDemonstration is a [Unity 5](http://unity3d.com/5) project that tries to demonstrate [StrangeIoC](http://strangeioc.github.io/strangeioc/) framework and usage of other libraries by writing "strange" code.

Its examples utilise the MVCS architecture along with patterns like [Observer](http://en.wikipedia.org/wiki/Observer_pattern), [Command](http://en.wikipedia.org/wiki/Command_pattern), [Mediator](http://en.wikipedia.org/wiki/Mediator_pattern), [Object Pool](http://en.wikipedia.org/wiki/Object_pool_pattern), [Dependency Injection](http://en.wikipedia.org/wiki/Dependency_injection), etc to provide a modular design to examples.

The examples that have UI based scenes use Unity's new UI system.

Each example (will) have its own wiki page that explains in detail, with code, as to how it does what it does and the whole workflow of the module.

Following are the modules that are present in the project:

* **Log**  
  The Log module is a simple yet strange Hello World example. When it starts, it logs a "Hello World" message on the debug console.

* **Persist**  
  The Persist module shows how to write strange code that persists models. It uses the Newtonsoft.Json library to serialize and deserialize an example model and uses Unity's PlayerPrefs class to persist the serialized data.

* **Echo**
  The Echo module uses the WebSocket-Sharp library to asynchronously connect with an Echo Server via websocket and allows the user to send messages to it which are eventually echoed back to it.

Checkout its [Wiki](https://github.com/AmanAgnihotri/StrangeDemonstration/wiki) pages for more information.
