using UnityEngine;

public class PowerOffPieces : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<BigPieceScript>().CheckWalls();
    }

}
