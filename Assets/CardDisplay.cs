using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{

    public Card card;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    public Image spriteImage;
    public Image bgSpriteImage;

    public CardType cardType;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = descriptionText.name;
        spriteImage.sprite = card.sprite;
        bgSpriteImage.sprite = card.bgSprite;
        cardType = card.cardType;
    }
}
