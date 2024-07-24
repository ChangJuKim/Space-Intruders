using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{

    public CardData cardData;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image spriteImage;
    public Image bgSpriteImage;
    public CardType cardType;

    public PlayerStats playerStats;
    public GameEvent startGameEvent;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = cardData.name;
        descriptionText.text = cardData.desc;
        spriteImage.sprite = cardData.sprite;
        bgSpriteImage.sprite = cardData.bgSprite;
        cardType = cardData.cardType;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HandleClick();
        ResumeGame();
    }

    private void HandleClick()
    {
        cardData.PerformEffect();
    }

    private void ResumeGame()
    {
        startGameEvent.Raise();
    }
}
