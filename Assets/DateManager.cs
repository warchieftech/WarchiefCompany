using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;

public class DateManager : MonoBehaviour
{
    public Text dateText;

    public int year;
    public int month;
    public int day;
    public int week = 0;
    public bool workDay;    //true = 평일 / false = 휴일

    private DateTime dateTime;
    private CultureInfo cultures;
    private string date;

    void Start()
    {
        cultures = CultureInfo.CreateSpecificCulture("ko-KR");
        StartCoroutine(DateSystem());
    }

    IEnumerator DateSystem()
    {
        while (true)
        {
            DateUpdate();
            yield return  new WaitForSeconds(5);
            day++;
        }
    }
    public void DateUpdate()
    {
        dateTime = new DateTime(year, month, day);
        date = dateTime.ToString(string.Format("yyyy년 MM월 dd일\nddd요일", cultures));
        dateText.text = date;
    }
}
