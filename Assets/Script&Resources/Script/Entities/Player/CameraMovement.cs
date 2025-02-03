using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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

    private void rotateCharacter()
    {
        float mouseX = entradaRaton.x * sensitivity * Time.deltaTime;
        float mouseY = entradaRaton.y * sensitivity * Time.deltaTime;


        valuex += mouseX;

     

        transform.localRotation = Quaternion.Euler(0, valuex, 0);
    }
}
