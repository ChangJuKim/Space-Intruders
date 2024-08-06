using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Alien : MonoBehaviour
{
    [SerializeField] private AlienStats alienData;
    private float moveCooldown;
    [SerializeField] private GameEvent gameOverEvent;
    [SerializeField] private GameEvent alienDeathEvent;

    public void Start()
    {
        ResetMoveCooldown();
    }

    public void FixedUpdate()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0)
        {
            Jump();
            ResetMoveCooldown();
        }

        if (transform.position.y <= alienData.finishLine)
        {
            gameOverEvent.Raise();
        }
    }

    private void ResetMoveCooldown()
    {
        moveCooldown = alienData.MoveCooldown;
    }

    private void Jump()
    {
        transform.position += Vector3.down * alienData.MoveDistance;
    }

    private void OnDestroy()
    {
        alienDeathEvent.Raise();
    }
}