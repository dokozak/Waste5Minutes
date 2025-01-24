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
    private int timeRecharge = 2;
    private Shooting shooting;
    
    private void Start()
    {
       isReload = false;
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
