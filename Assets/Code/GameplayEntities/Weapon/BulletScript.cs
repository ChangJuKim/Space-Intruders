using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private GameEvent playerLossEvent;

    [SerializeField] private BulletData bulletData;
    // TODO: Temporary fix for getting base bullet to be used in ResetTo
    // Doing it this way because bullet is a prefab, and it's somewhat difficult to hold bulletData in the weapon instead of in the bullet 
    [SerializeField] private BulletData baseBulletData;

    private Vector2 direction;

    public BulletData BulletData { get => bulletData; set => bulletData = value; }

    // TODO: Consider refactoring bullets somehow. Ideally it has multiple fields or interfaces (e.g. IBounceable, IHasPoison) or something
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
        float randomAngle = Random.Range(-1 * BulletData.FiringAngle / 2, BulletData.FiringAngle / 2);
        float angleInRadians = randomAngle * Mathf.PI/180;
        float yVelocity = 1;
        float xVelocity = Mathf.Tan(angleInRadians) * yVelocity;
        return new Vector2(xVelocity, yVelocity).normalized;
    }

    // Ideally can just call bullet's ResetTo or something
    public void ResetTo()
    {
        BulletData.ResetTo(baseBulletData);
    }
}

