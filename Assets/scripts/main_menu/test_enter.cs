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
        PlayerPrefs.SetString("chosen_lvl", "test");
        if (count != 0)
            PlayerPrefs.SetInt("chosen_lvl", 1);
        count++;
        PlayerPrefs.Save();
        //Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(1);
        //Resources.UnloadUnusedAssets();
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
