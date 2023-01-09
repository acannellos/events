# events

my take on the ScriptableObject GameEvent systems outlined below, mainly altered so that GameEventListener is more a container for any number of GameEvents that may impact a single GameObject

https://www.youtube.com/watch?v=7_dyDmF0Ktw
<br>
https://github.com/sticmac/unity-event-system
<br>

hold any number of GameEvents on a single GameEventListener
![events1](https://user-images.githubusercontent.com/105668314/211218359-3284bd86-23c5-4544-8471-e74db1dae266.png)
<br>

toggleable Debug bool for each GameEvent, which can log the Event Sender Data and Receiver
![events2](https://user-images.githubusercontent.com/105668314/211218360-5ff44a06-e085-41ad-aa17-3833ca8d5855.png)
![events3](https://user-images.githubusercontent.com/105668314/211218361-7c93197d-b8fe-409f-8e56-38f28bdd855f.png)
