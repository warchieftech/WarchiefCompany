using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicLight2D;

public class MainMoneySystem : MonoBehaviour
{
    public static MainMoneySystem instance;
    [Title("Warchief Main System", 20f, 20)]
    [Space(25f)]
    [Range(100000, 10000000)] public int money = 1000000;
    [Button("Add Money", "MainMoneySystem", "AddMoneyTest")] public bool btn_0;
    [Range(100000, 10000000)] public int rmoney = 1000000;
    [Button("Remove Money", "MainMoneySystem", "RemoveMoneyTest")] public bool btn_1;
    static void AddMoneyTest()
    {
        instance.AddMoney(instance.money);
    }
    static void RemoveMoneyTest()
    {
        instance.RemoveMoney(instance.rmoney);
    }

    [Header("Controllers")]
    public GameSaveSystem gameSaveSystem;
    public TalkCargo talkCargo;
    public GatchaManager gatchaManager;
    public SlaveListManager slaveListManager;
    public CompanyMaster companyMaster;
    public WorkController workController;
    public GameObject copMoney;
    public DateManager dateManager;
    public SkillMaster skillMaster;

    [Header("Settings")]
    public Chief chief;
    public int maxSlaves;
    public List<Slave> Slaves;
    public List<Work> Works;
    public List<Item> Items;
    public List<Title> Titles;
    public GameObject workQuest;
    public GameObject WorkTab;
    public GameObject errorPopup;
    public int getWorkCnt;

    private Coroutine system;
    private Company cop;
    private double Money = 500000000;
    private int workPower;
    private TitleSwitch t;
    private bool payChecker = false;

    private List<int> stressSlave;
    private int ran;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        cop = companyMaster.company;
        t = transform.GetComponent<TitleSwitch>();
        SystemAllBoot();

        skillMaster.UpdateAll();
        //AddSlave("DragonLee", 5, "이용", 100, 50, 50, 50000, 80);
        //AddSlave("SickYang", 5, "양현식", 100, 50, 50, 50000, 70);
        system = StartCoroutine(CostManager());
    }
    // 세이브 파일 불러오기 기능
    private void SystemAllBoot()
    {
        skillMaster.Setup();
        if(PlayerPrefs.GetInt("Load") == 1)
        {
            gameSaveSystem.Load();
            PlayerPrefs.SetInt("Load", 0);
        }
        else
        {

        }
    }
    public void RestartSystem()
    {
        dateManager.RestartDate();
        StartCoroutine(CostManager());
    }
    public void PauseSystem()
    {
        dateManager.PauseDate();
        StopCoroutine(system);
    }
    IEnumerator CostManager()
    {
        UpdateSlave();
        while (true)
        {
            yield return new WaitForSeconds(1);
            companyMaster.Updater();
            Calc();
            StatusUpdate();
            SlavePowerSetter();
            EventProcess();
            Working();
        }
    }

    // 돈계산
    void Calc()
    {
        cop.copPayment = 0;
        foreach (Slave slave in Slaves)
        {
            cop.copPayment += slave.pay;
        }
        if (dateManager.week == 6 && payChecker)   //매주 토요일마다 수당 지급
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
                Money -= (cop.copPayment / 5) * 2 / 5;
            }
        }
        Money -= cop.elecPay;
        copMoney.GetComponent<Text>().text = string.Format("{0}", Money.ToString("N0"));
    }
    void EventProcess()
    {
        ran = UnityEngine.Random.Range(0, 51);
        foreach (int i in stressSlave)
        {
            if (Slaves[i].runAngle)
            {
                switch (ran)
                {
                    default:
                        break;
                    case 50:
                        ErrorPopup(Slaves[i].name + "은(는) 지능이 상승했습니다!!");
                        RemoveSlave(i);
                        break;
                }
            }
        }
    }

    void StatusUpdate()
    {
        stressSlave = new List<int> { };
        for (int i = 0; i < Slaves.Count; i++)
        {
            Slaves[i].stress = Slaves[i].stressBase;
            Slaves[i].loyalty = Slaves[i].loyaltyBase;
            if (Slaves[i].stress > 80 && Slaves[i].health < 20)
            {
                stressSlave.Add(i);
            }
            t.TitleStatus(Slaves[i]);
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
    public void useText(int id)
    {
        talkCargo.ConverText(id);
    }
    public void useEventText(int id)
    {
        talkCargo.ConverEvnetText(id);
    }
    public void SetMoney(string saveMoney)
    {
        Money = Convert.ToDouble(saveMoney);
    }
    public double GetMoney()
    {
        return Money;
    }
    public void AddMoney(int temp)
    {
        Money += temp;
    }
    public void RemoveMoney(double temp)
    {
        Money -= temp;
    }

    public void GetWork()
    {
        Works.Add(workQuest.GetComponent<WorkManager>().work[getWorkCnt]);
        WorkTab.transform.GetChild(1).GetChild(0).GetChild(getWorkCnt).GetComponent<Button>().enabled = false;
        Money += workQuest.GetComponent<WorkManager>().work[getWorkCnt].downPay;
    }
    public void CloseWork()
    {
        workController.CloseWorkPopup();
    }
    public void AddSlave(string key, int star, string name, int health, int stress, int loyalty, int pay, int workPower)
    {
        Slave slaveTemp = new Slave(key, star, name, health, stress, loyalty, pay, workPower);
        Slaves.Add(slaveTemp);
        slaveListManager.UpdateList(Slaves);
    }
    public void RemoveSlave(int cnt)
    {
        Slaves.Remove(Slaves[cnt]);
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
                workQuest.GetComponent<WorkManager>().work[int.Parse(key) - 1].workCheckPoint = 0;
                workController.WorkTab.transform.GetChild(int.Parse(key) - 1).GetComponent<Button>().enabled = true;
                workController.WorkTab.transform.GetChild(int.Parse(key) - 1).GetChild(2).gameObject.SetActive(false);
                if (Works.Count == 0)
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
    public void GatchaStart()
    {
        if(Slaves.Count < maxSlaves)
        {
            if (Money > 500000)
            {
                Money -= 500000;
                gatchaManager.StartGatcha(gatchaManager.normalTable.Count);
            }
            else
            {
                ErrorPopup("회사에 남은 돈이 부족합니다.");
            }
        }
        else
        {
            ErrorPopup("책상이 더 필요합니다.");
        }
    }
    public void GatchaPremiumStart()
    {
        if(Slaves.Count < maxSlaves)
        {
            if (Money > 2000000)
            {
                Money -= 2000000;
                gatchaManager.StartGatcha(gatchaManager.premiumTable.Count);
            }
            else
            {
                ErrorPopup("회사에 남은 돈이 부족합니다.");
            }
        }
        else
        {
            ErrorPopup("책상이 더 필요합니다.");
        }
    }
    public void ErrorPopup(string comment)
    {
        errorPopup.SetActive(true);
        errorPopup.transform.GetChild(0).GetComponent<Text>().text = comment;
        Invoke("PopupCloser", 1);

    }
    public bool GetItem(int price)
    {
        if (Money >= price) return true;
        else return false;
    }
    void PopupCloser()
    {
        errorPopup.SetActive(false);
    }
    public void ItemUseSlave()
    {
        
    }
    public void SkillUpgrade(int id)
    {
        skillMaster.UpgradeSkill(id, Money);
    }
}
