using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletData", menuName = "ScriptableObjects/BulletData")]
public class BulletData : ScriptableObject
{
    public float speed;
    public bool isBounce;
    // Total variation in degrees
    public float firingAngle;

    public void ResetTo(BulletData other)
    {
        speed = other.speed;
        firingAngle = other.firingAngle;
        isBounce = other.isBounce;
    }
}
