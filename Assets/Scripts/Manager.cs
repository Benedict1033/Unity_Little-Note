using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject abc; //today icon
    //public GameObject[] todayIcon;
    //int a;

    //public GameObject derf;

    //public GameObject eventIcon;

    //public GameObject[] eventday;


    void Start()
    {
        //PlayerPrefs.DeleteAll();



        //Debug.Log(PlayerPrefs.GetInt("state").ToString());


        //a = DateTime.Now.Day;

        //GameObject icon = Instantiate(abc, transform.position, transform.rotation);

        
        //icon.transform.SetParent(todayIcon[a - 1].transform);


        //RectTransform aaa= icon.transform as RectTransform;
        //aaa.anchoredPosition = new Vector2(0, 33);



        //Text ksdh = todayIcon[a-1].transform.GetChild(0).GetComponent<Text>();
    
        //ksdh.color = new Color(255,255,255,255);


        //RectTransform sajd = todayIcon[a - 1].transform.GetChild(0) as RectTransform;
        //sajd.SetAsLastSibling();


        //for (int r=0; r < todayIcon.Length; r++) { 
        
        //GameObject askldj= Instantiate(derf, transform.position, transform.rotation);
        //    askldj.transform.SetParent(todayIcon[r].transform);

        //    RectTransform bbb = askldj.transform as RectTransform;
        //    bbb.anchoredPosition = new Vector2(0, 33);

        //    bbb.gameObject.SetActive(false);



        //    GameObject sldh = Instantiate(eventIcon, transform.position, transform.rotation);
        //    sldh.transform.SetParent(todayIcon[r].transform);

        //    RectTransform cccc = sldh.transform as RectTransform;
        //    cccc.anchoredPosition = new Vector2(0, -27);

        //    cccc.gameObject.SetActive(false);

        //}



     
        //重要
        //todayIcon[PlayerPrefs.GetInt("day")].transform.GetChild(2).gameObject.SetActive(true);
        //todayIcon[PlayerPrefs.GetInt("day")].transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(255, 255, 224, 255);

     




    }

    
    void Update()
    {   
   
    }

    public void back() => SceneManager.LoadScene("Home");
}
