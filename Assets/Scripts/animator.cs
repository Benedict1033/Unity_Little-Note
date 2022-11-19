using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
    public Animator hand1;
    public Animator hand2;

    void Start()
    {
        hand1 = hand1.gameObject.GetComponent<Animator>();
        hand2 = hand2.gameObject.GetComponent<Animator>();
        
        hand1.SetBool("yes", false);
        hand2.SetBool("yes", false);


    }


    void Update()
    {
        
    }

    public void handone() {
        hand1.SetBool("yes", false);

    }

    public void handtwo() {
        hand2.SetBool("yes", false);

    } 
    public void handone2() {
        hand1.SetBool("yes", true);

    }

    public void handtwo2() {
        hand2.SetBool("yes", true);

    }

    public void handstop() {
        hand1.SetBool("yes", true);
        hand2.SetBool("yes", true);
    }

}
