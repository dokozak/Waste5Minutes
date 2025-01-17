using UnityEngine;
using UnityEngine.InputSystem;

public class HandMovement : MonoBehaviour
{
    public float sensitivity = 10f;
    public GameObject hand;

    private Vector2 entradaRaton;
    private float valuex, valuey;

    private void OnLook(InputValue value)
    {
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            
            entradaRaton = value.Get<Vector2>();
            rotateCharacter();
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

        hand.transform.localRotation = Quaternion.Euler(-valuex, -valuey, 0);
    }
}
