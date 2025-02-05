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

                other.GetComponent<Inventory>().changeFirstGun(transform, transform.GetChild(0).gameObject);
            } else
            {
                other.GetComponent<Inventory>().changeSecondsGun(transform, transform.GetChild(0).gameObject);
            }

           

        }
    }

    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(waitTime);
        isChange = true;
    }
}
