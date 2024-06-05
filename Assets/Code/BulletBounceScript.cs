using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounceScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = Vector2.up * speed;
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        rigidBody.velocity = Vector2.up * speed;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
