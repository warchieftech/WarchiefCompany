using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxManager : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public GameObject itemBox;
    public ItemsMaster master;

    void Start()
    {
        master = GameObject.FindWithTag("ItemsMaster").GetComponent<ItemsMaster>();
        ItemSetting();
    }

    public void ItemSetting()
    {
        for(int i = 0; i < mainSystem.Items.Count; i++)
        {
            itemBox = Instantiate(Resources.Load("ItemBox") as GameObject);
            itemBox.GetComponent<ItemBox>().name = mainSystem.Items[i].name;
            itemBox.GetComponent<ItemBox>().comment = mainSystem.Items[i].comment;
            itemBox.GetComponent<ItemBox>().price = mainSystem.Items[i].price;
            itemBox.GetComponent<ItemBox>().img = mainSystem.Items[i].img;
            int temp = i;
            itemBox.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.SetId(mainSystem.Items[temp].id); });
            itemBox.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { master.BuyingItem(); });
            itemBox.GetComponent<ItemBox>().UpdateItem();
            itemBox.transform.SetParent(transform);

        }
    }
}
