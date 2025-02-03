using UnityEngine;

public class MapCollision : MonoBehaviour
{
    public bool isPlayerCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerCollision)
        {
            isPlayerCollision = true;
            GenerateMap.isContinue = true;
        }
    }

}

