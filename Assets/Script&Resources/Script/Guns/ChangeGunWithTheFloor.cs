using System.Collections;
using UnityEngine;

public class ChangeGunWithTheFloor : MonoBehaviour
{
    private bool isChange = true;
    private int waitTime = 2;
    private void OnTriggerStay(Collider other)
    {
        if(isChange && other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {

            isChange = false;
            StartCoroutine(wait());
            if (transform.GetChild(0).gameObject.GetComponent<GunInformation>().isFirstInventory) {

                other.GetComponent<Inventory>().changeFirstGun(transform);
            } else
            {
                other.GetComponent<Inventory>().changeSecondGun(transform);
            }

           

        }
    }

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(waitTime);
        isChange = true;
    }
}
