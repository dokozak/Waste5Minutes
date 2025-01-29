using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletsManager : MonoBehaviour
{
    public int bulletsIn;
    public int bulletsMax;
    public int bulletsHave;
    public Animator animator;

    public static bool isReload = false;
    private float timeRecharge = 1.75f;
    
    private void Start()
    {
       isReload = false;
       bulletsIn = bulletsMax;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReload();
        }

           
    }

    private IEnumerator rechargeAnimation()
    {
        isReload = true;
        animator.Play("Recharge");
        yield return new WaitForSeconds(timeRecharge);
        isReload = false;
    }

    private void OnReload()
    {
        if (bulletsIn == bulletsMax || bulletsHave == 0)
        {
            return;
        }
  
        if(bulletsMax-bulletsIn <= bulletsHave)
        {
            StartCoroutine(rechargeAnimation());
            StartCoroutine(RestBullets());
        }
        else
        {
            StartCoroutine(rechargeAnimation());
            StartCoroutine(AllBullets());
        }
        
    }

    private IEnumerator RestBullets()
    {
        yield return new WaitForSeconds(timeRecharge);
        bulletsHave -= bulletsMax - bulletsIn;
        bulletsIn = bulletsMax;
    }

    private IEnumerator AllBullets()
    {
        yield return new WaitForSeconds(timeRecharge);
        bulletsIn += bulletsHave;
        bulletsHave = 0;
    }
    public bool isShooting()
    {
        if (bulletsIn > 0)
        {
            bulletsIn--;
            return true;
        }
        OnReload();
        return false;
      
    }



}
