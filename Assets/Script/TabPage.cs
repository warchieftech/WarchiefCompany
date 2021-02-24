using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabPage : MonoBehaviour
{
    public List<GameObject> page;

    public void OpenPage(int num)
    {
        for(int i = 0; i < page.Count; i++)
        {
            if(i == num)
            {
                if (page[i].GetComponent<Canvas>().enabled)
                {
                    page[i].GetComponent<Canvas>().enabled = false;
                }
                else
                {
                    page[i].GetComponent<Canvas>().enabled = true;
                }
            }
            else
            {
                page[i].GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
