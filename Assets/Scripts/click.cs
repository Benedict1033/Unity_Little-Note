using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{

    public GameObject[] khsa;

    public GameObject defaultImage;

    public void clickMe() {
        for (int i = 0; i < khsa.Length; i++)
        {
            if (khsa[i].transform.childCount != 3)
            {
                khsa[i].transform.GetChild(2).gameObject.SetActive(false);
            }
            else { 
            khsa[i].transform.GetChild(1).gameObject.SetActive(false);

            }



        }

        transform.GetChild(1).gameObject.SetActive(true);

        

        if (transform.GetChild(2).gameObject.GetComponent<Image>().color == new Color(255, 255, 224, 255)) {
            defaultImage.SetActive(true);
            Invoke("hi", 0.3f);
        }

        //PlayerPrefs.GetInt("day");

    }

    void hi() {

        defaultImage.SetActive(true);
    }
}
