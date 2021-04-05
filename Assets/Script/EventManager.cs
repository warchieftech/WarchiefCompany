using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public void EventPlayer(int id, bool check, int slaveCnt = 0)
    {
        Debug.Log(slaveCnt);
        switch (id)
        {
            case 1:
                if (check)
                {
                    mainSystem.ErrorPopup(mainSystem.Slaves[slaveCnt].name + "의 급여가 올랐습니다.");
                    mainSystem.Slaves[slaveCnt].pay += (int) (mainSystem.Slaves[slaveCnt].pay * 0.2);
                }
                else
                {
                    mainSystem.ErrorPopup(mainSystem.Slaves[slaveCnt].name + "의 충성심이 떨어졌습니다.");
                    mainSystem.Slaves[slaveCnt].loyaltyBase -= 10;
                }
                break;

            default:
                break;
        }
    }
}
