using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public int recoil = 0;
    public float laserDistance = 10f;
    public LayerMask layerMask;
    public bool isAutomatic = true;
    private bool isShooting = false;
    private Camera mainCamera;
  

    void Start()
    {
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (BulletsManager.isReload || isShooting)
            return;
        
        if(isAutomatic)
        {
            if (Input.GetKey(KeyCode.Mouse0)) {
               shooting(createRayCast());
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                shooting(createRayCast());
            }
        }
        
       
    }


    private GameObject createRayCast()
    {

        Vector3 mousePosition = Input.mousePosition;

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);


        if (Physics.Raycast(ray, out RaycastHit hit, laserDistance, layerMask))
        {
            return hit.collider.gameObject;

        }
        return null;
    }

    public void shooting(GameObject gameObject)
    {
        if (gameObject == null)
            return;
    

        
    }

}
