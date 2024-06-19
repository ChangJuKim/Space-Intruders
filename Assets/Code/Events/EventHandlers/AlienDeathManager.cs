using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienManagerScript : MonoBehaviour
{
    public GameEvent playerVictoryEvent;

    public void CheckAllDead()
    {
        // Last alien is scheduled to, but not yet destroyed
        if (transform.childCount == 1)
        {
            playerVictoryEvent.Raise();
        }
    }
}
