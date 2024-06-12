using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        Debug.Log("Raised. " + listeners.Count + " listeners waiting");
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        Debug.Log("Registering from gameEvent side");
        listeners.Add(listener);
        Debug.Log(listeners.Count + " listeners registered");
    }

    public void UnregisterListener(GameEventListener listener) 
    {
        listeners.Remove(listener);
    }
}
