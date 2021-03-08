using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Work
{
    public string key;
    public int star;
    public string name;
    public int downPay;
    public int pay;
    public int workPoint;
    public int workCheckPoint;

    public Work(string key, int star, string name, int downPay, int pay, int wp, int wcp)
    {
        this.key = key;
        this.star = star;
        this.name = name;
        this.downPay = downPay;
        this.pay = pay;
        this.workPoint = wp;
        this.workCheckPoint = wcp;
    }
}
public class WorkManager : MonoBehaviour
{
    public List<Work> work;
}
