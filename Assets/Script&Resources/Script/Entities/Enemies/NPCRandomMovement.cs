using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCRandomMovement : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Vector3 min, max;

    [SerializeField] private GameObject player;
    [SerializeField] private float playerDetectionDistance;
    [SerializeField] private float angleVision;
    [SerializeField] private bool playerDetected;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destination = RandomDestination();
        GetComponent<NavMeshAgent>().SetDestination(destination);
        StartCoroutine(DistanceDetection());
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
            if (!playerDetected)
                transform.LookAt(destination);
        }



    }
    #region Random Destination
    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }

    #endregion

    IEnumerator Follow()
    {
        destination = player.transform.position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);

    }

    IEnumerator DistanceDetection()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < playerDetectionDistance)
            {
                Vector3 playerVector = player.transform.position - transform.position;
                if (Vector3.Angle(playerVector.normalized, transform.forward) < angleVision)
                {

                    playerDetected = true;
                    destination = player.transform.position;
                    GetComponent<NavMeshAgent>().SetDestination(destination);
                }

                playerDetected = true;
                destination = player.transform.position;
                GetComponent<NavMeshAgent>().SetDestination(destination);
            }
            else
            {
                playerDetected = false;
                RandomDestination();
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = false;

        }
    }
}
