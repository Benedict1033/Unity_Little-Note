using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{
    public GameObject [] anim;
    bool Play_Stop;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopAnim() {

        Play_Stop = !Play_Stop;


        
        for (int i = 0; i < anim.Length; i++) {

            if (Play_Stop)
            {
                anim[i].gameObject.GetComponent<Animator>().enabled = false;
                panel.SetActive(true);
            }
            else {

                anim[i].gameObject.GetComponent<Animator>().enabled = true;
                panel.SetActive(false);

            }
        }
    }
}
