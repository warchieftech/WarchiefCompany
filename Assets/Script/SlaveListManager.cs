using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlaveListManager : MonoBehaviour
{
    public GameObject SlavesList;
    public GameObject SlaveItemList;
    public GameObject ItemTransform;
    private GameObject slaveItemBody;
    public MainMoneySystem mainSystem;
    private GameObject slaveImg;
    private GameObject slaveList;
    private GameObject slaveItemImg;
    private Vector2 vec2;
    private void Awake()
    {
        vec2 = SlavesList.transform.position;
        vec2 = SlaveItemList.transform.position;
        mainSystem = GameObject.FindWithTag("GameController").GetComponent<MainMoneySystem>();
    }
    private void Start()
    {
        //SlavesList = transform.GetChild(0).gameObject;
    }
    public void UpdateList(List<Slave> slaves)
    {
        if (SlavesList.transform.childCount != 0)
        {
            Destroy(SlavesList);
            slaveList = Instantiate(Resources.Load("character/Contents") as GameObject);
            slaveList.transform.SetParent(transform);
            SlavesList = slaveList;

            Destroy(slaveItemBody);
            slaveItemBody = Instantiate(Resources.Load("character/ItemContents") as GameObject);
            slaveItemBody.transform.SetParent(ItemTransform.transform);
            SlaveItemList = slaveItemBody;

            SlavesList.transform.position = vec2;
            SlaveItemList.transform.position = vec2;
        }

        for (int i = 0; i < mainSystem.maxSlaves; i++)
        {
            if(i < slaves.Count)
            {
                slaveImg = Instantiate(Resources.Load("character/SlaveItem") as GameObject);
                slaveItemImg = Instantiate(Resources.Load("character/SlaveItemBox") as GameObject);
                slaveImg.GetComponent<SlaveItem>().Updater(slaves[i].title, slaves[i].name, slaves[i].key);
                slaveItemImg.GetComponent<SlaveItem>().Updater(slaves[i].title, slaves[i].name, slaves[i].key);
                slaveImg.transform.SetParent(SlavesList.transform);
                slaveItemImg.transform.SetParent(SlaveItemList.transform);
            }
            else
            {
                slaveImg = Instantiate(Resources.Load("character/EmptyItem") as GameObject);
                slaveImg.transform.SetParent(SlavesList.transform);
            }
        }
        transform.GetComponent<ScrollRect>().content = SlavesList.GetComponent<RectTransform>();
        ItemTransform.transform.GetComponent<ScrollRect>().content = SlaveItemList.GetComponent<RectTransform>();
    }
}
