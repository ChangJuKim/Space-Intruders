using UnityEngine;

public enum CardType
{
    Player = 0,
    Enemy = 1
}

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
public class CardData : ScriptableObject
{
    
    [SerializeField] private new string name;
    [TextArea(1,3)]
    [SerializeField] private string desc;

    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite bgSprite;

    [SerializeField] private CardType cardType;

    [SerializeReference]
    private ICardEffect effect;

    public string Name { get => name; set => name = value; }
    public string Desc { get => desc; set => desc = value; }
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public Sprite BgSprite { get => bgSprite; set => bgSprite = value; }
    public CardType CardType { get => cardType; set => cardType = value; }

    public void Print()
    {
        Debug.Log("(" + CardType + ") " + Name + ": " + Desc);
    }

    public void PerformEffect()
    {
        effect?.PerformEffect();
    }
}
