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

    [Header("Nomal Setting")]
    public int nN;
    public int nR;
    public int nSR;
    public int nU;
    public int nE;
    [Header("Premium Setting")]
    public int pN;
    public int pR;
    public int pSR;
    public int pU;
    public int pE;

    public Hashtable normalTable = new Hashtable();
    public Hashtable premiumTable = new Hashtable();

    private void Start()
    {
        MainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();

        for(int i = 0; i < nN + nR + nSR + nU + nE; i++)
        {
            if(i < nN)
            {
                normalTable.Add(i, 0);
            }
            else if (i < nR)
            {
                normalTable.Add(i, 1);
            }
            else if (i < nSR)
            {
                normalTable.Add(i, 2);
            }
            else if (i < nU)
            {
                normalTable.Add(i, 3);
            }
            else
            {
                normalTable.Add(i, 4);
            }
        }
        for (int i = 0; i < pN + pR + pSR + pU + pE; i++)
        {
            Debug.Log(pN + pR + pSR + pU + pE + "퍼센트");
            if (i < pN)
            {
                premiumTable.Add(i, 0);
            }
            else if (i < pR)
            {
                premiumTable.Add(i, 1);
            }
            else if (i < pSR)
            {
                premiumTable.Add(i, 2);
            }
            else if (i < pU)
            {
                premiumTable.Add(i, 3);
            }
            else
            {
                premiumTable.Add(i, 4);
            }
        }

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
    public void StartGatcha(int tableCnt)
    {
        if(tableCnt == normalTable.Count)
        {
            for (int i = 0; i < 3; i++)
            {
                int temp = Random.Range(0, tableCnt);

                if (temp < nN)
                {
                    getChara(normal, i);
                }
                else if (temp < nR)
                {
                    getChara(rare, i);
                }
                else if (temp < nSR)
                {
                    getChara(superRare, i);
                }
                else if (temp < nU)
                {
                    getChara(unique, i);
                }
                else
                {
                    getChara(epic, i);
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                int temp = Random.Range(0, tableCnt);

                if (temp < pN)
                {
                    getChara(normal, i);
                }
                else if (temp < pR)
                {
                    getChara(rare, i);
                }
                else if (temp < pSR)
                {
                    getChara(superRare, i);
                }
                else if (temp < pU)
                {
                    getChara(unique, i);
                }
                else
                {
                    getChara(epic, i);
                }
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
