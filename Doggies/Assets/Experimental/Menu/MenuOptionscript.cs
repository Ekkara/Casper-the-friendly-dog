using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MenuOptionscript : MonoBehaviour, IPointerEnterHandler
{
    //Invoke a unity eventt if selected from main menu script
    [SerializeField] int index;
    [SerializeField] UnityEvent OnSelect;
    [SerializeField] MainMenuScrip menuHandler;
    [SerializeField] Text text;
    [SerializeField] Image image;

    public void OptionSelected() {
        OnSelect.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        menuHandler.ChangeOptionTo(index);
    }
    public void UpdateColors(Color textColor, Color imageColor) {
        text.color = textColor;
        image.color = imageColor;
    }
}
