using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashItemsMaster : MonoBehaviour
{
    public GameObject ItemBox;
    public GameObject BuyingPopup;
    public GameObject usingPopup;
    public MainMoneySystem mainSystem;
    public List<Item> items;
    private int selectId;
    private int useId;
    public Slave slave;

    private void Start()
    {
        items = mainSystem.Items;
    }
    public void GetItem(int selectId)
    {
        ItemEvent(selectId);
        mainSystem.maxSlaves = mainSystem.Items[0].cnt;
        mainSystem.UpdateSlave();
        BuyingPopup.SetActive(false);
        mainSystem.ErrorPopup("구매에 성공했습니다.");
    }
    public void FailGet(int selectId)
    {
        BuyingPopup.SetActive(false);
        mainSystem.ErrorPopup("결제에 실패했습니다.");
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

    public void ItemEvent(int useId)
    {
        switch (useId)
        {
            case 3:
                mainSystem.Items[useId].cnt += 10;
                break;
        }
    }
}
