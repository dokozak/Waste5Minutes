using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 10f;

    private Vector2 entradaRaton;
    private float valuex, valuey;

    private void OnLook(InputValue value)
    {
        if (Input.GetKey(KeyCode.Mouse1
            ))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Mouse movement imput");
            entradaRaton = value.Get<Vector2>();
            rotateCharacter();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void rotateCharacter()
    {
        float mouseX = entradaRaton.x * sensitivity * Time.deltaTime;
        float mouseY = entradaRaton.y * sensitivity * Time.deltaTime;


        valuex += mouseX;
        valuey -= mouseY;

        valuey = Mathf.Clamp(valuey, -90f, 90f);

        transform.localRotation = Quaternion.Euler(valuey, valuex, 0);
    }
}
