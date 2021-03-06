﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float cameraSpeedMovement = 50f;

    bool needMovingToGameOver = false;
    bool needMovingToVictory = false;
    bool needMovingToGameFromGameOver = false;
    //9  x
    //          начальное положение камеры
    //7   y

    // Update is called once per frame
    void Update()
    {
        if (needMovingToGameOver)
            moveToGameOver();
        else
        if (needMovingToGameFromGameOver)
            moveToGameFromGameOver();
        else
        if (needMovingToVictory)
            moveToVictory();

    }

    public void moveToGameOver()
    {
        if (transform.position.x > -62)
        {
            needMovingToGameOver = true;
            transform.position += new Vector3(-cameraSpeedMovement * Time.deltaTime, 0);
            if (transform.position.x < -62)
                transform.position = new Vector3(-62, 7, transform.position.z);
        }
        else needMovingToGameOver = false;
    }

    public void moveToGameFromGameOver()
    {
        if (transform.position.x < 9)
        {    
            needMovingToGameFromGameOver = true;
            transform.position += new Vector3(cameraSpeedMovement * Time.deltaTime, 0);
            if (transform.position.x > 9)
                transform.position = new Vector3(9, 7, transform.position.z);
        } 
        else needMovingToGameFromGameOver = false;
    }

   public void moveToVictory()
   {
        if (transform.position.x < 100)
        {
            needMovingToVictory = true;
            transform.position += new Vector3(cameraSpeedMovement * Time.deltaTime, 0);
            if (transform.position.x > 100)
                transform.position = new Vector3(100, 7, transform.position.z);
        }
        else needMovingToVictory = false;
   }


}
