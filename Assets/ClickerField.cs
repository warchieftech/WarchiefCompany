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

    private int point;
    private int ran;

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
        {
            if(mainSystem.Works.Count > 0)
            {
                clickEvent = Instantiate(Resources.Load("ClickerEffect") as GameObject);
                ran = Random.Range(1, 101);
                if(ran <= mainSystem.chief.workCritical && ran != 0)
                {
                    point = (int) ((mainSystem.chief.workPower * 2) * mainSystem.chief.handsCnt);
                    clickEvent.transform.GetChild(0).GetComponent<Text>().text = "크리티컬 +" + point + "!!!";
                }
                else
                {
                    point = (int) (mainSystem.chief.workPower * mainSystem.chief.handsCnt);
                    clickEvent.transform.GetChild(0).GetComponent<Text>().text = "작업 +" + point;
                }
                for (int i = 0; i < mainSystem.Works.Count; i++)
                {
                    mainSystem.Works[i].workCheckPoint += point / mainSystem.Works.Count;
                }
                clickEvent.transform.SetParent(transform);
                clickEvent.transform.position = eventData.position;
                ctpm.InnerText();
            }
            else mainSystem.ErrorPopup("업무가 없어요");
        }
    }
}
