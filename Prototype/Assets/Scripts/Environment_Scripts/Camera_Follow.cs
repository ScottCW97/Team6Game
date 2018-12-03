﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour 
{
    //What we are following
    public Transform target;

    Vector3 velocity = Vector3.zero;

    //Time to follow target
    public float smoothTime = .15f;

    //Enable and set the maximum Y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //Enable and set the minimum Y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //Enable and set the maximum X value
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //Enable and set the minimum X value
    public bool XMinEnabled = false;
    public float XMinValue = 0;

   private GameObject[] enemy_list;


private void FixedUpdate()
    {
        //target position
        Vector3 targetPos = target.position;


        //Vertical
        if(YMinEnabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        }

        else if(YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        }

        else if(YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        }



        //Horizontal

        if (XMinEnabled && XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        }

        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        }

        else if (XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);
        }





        //align the camera and the target's z position
        targetPos.z = transform.position.z;


        enemy_list = GameObject.FindGameObjectsWithTag("Enemy");


        if(enemy_list.Length == 0)
        {
            //Using smooth damp we will gradually change the camera transform position to the target position based on the cameras transform velocity and our smooth time
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }
        else
        {
            transform.position = transform.position;
        }



    }
}
