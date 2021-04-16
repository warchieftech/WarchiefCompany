using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMaster : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public GameObject skill;

    public List<SkillBtnManager> skills;


    public void Setup()
    {
        for (int i = 0; i < skill.transform.childCount; i++)
        {
            skills.Add(skill.transform.GetChild(i).GetComponent<SkillBtnManager>());
        }
    }
    public void UpdateAll()
    {
        skills[0].UpdateSkill(mainSystem.chief.wpCost, mainSystem.chief.workPower);
        skills[1].UpdateSkill(mainSystem.chief.wcCost, mainSystem.chief.workCritical);
        skills[2].UpdateSkill(mainSystem.chief.handsCost, mainSystem.chief.handsCnt);
    }

    public void UpgradeSkill(int id, double money)
    {
        switch (id)
        {
            case 0:
                if(money >= mainSystem.chief.wpCost)
                {
                    mainSystem.RemoveMoney(mainSystem.chief.wpCost);
                    mainSystem.chief.workPower++;
                    mainSystem.chief.wpCost = (int) mainSystem.chief.wpCost * 1.1;
                    skills[0].UpdateSkill(mainSystem.chief.wpCost, mainSystem.chief.workPower);
                }
                else
                {
                    mainSystem.ErrorPopup("잔액이 모자랍니다.");
                }
                break;
            case 1:
                if (money >= mainSystem.chief.wcCost)
                {
                    mainSystem.RemoveMoney(mainSystem.chief.wcCost);
                    mainSystem.chief.workCritical++;
                    mainSystem.chief.wcCost = (int) mainSystem.chief.wcCost * 1.1;
                    skills[1].UpdateSkill(mainSystem.chief.wcCost, mainSystem.chief.workCritical);
                }
                else
                {
                    mainSystem.ErrorPopup("잔액이 모자랍니다.");
                }
                break;
            case 2:
                if (money >= mainSystem.chief.handsCost)
                {
                    mainSystem.RemoveMoney(mainSystem.chief.handsCost);
                    mainSystem.chief.handsCnt++;
                    mainSystem.chief.handsCost = (int) mainSystem.chief.handsCost * 1.1;
                    skills[2].UpdateSkill(mainSystem.chief.handsCost, mainSystem.chief.handsCnt);
                }
                else
                {
                    mainSystem.ErrorPopup("잔액이 모자랍니다.");
                }
                break;
        }
    }
}
