using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CardData cardData;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image spriteImage;
    [SerializeField] private Image bgSpriteImage;
    [SerializeField] private CardType cardType;

    [SerializeField] private GameEvent startGameEvent;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = cardData.Name;
        descriptionText.text = cardData.Desc;
        spriteImage.sprite = cardData.Sprite;
        bgSpriteImage.sprite = cardData.BgSprite;
        cardType = cardData.CardType;
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
