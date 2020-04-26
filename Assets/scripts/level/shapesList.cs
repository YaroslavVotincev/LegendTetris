using UnityEngine;

public class shapesList : MonoBehaviour
{
    public GameObject[] shp;
    public static GameObject[] allshapes;
    private void Awake()
    {
        allshapes = shp;
    }

}
