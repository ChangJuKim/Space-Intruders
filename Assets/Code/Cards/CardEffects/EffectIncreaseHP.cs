using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectIncreaseHP : ICardEffect
{
    [SerializeField] private HP hp;

    public void PerformEffect()
    {
        hp.IncreaseHP(2);
        Debug.Log("You increased HP!");
    }
}
