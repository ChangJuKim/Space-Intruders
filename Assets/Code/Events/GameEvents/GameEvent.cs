using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "ScriptableObjects/Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    [SerializeField] private bool oncePerFrame;
    protected int lastFrameRaised = -1;
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public bool OncePerFrame { get => oncePerFrame; set => oncePerFrame = value; }

    public void Raise()
    {
        if (!OncePerFrame || lastFrameRaised != Time.frameCount)
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
