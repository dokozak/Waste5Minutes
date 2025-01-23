using UnityEngine;
using UnityEngine.InputSystem;


public class HandMovement : MonoBehaviour
{
    public GameObject hand;

    private const float minX = -45.3f, maxX = 65.92f;
    private const float minY = -30.0f, maxY = 20.00f;

    public static bool isEnable = true;

    public Vector3 defaultPosition = new Vector3(0,0,0);
    private void Update()
    {
        if (!isEnable)
        {

            hand.transform.localRotation = Quaternion.Euler(defaultPosition);
            return;
        }
          
        float changeX = changeValues(Input.mousePosition.x, Screen.width, minX, maxX);
        float changeY = changeValues(Input.mousePosition.y, Screen.height, minY, maxY);
        hand.transform.localRotation = Quaternion.Euler(-changeX, 0, changeY);
    }

    private float changeValues(float mousePosition,float screenMax, float minValue,float maxValue)
    {
        float value = mousePosition / screenMax * 100;

        minValue = (minValue < 0) ? -minValue : minValue;

        return (minValue + maxValue) * value / 100 - minValue;

    }


}
