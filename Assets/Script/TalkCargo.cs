using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TalkData
{
    public bool eventCheck;
    public bool endCheck;
    public int eventId;
    public bool eventLine;
    public Sprite img;
    public string name;
    [TextArea]
    public string talk;
}
[System.Serializable]
public class Talks
{
    public List<TalkData> talks;
}
public class TalkCargo : MonoBehaviour
{
    public MainMoneySystem mainMoneySystem;
    public EventManager eventManager;

    public Image img;
    public Text name;
    public Text talk;

    public Sprite slaveImg;
    public string slaveName;

    private int slaveCnt;
    private int i;
    private string t;
    private int id;

    public List<Talks> talkDatas;

    public Canvas popup;
    public GameObject normalBtn;
    public GameObject eventBtn;

    public void ConverText(int id)
    {
        i = 0;
        StartCoroutine(InnerText(id));
    }
    public void ConverText(int id, int cnt)
    {
        i = cnt;
        StartCoroutine(InnerText(id));
    }
    public void ConverEvnetText(int id)
    {
        i = 0;
        //StartCoroutine(InnerEventText(id, this.slaveCnt));
        StartCoroutine(InnerEventText(id, 0));
    }
    public void ConverEventText(int id, int cnt)
    {
        i = cnt;
        //StartCoroutine(InnerEventText(id, this.slaveCnt));
        StartCoroutine(InnerEventText(id, 0));
    }
    public void Restart(bool branch)
    {
        if (branch)
        {
            i++;
            ConverText(this.id, i);
        }
        else
        {
            ConverText(this.id, i);
        }
    }
    public void RestartEvent(bool branch)
    {
        if (branch)
        {
            i++;
            ConverEventText(this.id, i);
        }
        else
        {
            ConverEventText(this.id, i);
        }
    }
    public void OpenNoBtn()
    {
        popup.enabled = true;
        eventBtn.SetActive(false);
        normalBtn.SetActive(true);
    }
    public void OpenEvBtn()
    {
        popup.enabled = true;
        normalBtn.SetActive(false);
        eventBtn.SetActive(true);
    }
    public IEnumerator InnerText(int id)
    {
        while (true)
        {
            t = "";
            img.sprite = talkDatas[id].talks[i].img;
            name.text = talkDatas[id].talks[i].name;
            char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
            for(int j = 0; j < charArr.Length; j++)
            {
                yield return new WaitForSeconds(0.1f);
                t += charArr[j];
                talk.text = t;
            }
            if (talkDatas[id].talks[i].eventCheck)
            {
                this.id = id;
                this.i = i + 1;
                OpenNoBtn();
                break;
            }
            yield return new WaitForSeconds(2);
            if (talkDatas[id].talks[i].endCheck)
            {
                EventPlay(id, talkDatas[id].talks[i].eventLine);
                break;
            }
            i++;
            if (i == talkDatas[id].talks.Count) break;
        }
    }
    public IEnumerator InnerEventText(int id, int slaveCnt)
    {
        this.slaveCnt = slaveCnt;
        while (true)
        {
            t = "";

            if (talkDatas[id].talks[i].name == "")
            {
                img.sprite = Resources.Load<Sprite>("Character/img/" + mainMoneySystem.Slaves[slaveCnt].key);
                name.text = mainMoneySystem.Slaves[slaveCnt].name;
                char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
                for (int j = 0; j < charArr.Length; j++)
                {
                    yield return new WaitForSeconds(0.1f);
                    t += charArr[j];
                    talk.text = t;
                }
            }
            else
            {
                img.sprite = talkDatas[id].talks[i].img;
                name.text = talkDatas[id].talks[i].name;
                char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
                for (int j = 0; j < charArr.Length; j++)
                {
                    yield return new WaitForSeconds(0.1f);
                    t += charArr[j];
                    talk.text = t;
                }
            }
            if (talkDatas[id].talks[i].eventCheck)
            {
                this.id = id;
                this.i = i + 1;
                OpenEvBtn();
                break;
            }
            yield return new WaitForSeconds(2);
            if (talkDatas[id].talks[i].endCheck)
            {
                EventPlay(id, talkDatas[id].talks[i].eventLine ,slaveCnt);
                break;
            }
            i++;
            if (i == talkDatas[id].talks.Count) break;
        }
    }
    public void EventPlay(int id, bool check)
    {
        eventManager.EventPlayer(id, check);
    }
    public void EventPlay(int id, bool check, int slaveCnt)
    {
        eventManager.EventPlayer(id, check, slaveCnt);
    }
}
