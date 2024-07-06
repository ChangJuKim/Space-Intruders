using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.up;
        rigidBody.velocity = direction * speed;
    }

    private void FixedUpdate()
    {

    }

    // TODO: Remove hard coded values and find a better way of checking collision
    // TODO: Make bullets die off screen instead of on screen
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
