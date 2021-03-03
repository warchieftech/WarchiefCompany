using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Company
{
    public string copName;
    public int copPower;
    public int elecPay;

    public Company(string copName, int copPower, int elecPay)
    {
        this.copName = copName;
        this.copPower = copPower;
        this.elecPay = elecPay;
    }
}
public class CompanyMaster : MonoBehaviour
{
    public Company company;

    public Text copName;
    public Text copPower;
    public Text elecPay;

    public void Updater()
    {
        copName.text = company.copName;
        copPower.text = company.copPower.ToString();
        elecPay.text = company.elecPay.ToString();
    }
}
