using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoyeTest : MonoBehaviour
{
    public MainMoneySystem m;
    public SlaveListManager s;
    public void AddNoye()
    {
        m.AddSlave("SungBae", 5, "배성현", 100, 50, 50, 1000, 60);
    }
    public void AddTitle()
    {
        m.Slaves[0].title = "질풍의 노예";
        m.Slaves[1].title = "개돼지";
        //m.Slaves[2].title = "주식의 신";
        m.UpdateSlave();
    }
}
