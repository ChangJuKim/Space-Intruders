using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public FloatVariable moveCooldownBase;
    public FloatVariable jumpDistance;
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
    }

    private void resetCooldown()
    {
        moveCooldown = moveCooldownBase.value;
    }


}
