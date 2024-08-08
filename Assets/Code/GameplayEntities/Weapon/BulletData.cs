using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BulletData", menuName = "ScriptableObjects/Stats/BulletData")]
public class BulletData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private bool isBounce;
    // Total variation in degrees
    [SerializeField] private float firingAngle;

    public float Speed { get => speed; set => speed = value; }
    public bool IsBounce { get => isBounce; set => isBounce = value; }
    public float FiringAngle { get => firingAngle; set => firingAngle = value; }

    public void ResetTo(BulletData other)
    {
        Speed = other.speed;
        FiringAngle = other.FiringAngle;
        IsBounce = other.isBounce;
    }
}
