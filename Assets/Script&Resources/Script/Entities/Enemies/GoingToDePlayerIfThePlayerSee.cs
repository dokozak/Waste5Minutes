using UnityEngine;
using UnityEngine.AI;

public class GoingToDePlayerIfThePlayerSee : MonoBehaviour
{
    private GameObject player;
    private Vector3 lastDestination;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }



    void Update()
    {
        Vector3 newDestination;
        bool isVisible = IsVisibleFromCamera(Camera.main) || Vector3.Distance(player.transform.position, transform.position) < 5;

     
        Debug.Log("Ingo" + Vector3.Distance(player.transform.position, transform.position));
        if (!isVisible)
        {

            newDestination = transform.position;
        }
        else
        {
            newDestination = player.transform.position;
        }

        if (lastDestination != newDestination)
        {

            GetComponent<NavMeshAgent>().SetDestination(newDestination);
            lastDestination = newDestination;
            if (!isVisible)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Walk");
            }
        }
    }

    bool IsVisibleFromCamera(Camera cam)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }
}
