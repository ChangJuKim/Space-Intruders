using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectIncreaseHP : ICardEffect
{
    public HP hp;

    public void PerformEffect()
    {
        hp.IncreaseHP(2);
    }
}
