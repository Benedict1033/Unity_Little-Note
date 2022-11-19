using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class values : MonoBehaviour
{
    public PolygonCollider2D poly;
    PolygonCollider2D my;

    public GameObject sca;


    void Update()
    {

       
            myDis();
        
    }

    // Update is called once per frame
    void myDis()
    {
        poly = GameObject.Find("Square").GetComponent<PolygonCollider2D>();
        my = gameObject.GetComponent<PolygonCollider2D>();
        if (poly != null)
        {
        


            my.points = poly.points;

            if (my.shapeCount>0)
            {
                this.transform.localScale = new Vector2(65, 65);

            }
            //if (get = false)
            //{
            //    sca.transform.localScale = new Vector2(90, 90);
            //}
        }

    }
}
