using TMPro;
using UnityEngine;

public class CanvasBulletInformation : MonoBehaviour
{
    public TextMeshProUGUI information;
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        information.text = inventory.getActuallyWeapon().GetComponent<BulletsManager>().getStringBullet();
    }
}
