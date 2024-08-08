using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponShooter : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private StringVariable gameSceneName;

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
            if (SceneManager.GetActiveScene().name == gameSceneName.Value)
            {
                weapon.Fire(transform);
            }
        }
    }

    public void SwapWeapon(Weapon other)
    {
        weapon = other;
    }



}
