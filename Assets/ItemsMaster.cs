using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public int id;
    public int cnt;
    public string name;
    [TextArea]
    public string comment;
    public double price;
    public Sprite img;
}
public class ItemsMaster : MonoBehaviour
{
    public GameObject ItemBox;
    public GameObject BuyingPopup;
    public MainMoneySystem mainSystem;
    public ItemBoxManager itemBoxManager;
    public List<Item> items;
    private int selectId;

    private void Start()
    {
        items = mainSystem.Items;
    }
    public void GetItem()
    {
        mainSystem.RemoveMoney((int) items[selectId].price);
        items[selectId].cnt++;
        BuyingPopup.SetActive(false);
    }
    public void UseItem(int id)
    {
        if(mainSystem.Items[id].cnt > 0)
        {
            items[id].cnt--;
            itemBoxManager.UpdateAll();
        }
        else
        {
            mainSystem.ErrorPopup("아이템의 갯수가 부족합니다.");
        }
    }
    public void BuyingItem()
    {
        BuyingPopup.SetActive(true);
        BuyingPopup.transform.GetChild(0).GetComponent<Text>().text = items[selectId].name + "을(를) 구입하시겠습니까?";
    }
    public void SetId(int x)
    {
        selectId = x;
    }
}
