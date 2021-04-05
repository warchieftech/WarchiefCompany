using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemBox : MonoBehaviour
{
    public Text nameText;
    public Text commentText;
    public Text priceText;
    public Image imgObj;

    public string name;
    public string comment;
    public double price;
    public Sprite img;

    public void UpdateItem()
    {
        nameText.text = name;
        commentText.text = comment;
        priceText.text = price.ToString();
        imgObj.sprite = img;
    }
}
