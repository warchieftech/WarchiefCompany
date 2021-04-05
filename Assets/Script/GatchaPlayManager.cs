using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SlaveStatus
{
    public Text name;
    public Text health;
    public Text stress;
    public Text loyalty;
    public Text pay;
    public Text workPower;
    public Text title;
    public Image star;
}
public class GatchaPlayManager : MonoBehaviour
{
    public GatchaManager gatchaManager;
    public Canvas statusPopup;
    public Canvas gatChaplay;
    public SlaveStatus status;

    public string keyName;

    private Slave thisSlave;

    private MainMoneySystem MainSystem;

    private void Start()
    {
        MainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    public void OpenStatus(int index)
    {
        for (int i = 0; i < gatchaManager.slaveList.slavePack.Count; i++)
        {
            if (gatchaManager.slaveList.slavePack[i].key == gatchaManager.getCharaList[index])
            {
                thisSlave = gatchaManager.slaveList.slavePack[i];
            }
        }
        status.name.text = thisSlave.name;
        status.health.text = thisSlave.maxHealth.ToString();
        status.stress.text = thisSlave.stressBase.ToString();
        status.loyalty.text = thisSlave.loyalty.ToString();
        status.pay.text = thisSlave.pay.ToString();
        status.workPower.text = thisSlave.workPowerBase.ToString();
        status.title.text = thisSlave.title.ToString();
        switch (thisSlave.star)
        {
            case 1:
                status.star.sprite = Resources.Load<Sprite>("image/normal");
                break;
            case 2:
                status.star.sprite = Resources.Load<Sprite>("image/rare");
                break;
            case 3:
                status.star.sprite = Resources.Load<Sprite>("image/ultraRare");
                break;
            case 4:
                status.star.sprite = Resources.Load<Sprite>("image/unique");
                break;
            case 5:
                status.star.sprite = Resources.Load<Sprite>("image/epic");
                break;
        }
        statusPopup.enabled = true;
    }

    public void AddMyCop()
    {
        MainSystem.AddSlave(thisSlave.key, thisSlave.star, thisSlave.name, thisSlave.health, (int)thisSlave.stressBase, (int)thisSlave.loyaltyBase, thisSlave.pay, (int)thisSlave.workPowerBase);
        if (thisSlave.titleKey >= 5000)
        {
            MainSystem.Slaves[MainSystem.Slaves.Count - 1].titleKey = thisSlave.titleKey;
            MainSystem.Slaves[MainSystem.Slaves.Count - 1].title = thisSlave.title;
        }
        MainSystem.UpdateSlave();
        statusPopup.enabled = false;
        gatChaplay.enabled = false;
    }
}
