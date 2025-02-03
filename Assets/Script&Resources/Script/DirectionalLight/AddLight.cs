using UnityEngine;

public class AddLight : MonoBehaviour
{
   public static void Add()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Light"); 
        foreach (GameObject obj in objects)
        {
            CreatePointLight(obj.transform.position + Vector3.up * 2); // Pone la luz 2 unidades arriba del objeto
        }
    }

    static void CreatePointLight(Vector3 position)
    {
        GameObject lightObj = new GameObject("Point Light");
        Light pointLight = lightObj.AddComponent<Light>();

        pointLight.type = LightType.Point;
        pointLight.range = 5f;
        pointLight.intensity = 3f;
        pointLight.color = Color.white;

        lightObj.transform.position = position;
    }

}
