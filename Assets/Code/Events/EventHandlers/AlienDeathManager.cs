using UnityEngine;

public class AlienManagerScript : MonoBehaviour
{
    [SerializeField] private GameEvent playerVictoryEvent;

    public void CheckAllDead()
    {
        // Last alien is scheduled to, but not yet destroyed
        if (transform.childCount == 1)
        {
            playerVictoryEvent.Raise();
        }
    }
}
