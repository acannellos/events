using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="AC/Game Event")]
public class GameEvent : ScriptableObject {

    public bool debug = false;
    public List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() {
        Raise(null, null);
    }

    public void Raise(object data) {
        Raise(null, data);
    }

    public void Raise(Component sender) {
        Raise(sender, null);
    }

    public void Raise(Component sender, object data) {
        if (listeners.Count >= 1) {
            foreach (GameEventListener l in listeners) {
                l.OnEventRaised(this, debug, sender, data);
            }
        }
    }

    public void RegisterListener(GameEventListener listener) {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
