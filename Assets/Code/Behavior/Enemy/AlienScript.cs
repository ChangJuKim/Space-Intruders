using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public FloatVariable moveCooldownBase;
    public FloatVariable jumpDistance;
    public FloatVariable finishLine;
    public GameEvent gameOverEvent;
    public GameEvent alienDeathEvent;
    private float moveCooldown;

    // Start is called before the first frame update
    void Start()
    {
        resetCooldown();
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        moveCooldown -= Time.deltaTime;
        if (moveCooldown <= 0)
        {
            transform.position = transform.position + Vector3.down * jumpDistance.value;
            resetCooldown();
        }

        if (transform.position.y <= finishLine.value)
        {
            gameOverEvent.Raise();
        }
    }

    private void resetCooldown()
    {
        moveCooldown = moveCooldownBase.value;
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        alienDeathEvent.Raise();
    }




}
