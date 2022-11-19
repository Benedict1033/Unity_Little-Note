using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public RayTest3top a = new RayTest3top();
    public RayTest3down b = new RayTest3down();
    public RayTest3left c = new RayTest3left();
    public RayTest3right d = new RayTest3right();

    public GameObject[] people;

    public GameObject why;


    public double dis;
    public double dis2;
    public float abcd;
    public float abcd2;
    public float y ;
    public float x;

    public Text dayText;
    public Text monthText;


    public static int howmany;


    void Start()
    {
        Invoke("whyyyyyyyyyyyyy", 1f);

        PlayerPrefs.SetInt("state", 1);
    }

    // Update is called once per frame
    void Update()
    {



       dis = (a.yPos - b.yPos) * (a.yPos - b.yPos);
       dis2 = (c.xPos - d.xPos) * (c.xPos - d.xPos);
       abcd = Mathf.Sqrt((float)dis);
       abcd2 = Mathf.Sqrt((float)dis2);
       y = abcd / 4;
       x = abcd2 / 4;



       
          
        


    }

    void whyyyyyyyyyyyyy() {
        //right hand
        people[0].transform.position = new Vector2((float)d.xPos, (float)d.yPos + y);
        //left hand
        people[1].transform.position = new Vector2((float)c.xPos, (float)c.yPos + y);
        //right leg
        people[2].transform.position = new Vector2((float)b.xPos + x, (float)b.yPos);
        //left leg
        people[3].transform.position = new Vector2((float)b.xPos - x, (float)b.yPos);
    }

    public void quitt() //confirm
    {
        int day = Int32.Parse(dayText.text);
        int month = Int32.Parse(monthText.text);


        if (dayText.text == "2021")
        {
            PlayerPrefs.SetInt("day", DateTime.Now.Day);
            PlayerPrefs.SetInt("month", DateTime.Now.Month);
            PlayerPrefs.SetInt("state", 1);
            Debug.Log(132);

        }
        else
        {
            PlayerPrefs.SetInt("day", day);
            PlayerPrefs.SetInt("month", month);
        }


        //PlayerPrefs.SetInt("state", 1);


        //if (PlayerPrefs.GetInt("day") ==day)
        //{
        //    howmany = 2;
        //    Debug.Log(123);
        //}






        Application.Quit();
    }

    public void back()
    {
        SceneManager.LoadScene("Home");
    }

    public void state1() {
       
        PlayerPrefs.SetInt("state", 1);
        Debug.Log(1);
    }
    public void state2()
    {
        PlayerPrefs.SetInt("state", 2);
        Debug.Log(2);

    }
    public void state3()
    {
        PlayerPrefs.SetInt("state", 3);
        Debug.Log(3);

    }
    public void state4()
    {
        PlayerPrefs.SetInt("state", 4);
        Debug.Log(4);

    }
    public void state5()
    {
        PlayerPrefs.SetInt("state", 5);
        Debug.Log(5);

    }
    public void state6()
    {
        PlayerPrefs.SetInt("state", 6);
        Debug.Log(6);

    }
}
