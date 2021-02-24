using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitlePopup : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Popup;
    private bool isBtnDown = false;
    private float time;
    private void Update()
    {
        if (isBtnDown)
        {
            if(time < 0)
            {
                Popup.SetActive(true);
            }
            time -= Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
        time = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }
}
