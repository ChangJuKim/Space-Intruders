using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    public bool oncePerFrame;
    private int lastFrameRaised = -1;
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        if (!oncePerFrame || lastFrameRaised != Time.frameCount)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }

            lastFrameRaised = Time.frameCount;
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) 
    {
        listeners.Remove(listener);
    }
}
