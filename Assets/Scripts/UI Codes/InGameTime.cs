using TMPro;
using UnityEngine;

public class InGameTime : MonoBehaviour
{
    public TextMeshProUGUI[] UITimeText;
    public TextMeshProUGUI[] UIDateText;
    public TextMeshProUGUI[] BorchText;
    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.DD_MM_YYYY;
    public Resources resources;
//Oyun içi bir dakika reelde bir saniyeye eşit
    public float secPerMin = 1;

    private string _time;
    private string _date;
    private string _borch;
    private bool isAm = false;
//Saat 
    int hr;
    int min;
//Tarih
    int day;
    int month;
    int year;
//Max, min
    int maxHr = 24;
    int maxMin = 60;
    int maxDay = 30;
    int maxMonth = 12;
//Borch
    int daysUntilBorch;
    public int newBorchDay = 7;
    public int BorchAmount;
    float timer = 0;

    public enum TimeFormat
    {
        Hour_24,
        Hour_12
    }
    public enum DateFormat
    {
        DD_MM_YYYY,
        MM_DD_YYYY,
        YYYY_MM_DD,
        YYYY_DD_MM
    }

    private void Awake()
    {
        hr    = 0;
        min   = 0;
        day   = 1;
        month = 1;
        year  = 1984;
        daysUntilBorch = 1; _borch = daysUntilBorch + "";

        if(hr < 12)
        isAm = true;
    }

    void Update()
    {
        if(timer >=secPerMin)
        {
            min++;
            if(min >=maxMin)
            {
                min = 0;
                hr++;
                if(hr >= maxHr)
                {
                    hr = 0;
                    day++;
                    daysUntilBorch--;
                    _borch = daysUntilBorch + "";
                    if(day >= maxDay)
                    {
                        day = 1;
                        month++;
                        if(month >= maxMonth)
                        {
                            month = 1;
                            year++;
                        }
                    }
                }
            }

            SetTimeDateString();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (daysUntilBorch <= 0)
        {
            resources.goins -= BorchAmount;
            resources.TotalBorch -= BorchAmount;
            daysUntilBorch = newBorchDay;
            _borch = daysUntilBorch + "";
        }
    }

    void SetTimeDateString()
    {
        switch(timeFormat)
        {
            case TimeFormat.Hour_24:
            {
                if(hr <= 9)
                {
                    _time = "0" + hr + ":";
                }
                else
                {
                    _time = hr + ":";
                }

                if(min <= 9)
                {
                    _time += "0" + min;
                }
                else
                {
                    _time += min;
                }

                break;
            }
            case TimeFormat.Hour_12:
            {
                int h;
                if(hr >= 13)
                {
                    h = hr - 12;
                }
                else if(hr == 0)
                {
                    h = 12;
                }
                else
                {
                    h = hr;
                }
                
                _time = h +":";

                if(min <= 9)
                {
                    _time += "0" + min;
                }
                else
                {
                    _time += min;
                }

                if(isAm)
                {
                    _time += " AM";
                }
                else
                {
                    _time += " PM";
                }

                break;
            }
        }
        switch(dateFormat)
        {
            case DateFormat.DD_MM_YYYY:
            {
                _date = day + "/" + month + "/" + year;
                break;
            }
            case DateFormat.MM_DD_YYYY:
            {
                _date = month + "/" + day + "/" + year;
                break;
            }
            case DateFormat.YYYY_MM_DD:
            {
                _date = year + "/" + month + "/" + day;
                break;
            }
            case DateFormat.YYYY_DD_MM:
            {
                _date = year + "/" + day + "/" + month;
                break;
            }
        }

        for(int i = 0; i < UITimeText.Length; i++)
        {
            UITimeText[i].text = _time;
        }
        for(int i = 0; i < UIDateText.Length; i++)
        {
            UIDateText[i].text = _date;
        }

        for(int i = 0; i < BorchText.Length; i++)
        {
            BorchText[i].text = _borch;
        }
    }
}
