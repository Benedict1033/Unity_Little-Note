using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest3left : MonoBehaviour
{
    public  double xPos;
    public  double yPos;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, 1000);
        if (hitInfo.collider != null)
        {

            xPos = Math.Round(hitInfo.point.x, 2, MidpointRounding.AwayFromZero);
            yPos = Math.Round(hitInfo.point.y, 2, MidpointRounding.AwayFromZero);

            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            //Debug.Log("left " + xPos + "," + yPos);

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * 100, Color.green);
        }
    }
}
