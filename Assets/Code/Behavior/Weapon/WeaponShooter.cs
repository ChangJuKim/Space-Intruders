using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    public Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        weapon.SetCooldown(0);
    }

    // Update is called once per frame
    void Update()
    {
        weapon.DecreaseCooldown(Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.Fire(transform);
        }
    }



}
