using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public FloatVariable moveCooldownBase;
    public FloatVariable jumpDistance;
    public FloatVariable finishLine;
    private float moveCooldown;
    public GameEvent alienDestroyEvent;

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
            alienDestroyEvent.Raise();
            Destroy(gameObject);
        }
    }

    private void resetCooldown()
    {
        moveCooldown = moveCooldownBase.value;
    }

    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy()
    {
        alienDestroyEvent.Raise();
    }




}
