using UnityEngine;
using UnityEngine.InputSystem;

public class BulletsManager : MonoBehaviour
{
    public int bulletsIn;
    public int bulletsMax;
    public int bulletsHave;

    private Shooting shooting;

    private void Start()
    {
       shooting = GetComponent<Shooting>();
       bulletsIn = bulletsMax;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
            OnReload();
    }

    private void OnReload()
    {
        if(bulletsIn == bulletsMax || bulletsHave == 0)
        {
            return;
        }
        //Add animation
        if(bulletsMax-bulletsIn <= bulletsHave)
        {
            Debug.Log("1");
            bulletsHave -= bulletsMax - bulletsIn;
            bulletsIn = bulletsMax;
        }
        else
        {
            Debug.Log("2");
            bulletsIn += bulletsHave;
            bulletsHave = 0;
        }
        
    }



}
