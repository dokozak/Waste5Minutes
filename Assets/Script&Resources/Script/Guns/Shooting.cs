using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

public class Shooting : MonoBehaviour
{

    public int recoil = 0;
    public float laserDistance = 10f;
    public float couldDown = 0.3f;
    public bool isAutomatic = true;
    public int damage = 1;

    
    private bool isShooting = true;
    private Camera mainCamera;
    private BulletsManager bulletsManager;


    private AudioSource audio;
    void Start()
    {

        audio = GetComponent<AudioSource>();
        mainCamera = Camera.main;
        bulletsManager = GetComponent<BulletsManager>();
    }

    public void shooting()
    {
        if (isAutomatic)
        {
            if(Input.GetKey(KeyCode.Mouse0))
                shooting(createRayCast());

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                shooting(createRayCast());
        }
    }

    private GameObject createRayCast()
    {

        Vector3 mousePosition = Input.mousePosition;

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);


        
        if (Physics.Raycast(ray, out RaycastHit hit, laserDistance))
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
        audio.PlayOneShot(audio.clip);
        if (gameObject == null)
            return;

        if (gameObject.CompareTag("Enemy"))
        {
            
            gameObject.GetComponent<LifeEnemies>().loseLife(damage);

        }
    }

    private IEnumerator waitTime()
    {
        isShooting = false;
        yield return new WaitForSeconds(couldDown);
        isShooting = true;
    }
}
