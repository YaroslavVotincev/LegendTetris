using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public float cameraSpeedMovement = 50f;

    bool needMovingToGameOver = false;

    bool needMovingToGame = false;

    //10.03  x
    //          начальное положение камеры
    //11.5   y


    void Start()
    {
        /*
        print(Screen.width);
        print(Screen.height);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (needMovingToGameOver)
            moveToGameOver();

        if (needMovingToGame)
            moveToGame();

    }

    public void moveToGameOver()
    {
        if (transform.position.x > -62)
        {
            needMovingToGameOver = true;
            transform.position += new Vector3(-cameraSpeedMovement * Time.deltaTime, 0);
        }
        else needMovingToGameOver = false;
    }

    public void moveToGame()
    {
        if (transform.position.x < 9.03)
        {    
            needMovingToGame = true;

            transform.position += new Vector3(cameraSpeedMovement * Time.deltaTime, 0);  
        }
        else if (transform.position.x >= 11.03)
        {  
            needMovingToGame = true;

            transform.position += new Vector3( -cameraSpeedMovement * Time.deltaTime, 0);
        }
        else needMovingToGame = false;
    }

}
