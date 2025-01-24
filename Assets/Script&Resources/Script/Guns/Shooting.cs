using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public int recoil = 0;
    public float laserDistance = 10f;
    public float couldDown = 0.3f;
    public bool isAutomatic = true;

    public LayerMask layerMask;

    
    private bool isShooting = true;
    private Camera mainCamera;
    private BulletsManager bulletsManager;

  

    void Start()
    {
        mainCamera = Camera.main;
        bulletsManager = GetComponent<BulletsManager>();
    }

    void Update()
    {
        if (BulletsManager.isReload)
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
        if (!isShooting || !bulletsManager.isShooting())
            return;
        StartCoroutine(waitTime());

        if (gameObject == null)
            return;

    }

    private IEnumerator waitTime()
    {
        isShooting = false;
        yield return new WaitForSeconds(couldDown);
        isShooting = true;
    }
}
