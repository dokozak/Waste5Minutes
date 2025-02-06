using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatronMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childrenIndex = path.childCount;
        destination = path.GetChild(0).transform.position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        patrollMovement();
    }


    public void patrollMovement()
    {
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            childrenIndex++;
            childrenIndex = childrenIndex % path.childCount;
            destination = path.GetChild(childrenIndex).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }

}
