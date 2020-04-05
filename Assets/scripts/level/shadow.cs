using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        while (isValidPosition(0, -1))
            transform.position += new Vector3(0, -1, 0);
                 
    }

    bool isValidPosition(int x1, int y1)
    {

        foreach (Transform cube in transform)
        {

            int x = Mathf.RoundToInt(cube.transform.position.x) + x1;

            int y = Mathf.RoundToInt(cube.transform.position.y) + y1;

            if (x <= 0f || x >= 11f || y <= 0f)
                return false;

            if (game.pole[y, x] == 1 )
                return false;

        }

        return true;

    }
}
