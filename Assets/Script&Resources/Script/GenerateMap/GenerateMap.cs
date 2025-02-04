using System;
using System.Collections;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GenerateMap : MonoBehaviour
{
    public GameObject[] plataform;

    public GameObject father;

    private ArrayList listOfPlataform;
    private NavMeshSurface fatherNavMesh;

    private int pointOfTheNextLevel;

    private const int plataformNormal1x1 = 0;
    private const int plataformWithItem1x1 = 1;
    private const int plataformWithEnemies1x1 = 2;
    private const int plataformWithItemAndEnemies1X3 = 3;
    private const int plataformNormal5x5 = 4;
    private const int plataformNormalWithItem5x5 = 5;
    private const int plataformNormalWithLifeBar5x5 = 6;

    private const int plataformFinal = 7;

    private const int probabilityOfNormal1x1 = 30;
    private const int probabilityOfWithItem1x1 = 40;
    private const int probabilityOfWithEnemies1x1 = 90;
    private const int probabilityOfWithItemAndEnemies1x3 = 101;
    private const int probabilityOfNormal5x5 = 50;
    private const int probabilityOfNormalWithItem5x5 = 70;
    private const int probabilityOfNormalWithLifeBar5x5 = 101;

    public static bool isContinue = false;

    private float waitTime = 0.1f;
    private void Start()
    {
        fatherNavMesh = father.GetComponent<NavMeshSurface>();
        isContinue = false;
        listOfPlataform = new ArrayList();
        StartCoroutine(createFirstMap(Vector3.zero, new Vector3(5, 0, 0)));
       
    }

    private void Update()
    {
        
    }

    IEnumerator createFirstMap(Vector3 firstPosition, Vector3 movement)
    {
        yield return null;
        listOfPlataform.Add(Instantiate(plataform[plataformNormal1x1], firstPosition, Quaternion.identity, father.transform));
        for (int i = 0; i < 4; i++)
        {
            firstPosition += movement;
            listOfPlataform.Add(Instantiate(getRandom1xXPlataform(),firstPosition, Quaternion.identity, father.transform));
        }
        firstPosition += movement * 4;
        GameObject lastPlataform = Instantiate(plataform[plataformNormal5x5], firstPosition, Quaternion.identity, father.transform);
        StartCoroutine(continueMaps(lastPlataform, firstPosition, movement));
    }

    //REcojer un objeto de tipo suelo y despues comprobar si ese suelo ha sido tocado,
    IEnumerator continueMaps(GameObject map, Vector3 midPosition, Vector3 movement)
    {
        yield return new WaitForSeconds(waitTime * 5);
        StartCoroutine(createMeshData());
        AddLight.Add();
        while (!isContinue) yield return new WaitForSeconds(waitTime);
        if (map.GetComponent<MapCollision>().isPlayerCollision) 
        {
            yield return new WaitForSeconds(waitTime * 2);
            deleteList();
            isContinue = false;
            listOfPlataform.Add(map);
            StartCoroutine(createMap(midPosition + movement * 3, movement));
            movement = new Vector3(movement.z,0, movement.x);
            StartCoroutine(createMap(midPosition + movement * 3, movement));
            if(movement.x == 1)
            {
                movement.x *= -1;
            }
            else
            {
                movement.z *= -1;
            }
           
            StartCoroutine(createMap(midPosition + movement * 3, movement));
            yield return new WaitForSeconds(waitTime);
            map.GetComponent<BigPieceScript>().CheckWalls();
        }
        else
        {
            Destroy(map);
        }



    }

    IEnumerator createMeshData()
    {

            fatherNavMesh.navMeshData = null;
            fatherNavMesh.BuildNavMesh();
            yield return null;
        
    }

    IEnumerator createMap(Vector3 position, Vector3 movement)
    {
        yield return null;

        for (int i = 0; i < 5; i++)
        {
            position += movement;

            listOfPlataform.Add(Instantiate(getRandom1xXPlataform(), position, Quaternion.identity, father.transform));
        }

        int randomNumber = UnityEngine.Random.Range(0, 3);


        if (randomNumber == 0)
        {
            if(movement.x == 0)
            {
                movement = new Vector3(movement.z * -1, 0, movement.x);
            }
            else
            {
                movement = new Vector3(movement.z, 0, movement.x * -1);
            }
          
        }
        else if(randomNumber == 1)
        {
            
            movement = new Vector3(movement.z, 0, movement.x);
        }

        for (int i = 0; i < 4; i++)
        {
            position += movement;
            listOfPlataform.Add(Instantiate(getRandom1xXPlataform(), position, Quaternion.identity, father.transform));
        }

        position += movement * 4;
        if (!Physics.Raycast(position, movement))
        {
            GameObject lastPlataform = Instantiate(getRandom5x5Plataform(), position, Quaternion.identity, father.transform);
            StartCoroutine(continueMaps(lastPlataform, position, movement));
        }
            Debug.DrawRay(position, movement, Color.white, 99f);
     
        

    }

    


    private void deleteList()
    {
        while (listOfPlataform.Count != 0)
        {
            Destroy((GameObject)listOfPlataform[0]);
            listOfPlataform.RemoveAt(0);
        }
    }

    private GameObject getRandom1xXPlataform()
    {
        switch (UnityEngine.Random.Range(0,101))
        {
            case < probabilityOfNormal1x1:
                return plataform[plataformNormal1x1];
            case < probabilityOfWithItem1x1:
                return plataform[plataformWithItem1x1];
            case < probabilityOfWithEnemies1x1:
                return plataform[plataformWithEnemies1x1];
            case < probabilityOfWithItemAndEnemies1x3:
                return plataform[plataformWithItemAndEnemies1X3];
            default:
                return plataform[plataformNormal1x1];

        }

    }

    private GameObject getRandom5x5Plataform()
    {
        switch (UnityEngine.Random.Range(0, 101))
        {
            case < probabilityOfNormal5x5:
                return plataform[plataformNormal5x5];
            case < probabilityOfNormalWithItem5x5:
                return plataform[plataformNormalWithItem5x5];
            case < probabilityOfNormalWithLifeBar5x5:
                return plataform[plataformNormalWithLifeBar5x5];
            default:
                return plataform[plataformNormal5x5];

        }

    }



}
