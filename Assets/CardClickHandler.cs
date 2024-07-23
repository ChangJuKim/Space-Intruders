using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardClickHandler : MonoBehaviour, IPointerClickHandler
{
    public FloatVariable playerHP;

    public void OnPointerClick(PointerEventData eventData)
    {
        HandleClick();
    }

    private void HandleClick()
    {
        Debug.Log("Hello!");
        playerHP.value += 3;
    }
}
