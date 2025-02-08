using UnityEngine;
using UnityEngine.AI;

public class GointToThePlayer : MonoBehaviour
{
    private GameObject player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);



    }
}
