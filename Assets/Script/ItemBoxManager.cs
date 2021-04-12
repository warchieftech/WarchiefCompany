using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxManager : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public GameObject inventory;
    public GameObject itemBox;
    public GameObject itemCargo;
    public ItemsMaster master;

    void Start()
    {
        master = GameObject.FindWithTag("ItemsMaster").GetComponent<ItemsMaster>();
        ItemSetting();
    }
    public void UpdateAll()
    {
        for(int i = 0; i < mainSystem.Items.Count; i++)
        {
            inventory.transform.GetChild(i).GetComponent<ItemBox>().price = mainSystem.Items[i].cnt;
            inventory.transform.GetChild(i).GetComponent<ItemBox>().UpdateItem();
        }
    }
    public void ItemSetting()
    {
        for(int i = 0; i < mainSystem.Items.Count; i++)
        {
            int temp = i;
            if (!mainSystem.Items[i].shopCheck)
            {
                itemBox = Instantiate(Resources.Load("ItemBox") as GameObject);
                itemBox.GetComponent<ItemBox>().name = mainSystem.Items[i].name;
                itemBox.GetComponent<ItemBox>().comment = mainSystem.Items[i].comment;
                itemBox.GetComponent<ItemBox>().price = mainSystem.Items[i].price;
                itemBox.GetComponent<ItemBox>().img = mainSystem.Items[i].img;
                itemBox.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.SetId(mainSystem.Items[temp].id); });
                itemBox.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.BuyingItem(); });
                itemBox.GetComponent<ItemBox>().UpdateItem();
                itemBox.transform.SetParent(transform);
            }

            itemCargo = Instantiate(Resources.Load("ItemCargo") as GameObject);
            itemCargo.GetComponent<ItemBox>().name = mainSystem.Items[i].name;
            itemCargo.GetComponent<ItemBox>().comment = mainSystem.Items[i].comment;
            itemCargo.GetComponent<ItemBox>().price = mainSystem.Items[i].cnt;
            itemCargo.GetComponent<ItemBox>().img = mainSystem.Items[i].img;
            if(i != 0)
            {
                itemCargo.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.SetId(mainSystem.Items[temp].id); });
                itemCargo.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.UseItem(mainSystem.Items[temp].id); });
            }
            itemCargo.GetComponent<ItemBox>().UpdateItem();
            itemCargo.transform.SetParent(inventory.transform);

        }
    }
}
