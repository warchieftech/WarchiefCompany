using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePopupObj : MonoBehaviour
{
    public Image Img;
    public Text Name;
    public Text Content;
    public int titleKey;
    public int slavePos;
    public bool personalTitle;

    private MainMoneySystem mainSystem;
    public Canvas TitleList;
    public Canvas TitlePopup;

    private void Start()
    {
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    public void AddTitle()
    {
        if (personalTitle)
        {
            mainSystem.ErrorPopup("전용 타이틀은 교체가 불가능합니다.");
        }
        else
        {
            Slave s = mainSystem.Slaves[slavePos];
            s.title = Name.text;
            s.titleKey = this.titleKey;
            if (s.titleKey != 5002) s.runAngle = true;
            mainSystem.UpdateSlave();
            TitleList.enabled = false;
            TitlePopup.enabled = false;
            mainSystem.ErrorPopup("타이틀이 적용되었습니다.");
        }
    }
}
