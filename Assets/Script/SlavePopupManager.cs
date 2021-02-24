using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlavePopupManager : MonoBehaviour
{
    public MainMoneySystem system;
    public Slave slave;

    public GameObject TitleList;
    public GameObject TitlePopup;
    public Text title;
    public Text name;
    public Image face;
    public Text workPower;
    public Text workPowerBase;
    public Image hpbar;
    public Text hpText;
    public Image stressbar;
    public Text stressText;
    public Image loyalbar;
    public Text loyalText;
    public Text pay;

    public void SlaveSetting(string key)
    {
        foreach(Slave s in system.Slaves)
        {
            if(s.key == key)
            {
                slave = s;
            }

        }
    }

    void Start()
    {
        StartCoroutine(StatusUpadate());
    }
    IEnumerator StatusUpadate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Status();
        }
    }
    public void Status()
    {
        title.text = slave.title;
        name.text = slave.name;
        face.sprite = Resources.Load<Sprite>("Character/img/" + slave.key);
        workPower.text = slave.workPower.ToString();
        workPowerBase.text = slave.workPowerBase.ToString();
        hpbar.fillAmount = (float) slave.health / 100f;
        hpText.text = string.Format(slave.health.ToString());
        stressbar.fillAmount = (float)slave.stress / 100f;
        stressText.text = string.Format(slave.stress.ToString());
        loyalbar.fillAmount = (float)slave.loyalty / 100f;
        loyalText.text = string.Format(slave.loyalty.ToString());
        pay.text = slave.pay.ToString();
    }
    public void TitlePopupBtn()
    {
        TitlePopup.GetComponent<TitlePopupObj>().slaveKey = slave.key;
        TitleList.GetComponent<Canvas>().enabled = true;
    }
}
