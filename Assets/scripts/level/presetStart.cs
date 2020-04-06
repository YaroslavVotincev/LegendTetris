using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presetStart : MonoBehaviour
{

    public GameObject testCube;

    public GameObject constantShape;

    public GameObject firstShape;

    public static int firstShapeid = -1;

    public static int constantShapeid = -1;

    public GameObject[] allshapes;

    public static bool isEnabled = true;

    public int[,] presetPole =
    {
        /*
        { 1 , 1 },
        { 1 , 2 },
        { 2 , 1 },
        { 3 , 1 },
        { 4 , 1 },
        { 5 , 1 },
        { 6 , 1 },
        { 7 , 1 },
        { 8 , 1 },
        { 9 , 1 },
        { 10 , 1 },
        */
    };

    public static bool rotated180 = true;

    public GameObject rotatableObjects;

    public GameObject controls; //16 3

    
    void Awake()
    {
        if (isEnabled)
        { 
            allshapes = this.GetComponent<game>().allshapes;

            for (int i = 0; i < 7; i++)
            {

                if (allshapes[i] == firstShape)
                {
                    firstShapeid = i;
                }

                if (allshapes[i] == constantShape)
                {
                    constantShapeid = i;
                }

            }

            if (firstShapeid == -1)
            {
                firstShapeid = constantShapeid;
            }

            for (int i = 0; i < presetPole.GetUpperBound(0) + 1; i++)
            {
                game.pole[presetPole[i, 1], presetPole[i, 0]] = 1;

                game.pole2[presetPole[i, 1], presetPole[i, 0]] = Instantiate(testCube, new Vector3(presetPole[i, 0], presetPole[i, 1]), Quaternion.identity);
            }

            

        }
    }

    private void Start()
    {

        if (rotated180 == true)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
            rotatableObjects.transform.rotation = Quaternion.Euler(0, 0, 180);
            rotatableObjects.transform.position = new Vector3(-15, 5);
            controls.transform.position = new Vector3(-5, 19);
            //controls.transform.rotation = Quaternion.Euler(0,0,180);
            foreach (Transform obj in controls.transform)
            {
                if (obj.GetComponent<rotationButton>() != null)
                {
                    obj.transform.localPosition = new Vector3(-3.56f, -4.38f);
                    
                }
            }
            nextShape.nextShapePos = new Vector3(-6, 2);
        }
    }


}
