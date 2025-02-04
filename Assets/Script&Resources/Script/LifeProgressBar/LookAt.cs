using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
