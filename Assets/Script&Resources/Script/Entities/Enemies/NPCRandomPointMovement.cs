using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCRandomPointMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        childrenIndex = path.childCount;
        randomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {


        #region Random Patroll 
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            randomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }


        #endregion


    }
    private void randomDestination()
    {
        destination = path.GetChild(Random.Range(0, childrenIndex)).position;
    }

}
