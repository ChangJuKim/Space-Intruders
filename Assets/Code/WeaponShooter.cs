using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooter : MonoBehaviour
{
    public Weapon weapon;
    public FloatVariable num;


    // Start is called before the first frame update
    void Start()
    {
        
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
