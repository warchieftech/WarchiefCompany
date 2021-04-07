using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;

public class DateManager : MonoBehaviour
{
    public Text dateText;
    public Text weekText;

    public int year;
    public int month;
    public int day;
    public int week = 0;
    public bool workDay;    //true = 평일 / false = 휴일

    private Coroutine dateSystem;
    private DateTime dateTime;
    private CultureInfo cultures;
    private string date;

    void Start()
    {
        cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        dateSystem = StartCoroutine(DateSystem());
    }
    public void RestartDate()
    {
        StartCoroutine(DateSystem());
    }
    public void PauseDate()
    {
        StopCoroutine(dateSystem);
    }
    IEnumerator DateSystem()
    {
        while (true)
        {
            DateUpdate();
            yield return  new WaitForSeconds(5);
            day++;
            week++;
        }
    }
    public void DateUpdate()
    {
        if(day > 12)
        {
            if(month > 12)
            {
                month = 1;
                day = 1;
                year++;
            }
            else
            {
                month++;
                day = 1;
            }
        }
        switch (week)
        {
            case 0:
                date = "일요일";
                workDay = false;
                break;
            case 1:
                date = "월요일";
                workDay = true;
                break;
            case 2:
                date = "화요일";
                break;
            case 3:
                date = "수요일";
                break;
            case 4:
                date = "목요일";
                break;
            case 5:
                date = "금요일";
                break;
            case 6:
                date = "토요일";
                workDay = false;
                break;
            case 7:
                date = "일요일";
                week = 0;
                workDay = false;
                break;
        }
        dateText.text = year + "년 " + month + "월 " + day + "일";
        weekText.text = date;
    }
}
