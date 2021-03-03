﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class MainMoneySystem : MonoBehaviour
{
    public GameObject copMoney;
    public DateManager dateManager;
    public List<Slave> Slaves;
    public List<Work> Works;

    private SlaveListManager slaveListManager;
    private CompanyMaster companyMaster;
    private Company cop;
    private int Money = 5000000;
    private int workPower;
    private WorkController workController;
    private TitleSwitch t;
    private bool payChecker = false;
    void Start()
    {
        slaveListManager = GameObject.FindWithTag("SlaveList").GetComponent<SlaveListManager>();
        workController = GameObject.FindWithTag("WorkController").GetComponent<WorkController>();
        companyMaster = GameObject.FindWithTag("CompanyPopup").GetComponent<CompanyMaster>();
        cop = companyMaster.company;
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
            companyMaster.Updater();
            Calc();
            StatusUpdate();
            SlavePowerSetter();
            Working();
        }
    }

    void Calc()
    {
        if(dateManager.week == 6 && payChecker)   //매주 토요일마다 수당 지급
        {
            payChecker = false;
            foreach (Slave slave in Slaves)
            {
                Money -= slave.pay;
                slave.loyaltyBase += 7;
                if (slave.loyaltyBase > 100) slave.loyaltyBase = 100;
                else if (slave.loyaltyBase < 0) slave.loyaltyBase = 0;
            }
        }
        else if(dateManager.week != 6)
        {
            payChecker = true;
        }
        if(dateManager.week == 6 || dateManager.week == 7 || dateManager.week == 0)
        {
            if (dateManager.workDay)
            {
                foreach (Slave slave in Slaves)
                {
                    Money -= (slave.pay / 5) * 2 / 5;
                }
            }
        }
        Money -= cop.elecPay;
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
        if(Works.Count > 0 && dateManager.workDay)
        {
            workPower = 0;
            foreach (Slave s in Slaves)
            {
                workPower += s.workPower;
                s.health--;
                s.stressBase += 0.5;
                s.loyaltyBase = Math.Truncate((s.loyaltyBase -= 0.2) * 10) / 10;
            }
            int userPower = workPower / Works.Count;
            foreach (Work w in Works)
            {
                w.workCheckPoint += userPower;
            }
        }else if (!dateManager.workDay)
        {
            foreach(Slave s in Slaves)
            {
                s.health += 3;
                if (s.health > s.maxHealth) s.health = s.maxHealth;
                else if (s.health < 0) s.health = 0;
                s.stressBase -= 1;
                if (s.stressBase > 100) s.stressBase = 100;
                else if (s.stressBase < 0) s.stressBase = 0;
            }
        }else if(Works.Count == 0 && dateManager.workDay)
        {
            foreach (Slave s in Slaves)
            {
                s.stressBase += 0.25;
                if (s.stressBase > 100) s.stressBase = 100;
                else if (s.stressBase < 0) s.stressBase = 0;
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
