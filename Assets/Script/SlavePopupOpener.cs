using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlavePopupOpener : MonoBehaviour
{
    public SlavePopupManager popupManager;
    public ItemsMaster itemsMaster;
    public Canvas popup;
    private string key;
    void Start()
    {
        popupManager = GameObject.FindWithTag("SlavePopup").GetComponent<SlavePopupManager>();
        popup = GameObject.FindWithTag("SlavePopup").GetComponent<Canvas>();
        itemsMaster = GameObject.FindWithTag("ItemsMaster").GetComponent<ItemsMaster>();
        key = transform.gameObject.GetComponent<SlaveItem>().key;
    }

    public void OpenPopup()
    {
        popupManager.pos = transform.GetSiblingIndex();
        popupManager.SlaveSetting(transform.GetSiblingIndex());
        popup.enabled = true;
    }
    public void SelectSlave()
    {
        itemsMaster.SelectSlave(transform.GetSiblingIndex());
    }
}
