using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Player = 0,
    Enemy = 1
}

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
public class CardData : ScriptableObject
{
    public new string name;
    [TextArea(1,3)]
    public string desc;

    public Sprite sprite;
    public Sprite bgSprite;

    public CardType cardType;

    [SerializeReference]
    public ICardEffect effect;

    public void Print()
    {
        Debug.Log("(" + cardType + ") " + name + ": " + desc);
    }

    public void PerformEffect()
    {
        Print();
        effect?.PerformEffect();

    }
}
