using System.Runtime.Serialization;
using UnityEngine;

public class AddLight : MonoBehaviour
{

    private const int WHITE = 1;
    private const int RED = 4;
    private const int BLUE = 2;
    private const int GREEN = 3;
    private const int DARK = 5;
    public static void Add()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject obj in objects)
        {
            CreatePointLight(obj.transform.position, getColor(WHITE));
        }
        objects = GameObject.FindGameObjectsWithTag("OtherLight");
        foreach (GameObject obj in objects)
        {
            Color color = getColor(Random.Range(BLUE, DARK + 1));
            for (int x = 0; x < obj.transform.childCount; x++)
            {

                CreateBigPointLight(obj.transform.GetChild(x).transform.position, color);
            }
        }
    }

    static void CreatePointLight(Vector3 position, Color color)
    {
        GameObject lightObj = new GameObject("Point Light");
        Light pointLight = lightObj.AddComponent<Light>();

        pointLight.type = LightType.Point;
        pointLight.range = 9f;
        pointLight.intensity = 3f;
        pointLight.color = color;

        lightObj.transform.position = position;
    }

    static void CreateBigPointLight(Vector3 position, Color color)
    {
        GameObject lightObj = new GameObject("Point Light");
        Light pointLight = lightObj.AddComponent<Light>();

        pointLight.type = LightType.Point;
        pointLight.range = 20f;
        pointLight.intensity = 7f;
        pointLight.color = color;

        lightObj.transform.position = position;
    }


    private static Color getColor(int color)
    {
        switch (color)
        {
            case DARK:
                return Color.black;
            case RED:
                return Color.red;
            case BLUE:
                return Color.blue;
            case GREEN:
                return Color.green;
            case WHITE:
                return Color.white;
            default:
                return Color.white;
        }
    }
}
