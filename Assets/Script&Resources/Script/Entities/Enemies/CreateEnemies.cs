using System.Collections;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject[] gameObject;

    public Transform[] positions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomEnemies = Random.Range(0, gameObject.Length);

        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(gameObject[randomEnemies], positions[i].position, Quaternion.identity, positions[i]);
        }

    }
}
