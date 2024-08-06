using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParameterizedGameEventListener : MonoBehaviour
{
    [SerializeField] private ParameterizedGameEvent Event;
    [SerializeField] private UnityEvent<EventParametersBase> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(EventParametersBase parameters)
    {
        Response.Invoke(parameters);
    }
}
