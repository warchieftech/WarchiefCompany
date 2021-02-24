using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePopupButton : MonoBehaviour
{
    public int key;
    public Image titleImg;
    public string Name;
    [TextArea]
    public string Content;

    public string slaveKey;
    private TitlePopupObj popup;
    private MainMoneySystem mainSystem;
    private void Awake()
    {
        popup = GameObject.FindWithTag("TitlePopup").GetComponent<TitlePopupObj>();
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    public void OnPopup()
    {
        slaveKey = popup.slaveKey;
        popup.titleKey = this.key;
        popup.Img.sprite = this.titleImg.sprite;
        popup.Name.text = this.Name;
        popup.Content.text = this.Content;
        popup.GetComponent<Canvas>().enabled = true;
    }
}
