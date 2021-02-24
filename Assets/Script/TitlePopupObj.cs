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
    public string slaveKey;

    private MainMoneySystem mainSystem;
    public Canvas TitleList;
    public Canvas TitlePopup;

    private void Start()
    {
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    public void AddTitle()
    {
        foreach (Slave s in mainSystem.Slaves)
        {
            if (s.key == slaveKey)
            {
                s.title = Name.text;
                s.titleKey = this.titleKey;
                mainSystem.UpdateSlave();
                TitleList.enabled = false;
                TitlePopup.enabled = false;
            }
        }
    }
}
