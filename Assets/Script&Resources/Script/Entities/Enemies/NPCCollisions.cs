using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCollisions : MonoBehaviour
{
    public int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<LifeManager>().lifePlayer -= damage * Time.deltaTime;

        }
    }


}
