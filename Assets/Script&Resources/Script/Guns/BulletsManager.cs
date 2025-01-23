using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletsManager : MonoBehaviour
{
    public int bulletsIn;
    public int bulletsMax;
    public int bulletsHave;
    public Animator animator;

    private int timeRecharge = 2;

    private Shooting shooting;
    
    private void Start()
    {
       shooting = GetComponent<Shooting>();
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
        HandMovement.isEnable = false;
        animator.Play("Recharge");
        yield return new WaitForSeconds(timeRecharge);
        HandMovement.isEnable = true;
    }

    private void OnReload()
    {
        if (bulletsIn == bulletsMax || bulletsHave == 0)
        {
            return;
        }
        //Add animation
        if(bulletsMax-bulletsIn <= bulletsHave)
        {
            StartCoroutine(rechargeAnimation());
            bulletsHave -= bulletsMax - bulletsIn;
            bulletsIn = bulletsMax;
        }
        else
        {
            StartCoroutine(rechargeAnimation());
            bulletsIn += bulletsHave;
            bulletsHave = 0;
        }
        
    }



}
