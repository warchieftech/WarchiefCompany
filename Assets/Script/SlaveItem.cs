using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlaveItem : MonoBehaviour
{
    public Text title;
    public Text name;
    public Image img;
    public string key;

    public void Updater(string sTitle, string sName, string sImg)
    {
        title.text = sTitle;
        name.text = sName;
        img.sprite = Resources.Load<Sprite>("Character/img/" + sImg);
        this.key = sImg;
    }
}
