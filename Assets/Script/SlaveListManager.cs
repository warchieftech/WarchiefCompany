using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlaveListManager : MonoBehaviour
{
    public GameObject SlavesList;
    public MainMoneySystem mainSystem;
    private GameObject slaveImg;
    private GameObject slaveList;
    private Vector2 vec2;
    private void Awake()
    {
        vec2 = SlavesList.transform.position;
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
            slaveList.GetComponent<RectTransform>().sizeDelta = new Vector2(1080, 200 * mainSystem.maxSlaves);
            slaveList.transform.SetParent(transform);
            SlavesList = slaveList;
            SlavesList.transform.position = vec2;
        }

        for (int i = 0; i < mainSystem.maxSlaves; i++)
        {
            if(i < slaves.Count)
            {
                slaveImg = Instantiate(Resources.Load("character/SlaveItem") as GameObject);
                slaveImg.GetComponent<SlaveItem>().Updater(slaves[i].title, slaves[i].name, slaves[i].key);
                slaveImg.transform.SetParent(SlavesList.transform);
            }
            else
            {
                slaveImg = Instantiate(Resources.Load("character/EmptyItem") as GameObject);
                slaveImg.transform.SetParent(SlavesList.transform);
            }
        }
        transform.GetComponent<ScrollRect>().content = SlavesList.GetComponent<RectTransform>();
    }
}
