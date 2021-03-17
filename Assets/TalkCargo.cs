using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TalkData
{
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
    public Image img;
    public Text name;
    public Text talk;

    public Sprite slaveImg;
    public string slaveName;

    private int i;
    private string t;
    public List<Talks> talkDatas;


    public IEnumerator InnerText(int id)
    {
        i = 0;
        while (true)
        {
            t = "";
            img.sprite = talkDatas[id].talks[i].img;
            name.text = talkDatas[id].talks[i].name;
            char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
            for(int i = 0; i < charArr.Length; i++)
            {
                yield return new WaitForSeconds(0.1f);
                t += charArr[i];
                talk.text = t;
            }
            yield return new WaitForSeconds(2);
            i++;
            if (i == talkDatas[id].talks.Count) break;
        }
    }
    public IEnumerator InnerEventText(int id)
    {
        i = 0;
        while (true)
        {
            t = "";

            if (talkDatas[id].talks[i].name == "")
            {
                img.sprite = slaveImg;
                name.text = slaveName;
                char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                    yield return new WaitForSeconds(0.1f);
                    t += charArr[i];
                    talk.text = t;
                }
            }
            else
            {
                img.sprite = talkDatas[id].talks[i].img;
                name.text = talkDatas[id].talks[i].name;
                char[] charArr = talkDatas[id].talks[i].talk.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                    yield return new WaitForSeconds(0.1f);
                    t += charArr[i];
                    talk.text = t;
                }
            }

            yield return new WaitForSeconds(2);
            i++;
            if (i == talkDatas[id].talks.Count) break;
        }
    }
}
