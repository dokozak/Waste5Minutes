using UnityEngine;
using UnityEngine.InputSystem;


public class HandMovement : MonoBehaviour
{
    public GameObject hand;

    private const float minX = 54.92f , maxX = -50.3f;
    private const float minY = -32.0f, maxY = 32.00f;

    private Vector3 defaultPosition = new Vector3(0,0,0);


    private void Start()
    {

    }


    private void Update()
    {
        if (BulletsManager.isReload)
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
        Debug.Log(value);
        minValue = (minValue < 0) ? -minValue : minValue;
        maxValue = (maxValue < 0) ? -maxValue : maxValue;

        return (minValue + maxValue) * value / 100 - minValue;

    }


}
