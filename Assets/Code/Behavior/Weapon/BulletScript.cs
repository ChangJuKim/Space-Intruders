using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private GameEvent playerLossEvent;

    [SerializeField] private BulletData bulletData;
    [SerializeField] private BulletData baseBulletData; // TODO: Temporary fix for getting base bullet

    private Vector2 direction;

    public BulletData BulletData { get => bulletData; set => bulletData = value; }

    // TODO: Remove this script somehow and make bullets have a constant feature?
    // Or make bullets extend from a bullet class that has some standard features? IDK
    // Start is called before the first frame update
    void Start()
    {
        direction = getDirection();
        rigidBody.velocity = direction * BulletData.Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                playerLossEvent.Raise();
                break;

            case "Wall":
                if (BulletData.IsBounce)
                {
                    Bounce(collision.contacts[0].normal);
                }
                else
                {
                    Destroy(gameObject);
                }
                break;

            case "Bullet":
                break;

            default:
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }
    }

    private void Bounce(Vector2 normal)
    {
        direction = Vector2.Reflect(direction, normal).normalized;
        rigidBody.velocity = direction * BulletData.Speed;
    }

    // Returns the new value of bounce
    public bool toggleBounce()
    {
        BulletData.IsBounce = !BulletData.IsBounce;
        return BulletData.IsBounce;
    }

    private Vector2 getDirection()
    {
        float angleInRadians = BulletData.FiringAngle / 2 * Mathf.PI/180;
        float yVelocity = 1;
        float xVariation = Mathf.Tan(angleInRadians) * yVelocity;
        return new Vector2(Random.Range(-1 * xVariation, xVariation), yVelocity).normalized;
    }

    public void ResetTo()
    {
        BulletData.ResetTo(baseBulletData);
    }
}

