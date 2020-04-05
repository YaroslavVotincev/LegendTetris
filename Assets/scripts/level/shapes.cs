using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapes : MonoBehaviour
{
    float falldown = 0f, fall=0f;

    public static float fallspeed = 1f;

    public int upmoves = 2;

    public static bool isStopped = false;

    public Vector3 rotationPoint;

    public GameObject thisShadowShape, currentShadow;
    




    // Start is called before the first frame update
    void Start()
    {

        shadowInst();

    }







    // Update is called once per frame
    void Update()
    {

        if (isStopped == false)
        {

            CheckUserInput();

        }

    }







    void CheckUserInput()
    {

        if ((Input.GetKeyDown(KeyCode.RightArrow) || controlButtons.right) && Time.time - fall >= 0.15f)
        {

            fall = Time.time;

            if (isValidPosition(1, 0))
            {

                transform.position += new Vector3(1, 0, 0);

                shadowMove();

            }

            controlButtons.right = false;

        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || controlButtons.left) && Time.time - fall >= 0.15f)
        {
            fall = Time.time;

            if (isValidPosition(-1, 0))
            {

                transform.position += new Vector3(-1, 0, 0);

                shadowMove();

            }

            controlButtons.left = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) || rotationButton.doRotation)
        {

            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);

            if (isValidPosition(0, 0) == false)
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);

            else
                shadowMove();

            rotationButton.doRotation = false;

        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || controlButtons.up) && upmoves > 0 && Time.time - fall >= 1f)
        {

            fall = Time.time;

            if (isValidPosition(0, 1))
            {

                transform.position += new Vector3(0, 1, 0);

                upmoves--;

            }

            controlButtons.up = false;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - falldown >= fallspeed || (controlButtons.down && Time.time - falldown >= 0.1f))
        {

            falldown = Time.time;

            if (isValidPosition(0, -1))
                transform.position += new Vector3(0, -1, 0);

            else
            {

                isStopped = true;

                Destroy(currentShadow);

            }

            controlButtons.down = false;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            while (isValidPosition(0, -1))
                transform.position += new Vector3(0, -1, 0);

            isStopped = true;

            Destroy(currentShadow);

        }


        if (Input.GetKeyUp(KeyCode.Q))
        {

            isStopped = true;

            Destroy(currentShadow);

        }

    }





    bool isValidPosition(int x1, int y1)
    {

        foreach (Transform cube in transform)
        {

            int x = Mathf.RoundToInt(cube.transform.position.x) + x1;

            int y = Mathf.RoundToInt(cube.transform.position.y) + y1;

            if (x <= 0f || x >= 11f || y <= 0f)
                return false;

            if (game.pole[y, x] == 1)
                return false;

        }

        return true;

    }





    void shadowInst()
    {

        currentShadow = Instantiate(thisShadowShape,transform.position, Quaternion.identity) as GameObject;

        foreach (Transform cube in currentShadow.transform)
        {

            cube.GetComponent<SpriteRenderer>().sortingOrder = -1;

        }

    }





    void shadowMove()
    {

        currentShadow.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        currentShadow.transform.rotation = transform.rotation;

    }

}
