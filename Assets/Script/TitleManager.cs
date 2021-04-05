using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Title
{
    public int key;
    [Header("전용칭호 여부")]
    public bool personalTitle = false;
    public Sprite titleImg;
    public string Name;
    [TextArea]
    public string Content;
}
public class TitleManager : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public List<Title> titles;

    public GameObject contents;
    public GameObject lineObj;
    public GameObject item;

    void Start()
    {
        titles = mainSystem.Titles;
        for(int i = 0; i < mainSystem.Titles.Count; i++)
        {
            if(i % 5 == 0)
            {
                lineObj = Instantiate(Resources.Load("Character/LineObj") as GameObject);
                lineObj.transform.SetParent(contents.transform);
            }
            item = Instantiate(Resources.Load("Character/Title") as GameObject);
            item.GetComponent<TitlePopupButton>().key = titles[i].key;
            item.GetComponent<TitlePopupButton>().personalTitle = titles[i].personalTitle;
            item.GetComponent<TitlePopupButton>().titleImg.sprite = titles[i].titleImg;
            item.GetComponent<TitlePopupButton>().Name.text = titles[i].Name;
            item.GetComponent<TitlePopupButton>().Content = titles[i].Content;
            item.transform.SetParent(lineObj.transform);
        }
    }
}
