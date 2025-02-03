using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CheckWalls", 0.1f);
    }

    public void CheckWalls()
    {
        if (Physics.Raycast(transform.position, -transform.right, 6))
        {
            Debug.DrawRay(transform.position, -transform.right * 6, Color.red, 1.0f); // Draws the ray
            Destroy(transform.GetChild(3).gameObject);
        }
        if (Physics.Raycast(transform.position, transform.right, 6))
        {
            Debug.DrawRay(transform.position, transform.right * 6, Color.green, 1.0f); // Draws the ray
            Destroy(transform.GetChild(2).gameObject);
        }
        if (Physics.Raycast(transform.position, -transform.forward,6))
        {
            Debug.DrawRay(transform.position, -transform.forward * 6, Color.blue, 1.0f); // Draws the ray
            Destroy(transform.GetChild(1).gameObject);
        }
        if (Physics.Raycast(transform.position, transform.forward, 6))
        {
            Debug.DrawRay(transform.position, transform.forward * 6, Color.yellow, 1.0f); // Draws the ray
            Destroy(transform.GetChild(0).gameObject);
        }
    }

  
}
