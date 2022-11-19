using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;

    //public GameObject default_Img;

    public GameObject []imageShow;
    
    void Start()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 35 + startPos.x, startPos.y - (i / 7) * 40, startPos.z);

            _dateItems.Add(item);



        }



        _dateTime = DateTime.Now;

        CreateCalendar();

        _calendarPanel.SetActive(false);

        ShowCalendar();
    }

    private void Update()
    {
        try
        {
            if (_monthNumText.text.ToString() == "1")
            {
                GameObject.Find("Item" + 26).transform.GetChild(1).gameObject.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
                GameObject.Find("Item" + 26).transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {

                GameObject.Find("Item" + 26).transform.GetChild(1).gameObject.GetComponent<Text>().color = new Color32(50, 50, 50, 255);
                GameObject.Find("Item" + 26).transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        catch { }

        CreateCalendar();
    }


    void CreateCalendar()
    {
        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {


            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);


            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();

                    if (_monthNumText.text == PlayerPrefs.GetInt("month").ToString())
                    {

                        if (label.text == PlayerPrefs.GetInt("day").ToString())
                        {

                            label.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                            Debug.Log("why");
                        }
                        else
                        {

                            label.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                        }

                    }
                    else {

                        label.gameObject.transform.GetChild(0).gameObject.SetActive(false);

                    }
                    date++;
                }
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();
        _monthNumText.text = _dateTime.Month.ToString();
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }

    public void ShowCalendar()
    {

        _calendarPanel.SetActive(true);

        //_calendarPanel.transform.position = Input.mousePosition-new Vector3(0,120,0);
    }

    public Text _target;
    public void OnDateItemClick(string day)
    {
        _target.text = _yearNumText.text + "年" + _monthNumText.text + "月" + day + "日";
        //_calendarPanel.SetActive(false);


        if (_monthNumText.text == PlayerPrefs.GetInt("month").ToString())
        {
            if (day == PlayerPrefs.GetInt("day").ToString())
            {


                if (PlayerPrefs.GetInt("state") == 1)
                {
                    imageShow[0].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("state") == 2)
                {
                    imageShow[1].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("state") == 3)
                {
                    imageShow[2].SetActive(true);
                }

                else if (PlayerPrefs.GetInt("state") == 4)
                {
                    imageShow[3].SetActive(true);
                }

                else if (PlayerPrefs.GetInt("state") == 5)
                {
                    imageShow[4].SetActive(true);
                }
                else if (PlayerPrefs.GetInt("state") == 6)
                {
                    imageShow[5].SetActive(true);
                }

            }
        }
        else { 
        
        
        }
    }
}
