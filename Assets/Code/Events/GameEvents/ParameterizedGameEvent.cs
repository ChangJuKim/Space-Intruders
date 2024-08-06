using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Parameterized Game Event", menuName = "ScriptableObjects/ParameterizedGameEvent")]
public class ParameterizedGameEvent : GameEvent
{

    private List<ParameterizedGameEventListener> parameterizedListeners = new List<ParameterizedGameEventListener>();

    public void Raise(EventParametersBase parameters)
    {
        if (!OncePerFrame || lastFrameRaised != Time.frameCount)
        {
            for (int i = parameterizedListeners.Count - 1; i >= 0; i--)
            {
                parameterizedListeners[i].OnEventRaised(parameters);
            }

            lastFrameRaised = Time.frameCount;
        }
    }

    public void RegisterListener(ParameterizedGameEventListener listener)
    {
        parameterizedListeners.Add(listener);
    }

    public void UnregisterListener(ParameterizedGameEventListener listener)
    {
        parameterizedListeners.Remove(listener);
    }
}
