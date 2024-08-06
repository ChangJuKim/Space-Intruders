using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectIncreaseSpeed : ICardEffect
{
    [SerializeField] private FloatVariable speed;
    [SerializeField] private float amount;

    public void PerformEffect()
    {
        speed.value += amount;
    }
}
