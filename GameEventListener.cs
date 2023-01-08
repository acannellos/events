using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class CustomResponse : UnityEvent<Component, object> {}

[System.Serializable]
public class EventContainer {
    public GameEvent gameEvent;
    public CustomResponse response;

    public void EventRaised(Component sender, object data) {
        response.Invoke(sender, data);
    }
}

public class GameEventListener : MonoBehaviour {

    public List<EventContainer> events = new List<EventContainer>();

    private void OnEnable() {
        if (events.Count >= 1) {
            foreach (EventContainer e in events) {
                e.gameEvent.RegisterListener(this);
            }
        }
    }

    private void OnDisable() {
        if (events.Count >= 1) {
            foreach (EventContainer e in events) {
                e.gameEvent.UnregisterListener(this);
            }
        }
    }

    public void OnEventRaised(GameEvent raisedEvent, bool debug, Component sender, object data) {
        
        if (events.Count >= 1) {
            foreach (EventContainer e in events) {
                if (raisedEvent == e.gameEvent) {
                    e.EventRaised(sender, data);
                }
            }
        }
                
        if (debug) DebugEvent(raisedEvent, sender, data);
    }

    private void DebugEvent(GameEvent raisedEvent, Component sender, object data) {

        string debugSender = sender == null ? "null" : sender.gameObject.name;
        object debugData = data == null ? "null" : data;

        Debug.Log(raisedEvent + ": " + debugSender + " raised " + debugData + " on " + gameObject.name);
    }

}

