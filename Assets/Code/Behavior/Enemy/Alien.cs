using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Alien : MonoBehaviour
{
    public AlienStats alienData;
    private float moveCooldown;
    public GameEvent gameOverEvent;
    public GameEvent alienDeathEvent;

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
        moveCooldown = alienData.moveCooldown;
    }

    private void Jump()
    {
        transform.position += Vector3.down * alienData.moveDistance;
    }

    private void OnDestroy()
    {
        alienDeathEvent.Raise();
    }
}