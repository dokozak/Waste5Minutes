using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform positionOnShooting;
    public GameObject shot;
    public GameObject gunShotPosition;

    private GameObject[] shotBuffer;
    private GameObject[] shotShooting;
    private Vector3 shotBufferPosition = new Vector3(0,99,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shotShooting = new GameObject[20];
        shotBuffer = new GameObject[20];
        for (int i = 0; i < shotBuffer.Length; i++) 
            Instantiate(shotBuffer[i], shotBufferPosition, Quaternion.identity);
        
    }

    public void shooting()
    {
        int nextShot = 0;
        int emptySite = 0;
        while (shotBuffer[nextShot] == null) nextShot++;

        while(shotShooting[emptySite] != null) emptySite++;
    
        
    }

}
