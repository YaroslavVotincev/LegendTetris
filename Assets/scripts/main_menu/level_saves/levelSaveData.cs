using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class levelSaveData
{
    public bool wasStarted = false;

    public byte[,] pole = new byte[27, 12];

    public string[] poleStr = new string[27]
    {
         "222222222222",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "200000000002",
         "222222222222",
         "222222222222",
         "222222222222",
         "222222222222",
         "222222222222",
         "222222222222"
    };

    public int currentShapeID = 0;

    public int currentShape_x = 5;

    public int currentShape_y = 23;

    public float currentShape_rotation = 0;

    public int score = 0;

    public int targetScore;

    public string lvlName;

    public int firstShapeid = -1;

    public int constantShapeid = -1;

    public byte[,] fromPoleStr_ToPole()
    {
        for (int i = 0; i < 27; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                this.pole[i, j] = System.Convert.ToByte(poleStr[i][j]);
            }
        }
        return this.pole;
    }

    public string[] fromPole_ToPoleStr(byte[,] poleF)
    {
        //StringBuilder[] str = new StringBuilder[27]  ;  
        string[] str1 = new string[27];
        for (int i = 0; i < 27; i++)
        {
            char[] charStr  = new char[12] ;// = str1[i].ToCharArray();

            for (int j = 0; j < 12; j++)
            {
                /*
                if (poleF[i, j] == 2)
                    charStr[j] = '2';
                else if (poleF[i, j] == 1)
                    charStr[j] = '1';
                else if (poleF[i, j] == 0)
                    charStr[j] = '0';*/
                charStr[j] = ( System.Convert.ToChar( poleF[i,j] ) );
            }
            //str1[i] = str[i].ToString();
            str1[i] = new string(charStr);

        }
        
        return str1;
    }
}
