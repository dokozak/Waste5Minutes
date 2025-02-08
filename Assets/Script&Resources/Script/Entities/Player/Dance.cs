using UnityEngine;

public class Dance : MonoBehaviour
{
    private Camera cam;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cam.transform.Rotate(0, -180, 0);
            cam.transform.Translate(0,0,-3);
            animator.Play("capo");
        }
    }
}
