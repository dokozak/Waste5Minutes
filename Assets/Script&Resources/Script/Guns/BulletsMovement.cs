using UnityEngine;

public class BulletsMovement : MonoBehaviour
{
    public Vector3 movement;

    public bool imShooted;
    private float time;

    private const int timeLife = 3; 
    // Update is called once per frame
    void Update()
    {
        if (!imShooted)
            return;
       
        if((time += Time.deltaTime) > timeLife)
        {

            return;
        }
        


    }
}
