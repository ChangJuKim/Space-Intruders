using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounceScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Vector2 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
        rigidBody.velocity = direction * speed;
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        rigidBody.velocity = direction * speed;
    }



    // TODO: Remove hard coded values and find a better way of checking collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Bounce(collision.contacts[0].normal);
        } else if (collision.gameObject.tag != "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void Bounce(Vector2 normal)
    {
        direction = Vector2.Reflect(direction, normal).normalized;
    }
}
