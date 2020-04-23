using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_enter : MonoBehaviour
{
    public static bool begin = false;
    int count = 0;

    private void OnMouseDown()
    {
        presetStart.lvlName = "test";
        SceneManager.LoadScene(1);
        if (count != 0)
            begin = true;
        count++;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
