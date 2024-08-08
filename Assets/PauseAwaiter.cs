using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I wanted this done quickly so I didn't bother with a good name
public class PauseAwaiter : MonoBehaviour
{
    [SerializeField] private GameEvent pauseGameEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGameEvent.Raise();
        }
    }
}
