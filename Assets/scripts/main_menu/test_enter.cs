using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_enter : MonoBehaviour
{
    //public static bool begin = false;
    

    private void OnMouseDown()
    {
        PlayerPrefs.SetString("chosen_lvl", "test");        
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
