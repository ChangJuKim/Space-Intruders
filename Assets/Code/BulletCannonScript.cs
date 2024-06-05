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
        direction = new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
        rigidBody.velocity = direction * speed;
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with object");
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
