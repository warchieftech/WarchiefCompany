using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEventsManager : MonoBehaviour
{
    public MainMoneySystem mainSystem;
    public TalkCargo talkSystem;
    public DateManager dateManager;

    public int year;
    public int month;
    public int day;

    public void RandomSlaveEvent(int talkId)
    {
        mainSystem.PauseSystem();
        int ran = Random.Range(0, mainSystem.Slaves.Count);
        talkSystem.SlaveSetting(ran);
        talkSystem.ConverEvnetText(talkId);
    }

}
