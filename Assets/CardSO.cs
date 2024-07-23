using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Player = 0,
    Enemy = 1
}

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    public new string name;
    [TextArea(1,3)]
    public string desc;

    public Sprite sprite;
    public Sprite bgSprite;

    public CardType cardType;

    public void Print()
    {
        Debug.Log("(" + cardType + ") " + name + ": " + desc);
    }
}
