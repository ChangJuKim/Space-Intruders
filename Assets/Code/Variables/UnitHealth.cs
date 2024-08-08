using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HP", menuName = "ScriptableObjects/Stats/HP")]
public class HP : ScriptableObject
{
    [SerializeField] private FloatVariable hp;

    public void DecreaseHP(float damage)
    {
        hp.Value -= damage;
    }

    public void IncreaseHP(float bonus)
    {
        hp.Value += bonus;
    }

    public void ResetTo(HP other)
    {
        hp.ResetTo(other.hp);
    }
}
