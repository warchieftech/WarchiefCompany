using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBtnManager : MonoBehaviour
{
    public Text cost;
    public Text level;

    public void UpdateSkill(double cost, double level)
    {
        this.cost.text = (int)cost + "원";
        this.level.text = level.ToString();
    }
}
