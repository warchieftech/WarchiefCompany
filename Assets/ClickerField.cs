using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerField : MonoBehaviour, IPointerClickHandler
{
    public MainMoneySystem mainSystem;
    public CodeTextPrintManager ctpm;
    public GameObject clickEvent;

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            if(mainSystem.Works.Count > 0)
            {
                clickEvent = Instantiate(Resources.Load("ClickerEffect") as GameObject);
                Debug.Log("Mouse Position : " + eventData.position);
                for (int i = 0; i < mainSystem.Works.Count; i++)
                {
                    mainSystem.Works[i].workCheckPoint += mainSystem.chief.workPower / mainSystem.Works.Count;
                }
                clickEvent.transform.GetChild(0).GetComponent<Text>().text = "작업 + " + mainSystem.chief.workPower;
                clickEvent.transform.SetParent(transform);
                clickEvent.transform.position = eventData.position;
                ctpm.InnerText();
            }
            else mainSystem.ErrorPopup("업무가 없어요");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {

        }
        else if (eventData.button == PointerEventData.InputButton.Right) 
        {

        }
    }
}
