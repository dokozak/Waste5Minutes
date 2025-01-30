using UnityEngine;

public class GunsOnFloorCollisions : MonoBehaviour
{
    public static GameObject weaponOnFloor;

    private void Start()
    {
        weaponOnFloor = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        weaponOnFloor = null;
    }

    private void OnCollisionStay(Collision collision)
    {
        weaponOnFloor = this.gameObject;
        if (collision.gameObject.CompareTag("Player") && Inventory.isChangeArms)
        {
            weaponOnFloor = null;
            Inventory.isChangeArms = false;
            Destroy(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            weaponOnFloor = null;
    }
}
