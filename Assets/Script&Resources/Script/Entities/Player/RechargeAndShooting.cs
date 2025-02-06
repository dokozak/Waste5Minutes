using UnityEngine;

public class RechargeAndShooting : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!BulletsManager.isReload)
        
  
        inventory.getActuallyWeapon().GetComponent<Shooting>().shooting(); 

        if (Input.GetKeyDown(KeyCode.R))
        {
            inventory.getActuallyWeapon().GetComponent<BulletsManager>().reload();
        }
    }
}
