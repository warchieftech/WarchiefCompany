using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlavePopupOpener : MonoBehaviour
{
    public SlavePopupManager popupManager;
    public Canvas popup;
    private string key;
    void Start()
    {
        popupManager = GameObject.FindWithTag("SlavePopup").GetComponent<SlavePopupManager>();
        popup = GameObject.FindWithTag("SlavePopup").GetComponent<Canvas>();
        key = transform.gameObject.GetComponent<SlaveItem>().key;
    }

    public void OpenPopup()
    {
        popupManager.SlaveSetting(key);
        popup.enabled = true;
    }
}
