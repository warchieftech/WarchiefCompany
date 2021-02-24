using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class MainMoneySystem : MonoBehaviour
{
    public GameObject copMoney;
    public List<Slave> Slaves;
    public List<Work> Works;

    private SlaveListManager slaveListManager;
    private int Money = 5000000;
    private int workPower;
    private WorkController workController;
    private TitleSwitch t;
    void Start()
    {
        slaveListManager = GameObject.FindWithTag("SlaveList").GetComponent<SlaveListManager>();
        workController = GameObject.FindWithTag("WorkController").GetComponent<WorkController>();
        t = transform.GetComponent<TitleSwitch>();

        AddSlave("DragonLee", 5, "이용선", 100, 50, 50, 50000, 80);
        AddSlave("SickYang", 5, "양현식", 100, 50, 50, 50000, 70);
        StartCoroutine(CostManager());
    }

    IEnumerator CostManager()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Calc();
            StatusUpdate();
            SlavePowerSetter();
            Working();
        }
    }

    void Calc()
    {
        foreach(Slave slave in Slaves)
        {
            Money -= slave.pay;
        }
        copMoney.GetComponent<Text>().text = Money.ToString();
    }
    void StatusUpdate()
    {
        foreach(Slave s in Slaves)
        {
            s.stress = s.stressBase;
            s.loyalty = s.loyaltyBase;
            t.TitleStatus(s);
        }
    }

    void SlavePowerSetter()
    {
        foreach(Slave s in Slaves)
        {
            s.workPower = (int)(s.workPowerBase + (s.workPowerBase * (s.loyalty / 100)) - (s.workPowerBase * (s.stress / 100)));
        }
    }

    void Working()
    {
        if(Works.Count > 0)
        {
            workPower = 0;
            foreach (Slave s in Slaves)
            {
                workPower += s.workPower;
            }
            int userPower = workPower / Works.Count;
            foreach (Work w in Works)
            {
                w.workCheckPoint += userPower;
            }
        }
    }

    public void AddMoney(int temp)
    {
        Money += temp;
    }

    public void GetWork(GameObject workQuest)
    {
        Works.Add(workQuest.GetComponent<WorkManager>().work);
        Money += workQuest.GetComponent<WorkManager>().work.downPay;
    }
    public void AddSlave(string key, int star, string name, int health, int stress, int loyalty, int pay, int workPower)
    {
        Slave slaveTemp = new Slave(key, star, name, health, stress, loyalty, pay, workPower);
        Slaves.Add(slaveTemp);
        slaveListManager.UpdateList(Slaves);
    }
    public void UpdateSlave()
    {
        slaveListManager.UpdateList(Slaves);
    }
    public void FinishWork(string key)
    {
        int temp;
        for(int i = 0; i < Works.Count; i++)
        {
            if(Works[i].key == key)
            {
                Money += Works[i].pay;
                Works.RemoveAt(i);
                if(Works.Count == 0)
                {
                    workController.workBtn.GetComponent<Button>().enabled = false;
                    workController.workText.text = "계약한 업무가 없습니다.";
                }
                else
                {
                    workController.qCnt = 0;
                }
            }
        }
    }
}
