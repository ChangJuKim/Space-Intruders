using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EffectIncreaseAtkSpd : ICardEffect
{

    public void PerformEffect()
    {
        Debug.Log("You chose attack speed!");
    }
}
