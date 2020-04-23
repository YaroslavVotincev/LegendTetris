﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSaveData 
{
    public bool wasStarted = false;

    public byte[,] pole = new byte[27, 12]
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

    public GameObject[,] pole2 = new GameObject[27, 12];

    public GameObject currentShape;

    public int score = 0;

    public int targetScore;

    public string lvlName;

    public int firstShapeid = -1;

    public int constantShapeid = -1;
}