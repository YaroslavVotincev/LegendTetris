using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public GameObject[] allshapes;

    public GameObject fill, gameOverCube;

    public static GameObject currentShape;

    public static int score = 0;

    float ptrTime=0;

    int ai = 1, aj = 1;
        
    int completedLines=0;

    public GameObject textScore;

    public GameObject empty;

    public static bool gameOver = false, poleGameOverCleared = false;

    public static bool activePhase = true;

    public static GameObject[,] pole2 = new GameObject[27, 12];

    public static byte[,] pole = new byte[27, 12]
    {

         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,0,0,0,0,0,0,0,0,0,0,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2},
         {2,2,2,2,2,2,2,2,2,2,2,2}

    };




    // Start is called before the first frame update
    void Start()
    {

        if (presetStart.isEnabled && presetStart.firstShapeid >= 0)
        {
            nextShape.id = presetStart.firstShapeid;
        }
        else nextShape.id = Random.Range(0, 7);

        NextShape();

        pole2FillingEmpty();

    }

    // Update is called once per frame
    void Update()
    {
        if (activePhase)
        {
            if (shapes.isStopped == true)
            {
                shapeStoppedHandler();
            }    
        }

        else if (poleGameOverCleared == false && gameOver == true)
        {
            if (Time.time - ptrTime > 0.01f)
            {
                ptrTime = Time.time;

                if (poleFillGameOverCubes() == false)
                    poleGameOverCleared = true;
            }
        }

        else if(poleGameOverCleared==true)
        {
            this.GetComponent<cameraControl>().moveToGameOver();
        }

    }

    void shapeStoppedHandler()
    {
        if (gameOver == false && currentShape != null)
            transformToFilling();

        if (gameOver == false)
        {
            shapes.isStopped = false;

            completedLines = 0;

            poleGameOverCleared = false;

            if (checkForLines() == false)
            {
                NextShape();
            }
            else
            {
                Invoke("checkForLines", 0.5f);

                Invoke("checkForLines", 0.7f);

                Invoke("checkForLines", 0.9f);

                Invoke("NextShape", 0.9f);
            }
        }

        else
        {
            poleGameOverCleared = false;

            activePhase = false;
        }

    }




    void NextShape()
    {

        currentShape = Instantiate(allshapes[nextShape.id]) as GameObject;

        currentShape.transform.position = new Vector3(5, 23, 0);

        nextShape.needToChange = true;

    }

    void poleFillingCubes()
    {

        for (int i = 0; i < 27; i++)
        {

            for (int j = 0; j < 12; j++)
            {

                if (pole[i, j] == 1)
                    pole2[i, j] = Instantiate(fill, new Vector3(j, i, 0), Quaternion.identity) as GameObject;

            }

        }

    }

    void pole2FillingEmpty()
    {

        for (int i = 0; i < 27; i++)
        {

            for (int j = 0; j < 12; j++)
            {

                if (pole2[i, j] == null || pole2[i,j]==gameOverCube)
                    pole2[i, j] = Instantiate(empty, new Vector3(j, i, 0), Quaternion.identity) as GameObject;

            }

        }

    }

    public void poleRetryClear()
    {

        for (int i = 1; i < 25; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (pole[i, j] == 1 )
                {
                    pole[i, j] = 0;

                    Destroy(pole2[i, j]);
                }
                Destroy(pole2[i, j]);
            }
        }
        pole2FillingEmpty();
        //this.GetComponent<cameraControl>().moveToGameOver();
    }

    bool poleFillGameOverCubes()
    {
        if (ai<24)
        {
            Destroy (pole2[ai, aj%12]) ;
            pole2[ai, aj%12] = Instantiate(gameOverCube, new Vector3(aj%12, ai, 0), Quaternion.identity) as GameObject;
            if (aj % 12 == 0) ai++;
            aj++;
            return true;
        }
        return false;
    }


    void transformToFilling()
    {

        foreach (Transform cube in currentShape.transform)
        {

            int x = Mathf.RoundToInt(cube.transform.position.x);

            int y = Mathf.RoundToInt(cube.transform.position.y);

           // Destroy( pole2[y, x] );

            pole2[y,x] = Instantiate(fill, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

            pole2[y, x].GetComponent<SpriteRenderer>().color = cube.GetComponent<SpriteRenderer>().color;

            pole[y,x] = 1;

            if (y >= 21)
                gameOver = true;

        }

        Destroy(currentShape);
        pole2FillingEmpty();

    }

    bool checkForLines()
    {

        int a, i, j;

        for (i = 0; i < 22; i++)
        {

            a = 0;

            for (j = 1; j < 11; j++)
            {

                if (pole[i, j] == 1)
                    a++;

            }

            if (a == 10)
            {

                for (int k = 1; k < 11; k++)
                {

                    Destroy(pole2[i, k]);

                }

                for (int g = i; g < 20; g++)
                {

                    for (int k = 1; k < 11; k++)
                    {

                        pole[g, k] = pole[g + 1, k];

                        pole2[g, k] = pole2[g + 1, k];

                        pole2[g, k].transform.position += new Vector3(0, -1, 0);
                         
                    }

                }

                completedLines++;

                score += 10 * completedLines;

                textScore.GetComponent<Text>().text = ("Счёт: " + System.Convert.ToString(score));

                pole2FillingEmpty();

                return true;

            }
        }
        return false;
    }

}
