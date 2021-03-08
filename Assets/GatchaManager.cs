using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatchaManager : MonoBehaviour
{
    public List<string> normal;
    public List<string> rare;
    public List<string> superRare;
    public List<string> unique;
    public List<string> epic;
    public SlaveList slaveList;
    public Canvas gatchaPlay;
    public GameObject AnimationObj;

    public List<string> getCharaList = new List<string>(new string[3]);
    public List<GameObject> SlaveObj;

    private MainMoneySystem MainSystem;
    private int ran;
    private int charRan;

    private void Start()
    {
        MainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();

        foreach (Slave s in slaveList.slavePack)
        {
            switch (s.star)
            {
                case 1:
                    normal.Add(s.key);
                    break;
                case 2:
                    rare.Add(s.key);
                    break;
                case 3:
                    superRare.Add(s.key);
                    break;
                case 4:
                    unique.Add(s.key);
                    break;
                case 5:
                    epic.Add(s.key);
                    break;
            }
        }
    }
    public void StartGatcha()
    {
        for (int i = 0; i < 3; i++)
        {
            ran = Random.Range(1, 11);
            switch (ran)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    getChara(normal, i);
                    break;
                case 7:
                case 8:
                case 9:
                    getChara(rare, i);
                    break;
                case 10:
                    getChara(superRare, i);
                    break;
            }
        }
        AnimationObj.SetActive(true);
        Invoke("OpenPopup", 1);
    }

    public void StartPremiumGatcha()
    {
        for(int i = 0; i < 3; i++)
        {
            ran = Random.Range(1, 17);
            switch (ran)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    getChara(normal, i);
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                    getChara(rare, i);
                    break;
                case 11:
                case 12:
                case 13:
                    getChara(superRare, i);
                    break;
                case 14:
                case 15:
                    getChara(unique, i);
                    break;
                case 16:
                    getChara(epic, i);
                    break;
            }
        }
        AnimationObj.SetActive(true);
        Invoke("OpenPopup", 1);
    }

    public void getChara(List<string> star, int index)
    {
        AnimationObj.SetActive(false);
        charRan = Random.Range(0, star.Count);
        getCharaList[index] = star[charRan];
    }
    public void OpenPopup()
    {
        ImageChanger();
        gatchaPlay.enabled = true;
    }
    public void ImageChanger()
    {
        for(int i = 0; i < 3; i++)
        {
            SlaveObj[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Character/img/" + getCharaList[i]);
        }
    }

}
