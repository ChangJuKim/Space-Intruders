using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectIncreaseSpeed : ICardEffect
{
    public FloatVariable speed;

    public void PerformEffect()
    {
        speed.value += 1;
    }
}
