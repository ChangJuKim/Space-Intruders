using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    public FloatVariable maxSpeed;
    public float acceleration;
    public float weaponRemainingCooldown = 0;
    public float offset;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
    }

    private void HandlePlayerInput()
    {
        CheckMovement();
        CheckFiring();
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity += Vector2.left * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
            rigidBody.velocity += Vector2.right * acceleration * Time.deltaTime;
        }
        if (rigidBody.velocity.magnitude > maxSpeed.value)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed.value;
        }
    }

    private void CheckFiring()
    {
        if (Input.GetKey(KeyCode.Space) && weaponRemainingCooldown <= 0)
        {
            weaponRemainingCooldown = Constants.WEAPON_COOLDOWN;
            SpawnBullet();
        }
        weaponRemainingCooldown -= Time.deltaTime;
    }

    private void SpawnBullet()
    {
        Vector3 offsetVector = Vector3.up * offset;
        Instantiate(bullet, transform.position + offsetVector, transform.rotation);
    }
}
