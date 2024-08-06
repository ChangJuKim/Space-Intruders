using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        weapon.SetCooldown(0);
    }

    void Update()
    {
        weapon.DecreaseCooldown(Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.Fire(transform);
        }
    }

    public void SwapWeapon(Weapon other)
    {
        weapon = other;
    }



}
