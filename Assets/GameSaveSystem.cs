using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveSystem : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public WorkManager workManager;

    public void Save()
    {
        mainSystem.ErrorPopup("저장을 시작합니다.");
        mainSystem.PauseSystem();

        PlayerPrefs.SetInt("Chief0", (int)mainSystem.chief.workPower);
        PlayerPrefs.SetInt("Chief1", (int)mainSystem.chief.workCritical);
        PlayerPrefs.SetInt("Chief2", (int)mainSystem.chief.handsCnt);
        PlayerPrefs.SetString("CopMoney", mainSystem.GetMoney().ToString());
        PlayerPrefs.SetInt("SlaveCnt", mainSystem.Slaves.Count);
        for(int i = 0; i < mainSystem.Slaves.Count; i++)
        {
            PlayerPrefs.SetString("SlaveKey_" + i, mainSystem.Slaves[i].key);
            PlayerPrefs.SetInt("SlaveStar_" + i, mainSystem.Slaves[i].star);
            PlayerPrefs.SetString("SlaveName_" + i, mainSystem.Slaves[i].name);
            PlayerPrefs.SetInt("SlaveHealth_" + i, mainSystem.Slaves[i].health);
            PlayerPrefs.SetInt("SlaveStress_" + i, (int)mainSystem.Slaves[i].stressBase);
            PlayerPrefs.SetInt("SlaveLoyal_" + i, (int)mainSystem.Slaves[i].loyaltyBase);
            PlayerPrefs.SetInt("SlavePay_" + i, mainSystem.Slaves[i].pay);
            PlayerPrefs.SetInt("SlavePower_" + i, (int)mainSystem.Slaves[i].workPowerBase);
            PlayerPrefs.SetInt("SlaveTitle_" + i, mainSystem.Slaves[i].titleKey);
        }
        PlayerPrefs.SetInt("WorkCnt", mainSystem.Works.Count);
        for(int i = 0; i < mainSystem.Works.Count; i++)
        {
            PlayerPrefs.SetString("WorkKey_" + i, mainSystem.Works[i].key);
            PlayerPrefs.SetInt("WorkCP_" + i, (int)mainSystem.Works[i].workCheckPoint);
        }
        PlayerPrefs.SetInt("ItemCnt", mainSystem.Items.Count);
        for(int i = 0; i < mainSystem.Items.Count; i++)
        {
            PlayerPrefs.SetInt("ItemCnt_" + i, mainSystem.Items[i].cnt);
        }
        PlayerPrefs.SetInt("Year", mainSystem.dateManager.year);
        PlayerPrefs.SetInt("Mon", mainSystem.dateManager.month);
        PlayerPrefs.SetInt("Day", mainSystem.dateManager.day);

        PlayerPrefs.SetInt("ChiefPower", (int)mainSystem.chief.workPower);
        PlayerPrefs.SetInt("ChiefPC", (int)mainSystem.chief.wpCost);
        PlayerPrefs.SetInt("ChiefCri", (int)mainSystem.chief.workCritical);
        PlayerPrefs.SetInt("ChiefCC", (int)mainSystem.chief.wcCost);
        PlayerPrefs.SetInt("ChiefHands", (int)mainSystem.chief.handsCnt);
        PlayerPrefs.SetInt("ChiefHC", (int)mainSystem.chief.handsCost);

        mainSystem.RestartSystem();
        mainSystem.ErrorPopup("저장을 끝났습니다.");
    }

    public void Load()
    {
        mainSystem.SetMoney(PlayerPrefs.GetString("CopMoney"));
        mainSystem.maxSlaves = PlayerPrefs.GetInt("ItemCnt_0");
        mainSystem.dateManager.year = PlayerPrefs.GetInt("Year");
        mainSystem.dateManager.month = PlayerPrefs.GetInt("Month");
        mainSystem.dateManager.day = PlayerPrefs.GetInt("Day");

        mainSystem.chief.workPower = PlayerPrefs.GetInt("ChiefPower");
        mainSystem.chief.wpCost = PlayerPrefs.GetInt("ChiefPC");
        mainSystem.chief.workCritical = PlayerPrefs.GetInt("ChiefCri");
        mainSystem.chief.wcCost = PlayerPrefs.GetInt("ChiefCC");
        mainSystem.chief.handsCnt = PlayerPrefs.GetInt("ChiefHands");
        mainSystem.chief.handsCost = PlayerPrefs.GetInt("ChiefHC");

        for (int i = 0; i < PlayerPrefs.GetInt("SlaveCnt"); i++)
        {
            mainSystem.AddSlave(
                PlayerPrefs.GetString("SlaveKey_" + i),
                PlayerPrefs.GetInt("SlaveStar_" + i),
                PlayerPrefs.GetString("SlaveName_" + i),
                PlayerPrefs.GetInt("SlaveHealth_" + i),
                PlayerPrefs.GetInt("SlaveStress_", +i),
                PlayerPrefs.GetInt("SlaveLoyal_" + i),
                PlayerPrefs.GetInt("SlavePay_" + i),
                PlayerPrefs.GetInt("SlavePower_" + i)
                );
            mainSystem.Slaves[i].titleKey = PlayerPrefs.GetInt("SlaveTitle_" + i);
        }
        mainSystem.UpdateSlave();
        for (int i = 0; i < PlayerPrefs.GetInt("WorkCnt"); i++)
        {
            mainSystem.Works.Add(mainSystem.workQuest.GetComponent<WorkManager>().work[int.Parse(PlayerPrefs.GetString("WorkKey_" + i)) - 1]);
            mainSystem.Works[i].workCheckPoint = PlayerPrefs.GetInt("WorkCP_" + i);
        }
        for(int i = 0; i < PlayerPrefs.GetInt("ItemCnt"); i++)
        {
            mainSystem.Items[i].cnt = PlayerPrefs.GetInt("ItemCnt_" + i);
        }

        mainSystem.skillMaster.UpdateAll();
        mainSystem.ErrorPopup("불러오기 완료");
    }
}
