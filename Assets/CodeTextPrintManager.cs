using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeTextPrintManager : MonoBehaviour
{
    public List<GameObject> texts;

    private int cnt;
    private GameObject buff;
    int cCnt;
    private void Start()
    {
        cnt = 0;
        cCnt = transform.childCount;
        for(int i = 0; i < cCnt; i++)
        {
            texts.Add(Instantiate(transform.GetChild(i).gameObject));
        }
    }

    public void InnerText()
    {
        /*if(transform.childCount < 12)
        {
            texts[cnt].transform.SetParent(transform);
            cnt++;
        }
        else
        {*/
        texts[0].transform.GetComponent<Text>().enabled = true;
        texts[0].transform.SetParent(transform);
        Destroy(transform.GetChild(0).gameObject);
        texts.Add(Instantiate(transform.GetChild(0).gameObject));
        texts.RemoveRange(0, 1);
            cnt++;
        //}
        if (cnt == cCnt) cnt = 0;
    }
    public void ResetCnt()
    {
        cnt = 0;
    }
}
