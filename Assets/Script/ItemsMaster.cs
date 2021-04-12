using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    [Header("true : 선택형 / false : 즉시사용")]
    public bool type;
    [Header("true : 상점 미등록 / false : 상점등록")]
    public bool shopCheck;
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
    public GameObject usingPopup;
    public MainMoneySystem mainSystem;
    public ItemBoxManager itemBoxManager;
    public List<Item> items;
    private int selectId;
    private int useId;
    public Slave slave;

    private void Start()
    {
        items = mainSystem.Items;
    }
    public void GetItem()
    {
        if (mainSystem.GetItem((int) items[selectId].price))
        {
            mainSystem.RemoveMoney((int)items[selectId].price);
            items[selectId].cnt++;
            mainSystem.maxSlaves = mainSystem.Items[0].cnt;
            mainSystem.UpdateSlave();
            BuyingPopup.SetActive(false);
            mainSystem.ErrorPopup("구매에 성공했습니다.");
        }
        else
        {
            BuyingPopup.SetActive(false);
            mainSystem.ErrorPopup("잔액이 부족합니다.");
        }
    }
    public void UseItem(int id)
    {
        useId = id;
        if(mainSystem.Items[id].cnt > 0)
        {
            if (mainSystem.Items[id].type)
            {
                usingPopup.GetComponent<Canvas>().enabled = true;
            }
            else
            {
                items[id].cnt--;
                UseItem();
                itemBoxManager.UpdateAll();
            }
        }
        else
        {
            mainSystem.ErrorPopup("아이템의 갯수가 부족합니다.");
        }
    }
    public void SelectSlave(int key)
    {
        items[useId].cnt--;
        this.slave = mainSystem.Slaves[key];
        UseItem();
        itemBoxManager.UpdateAll();
        usingPopup.GetComponent<Canvas>().enabled = false;
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

    public void UseItem()
    {
        switch (useId)
        {
            case 0:

                break;
            case 1:
                slave.health += 15;
                break;
            case 2:
                slave.stressBase -= 5;
                break;
            case 3:

                break;
        }
    }
}
