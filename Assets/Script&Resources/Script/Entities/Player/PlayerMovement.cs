using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int velocity = 5;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward; 
        Vector3 right = transform.right;     

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        if (Input.GetKey(KeyCode.W))
            transform.Translate(forward * Time.deltaTime * velocity, Space.World);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-forward * Time.deltaTime * velocity, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-right * Time.deltaTime * velocity, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(right * Time.deltaTime * velocity, Space.World);
    }
}
