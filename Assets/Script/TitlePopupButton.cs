using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePopupButton : MonoBehaviour
{
    public int key;
    public bool personalTitle;
    public Image titleImg;
    public Text Name;
    [TextArea]
    public string Content;

    public int slaveKey;
    private TitlePopupObj popup;
    private MainMoneySystem mainSystem;
    private void Awake()
    {
        popup = GameObject.FindWithTag("TitlePopup").GetComponent<TitlePopupObj>();
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    public void OnPopup()
    {
        slaveKey = popup.slavePos;
        popup.titleKey = this.key;
        popup.personalTitle = this.personalTitle;
        popup.Img.sprite = this.titleImg.sprite;
        popup.Name.text = this.Name.text;
        popup.Content.text = this.Content;
        popup.GetComponent<Canvas>().enabled = true;
    }
}
