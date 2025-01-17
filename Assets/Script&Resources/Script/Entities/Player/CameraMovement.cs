using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 10f;

    private Vector2 entradaRaton;
    private float valuex, valuey;

    private void OnLook(InputValue value)
    {
        Debug.Log("Mouse movement imput");
        entradaRaton = value.Get<Vector2>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = entradaRaton.x * sensitivity * Time.deltaTime;
        float mouseY = entradaRaton.y * sensitivity * Time.deltaTime;

      
        valuex += mouseX;
        valuey -= mouseY;

        valuey = Mathf.Clamp(valuey, -90f, 90f);

        transform.localRotation = Quaternion.Euler(valuey, valuex, 0);
    }
}
