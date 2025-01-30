using System.Collections;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject[] plataform;

    private ArrayList listOfPlataform;

    private int pointOfTheNextLevel;

    private const int plataformNormal1x1 = 0;
    private const int plataformWithItem1x1 = 1;
    private const int plataformWithEnemies1x1 = 2;
    private const int plataformNormal5x5 = 3;
    private const int plataformWithItemAndEnemies1X3 = 5;
    private const int plataformNormalWithItem5x5 = 6;
    private const int plataformFinal = 7;
   

    private void Start()
    {
        StartCoroutine(createMap(Vector3.zero, new Vector3(1, 0, 0)));
    }

    IEnumerator createMap(Vector3 firstPosition, Vector3 movement)
    {
        yield return null;



    }
}
