
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCScript : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;
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
        #region Mouse Click
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit = new RaycastHit();

        //    if (Physics.Raycast(ray, out hit, 1000))
        //    {
        //        GetComponent<NavMeshAgent>().SetDestination(hit.point);
        //    }
        //}

        #endregion Mouse Click

        #region Patroll Movement
        //if (Vector3.Distance(transform.position, destination) < 1f)
        //{
        //    //    childrenIndex++;
        //    //    childrenIndex = childrenIndex % path.childCount;
        //    //    destination = path.GetChild(childrenIndex).position;
        //    //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
        #endregion

        #region Random Patroll 
        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
            if(!playerDetected) 
            transform.LookAt(destination);
        }
        

        #endregion


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
                    destination= player.transform.position;
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
