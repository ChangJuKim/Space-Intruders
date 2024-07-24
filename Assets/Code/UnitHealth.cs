using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New HP", menuName = "ScriptableObjects/HP")]
public class HP : ScriptableObject
{
    public FloatVariable hp;

    public void DecreaseHP(float damage)
    {
        hp.value -= damage;
    }

    public void IncreaseHP(float bonus)
    {
        hp.value += bonus;
    }

    public void ResetTo(HP other)
    {
        hp.ResetTo(other.hp);
    }
}
