using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Slave
{
    public string key;
    public int star;
    public string name;
    public int maxHealth;
    public int health;
    public double stress;
    public double loyalty;
    public double stressBase;
    public double loyaltyBase;
    public int pay;
    public string title = "";
    public int titleKey = 5000;
    public double workPowerBase;
    public int workPower = 0;

    public Slave(string key, int star, string name, int health, int stress, int loyalty, int pay, int workPowerBase)
    {
        this.key = key;
        this.star = star;
        this.name = name;
        maxHealth = health;
        this.health = health;
        stressBase = stress;
        loyaltyBase = loyalty;
        this.pay = pay;
        this.workPowerBase = workPowerBase;
    }
}
public class SlaveManager : MonoBehaviour
{
    public List<Slave> slaves;
}
