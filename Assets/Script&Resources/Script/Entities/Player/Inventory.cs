using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(HidenArms))]
public class Inventory : MonoBehaviour
{
    private GameObject firstWeapon;
    private GameObject secondWeapon;

    private HidenArms arms;

    public float animationTime;
    public Transform fatherOfGun;

    private const int revolverProbability = 50;
    private const int desertEagleProbability = 75;
    private const int subMachineGunProbability = 89;
    private const int francProbability = 94;
    private const int rifleProbability = 99;
    private const int knifeProbability = 100;

    public static bool isChangeArms = false;

    private void Start()
    {
        isChangeArms = false;
        arms = GetComponent<HidenArms>();
        getFirstWeapon();
    }

    private void Update()
    {
        if (GunsOnFloorCollisions.weaponOnFloor == null || BulletsManager.isReload || isChangeArms)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ChangeArms());

        }
    }

    private IEnumerator ChangeArms()
    {
        //Add animation

        yield return new WaitForSeconds(animationTime);

        activateArms();
        isChangeArms = true;
    }


    private void activateArms()
    {
        if (GunsOnFloorCollisions.weaponOnFloor.GetComponent<GunInformation>().isFirstInventory)
        {
            firstWeapon.transform.position = GunsOnFloorCollisions.weaponOnFloor.gameObject.transform.position;
            firstWeapon.AddComponent<GunsOnFloorCollisions>();
        }
        else
        {
            secondWeapon.transform.position = GunsOnFloorCollisions.weaponOnFloor.gameObject.transform.position;
            secondWeapon.AddComponent<GunsOnFloorCollisions>();
        }

        switch (GunsOnFloorCollisions.weaponOnFloor.GetComponent<GunInformation>().typeOfGun)
        {
            //case HidenArms._revolver:
            //    secondWeapon = Instantiate(arms.inventoryArms[HidenArms._revolver], arms.positionsOfTheArms[HidenArms._revolver], Quaternion.identity);
            //    break;
            //case HidenArms._desertEagle:
            //    secondWeapon = Instantiate(arms.inventoryArms[HidenArms._desertEagle], arms.positionsOfTheArms[HidenArms._desertEagle], Quaternion.identity);
            //    break;
            //case HidenArms._subMachineGun:
            //    firstWeapon = Instantiate(arms.inventoryArms[HidenArms._subMachineGun], arms.positionsOfTheArms[HidenArms._subMachineGun], Quaternion.identity);
            //    break;
            //case HidenArms._franc:
            //    firstWeapon = Instantiate(arms.inventoryArms[HidenArms._franc], arms.positionsOfTheArms[HidenArms._franc], Quaternion.identity);
            //    break;
            //case HidenArms._rifle:
            //    firstWeapon = Instantiate(arms.inventoryArms[HidenArms._rifle], arms.positionsOfTheArms[HidenArms._rifle], Quaternion.identity);
            //    break;
            //case HidenArms._knife:
            //    secondWeapon = Instantiate(arms.inventoryArms[HidenArms._knife], arms.positionsOfTheArms[HidenArms._knife], Quaternion.identity);
            //    break;
        }
    }

    private void getFirstWeapon()
    {
        Instantiate(arms.inventoryArms[HidenArms._revolver], Vector3.zero, Quaternion.identity, arms.positionsOfTheArms[HidenArms._revolver]);
        return;
        //switch (Random.Range(0, 101))
        //{
        //    case < revolverProbability:
        //        secondWeapon = Instantiate(arms.inventoryArms[HidenArms._revolver], arms.positionsOfTheArms[HidenArms._revolver], Quaternion.identity);
        //        break;
        //    case < desertEagleProbability:
        //        secondWeapon = Instantiate(arms.inventoryArms[HidenArms._desertEagle], arms.positionsOfTheArms[HidenArms._desertEagle], Quaternion.identity);
        //        break;
        //    case < subMachineGunProbability:
        //        firstWeapon = Instantiate(arms.inventoryArms[HidenArms._subMachineGun], arms.positionsOfTheArms[HidenArms._subMachineGun], Quaternion.identity);
        //        break;
        //    case < francProbability:
        //        firstWeapon = Instantiate(arms.inventoryArms[HidenArms._franc], arms.positionsOfTheArms[HidenArms._franc], Quaternion.identity);
        //        break;
        //    case < rifleProbability:
        //        firstWeapon = Instantiate(arms.inventoryArms[HidenArms._rifle], arms.positionsOfTheArms[HidenArms._rifle], Quaternion.identity);
        //        break;
        //    case knifeProbability:
        //        secondWeapon = Instantiate(arms.inventoryArms[HidenArms._knife], arms.positionsOfTheArms[HidenArms._knife], Quaternion.identity);
        //        break;

        //}
       
    }


}
