using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
    private const int rifleProbability = 101;
    private const int knifeProbability = 102;

    public bool isFirstGun = true;

    public static bool isChangeArms = false;

    private void Start()
    {
        isChangeArms = false;
        arms = GetComponent<HidenArms>();
        getFirstWeapon();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if(firstWeapon != null) 
            isFirstGun = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (secondWeapon != null)
                isFirstGun = false;
        }

        if (isFirstGun) {
            firstWeapon.SetActive(true);
            if (secondWeapon != null)
                secondWeapon.SetActive(false);
        }
        else
        {
            if(firstWeapon != null)
            firstWeapon.SetActive(false);
            secondWeapon.SetActive(true);
        }
    }

    public GameObject getActuallyWeapon()
    {
        if (isFirstGun)
        {
            return firstWeapon;
        }
        else
        {
            return secondWeapon;
        }
    }
    private void getFirstWeapon()
    {
        switch (Random.Range(0, 101))
        {
            case < revolverProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._revolver], arms.positionsOfTheArms[HidenArms._revolver].position, arms.positionsOfTheArms[HidenArms._revolver].localRotation, fatherOfGun);
                isFirstGun = false;
                break;
            case < desertEagleProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._desertEagle], arms.positionsOfTheArms[HidenArms._desertEagle].position, arms.positionsOfTheArms[HidenArms._desertEagle].localRotation, fatherOfGun);
                isFirstGun = false;
                break;
            case < subMachineGunProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._subMachineGun], arms.positionsOfTheArms[HidenArms._subMachineGun].position, arms.positionsOfTheArms[HidenArms._subMachineGun].localRotation, fatherOfGun);
                isFirstGun = true;
                break;
            case < francProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._franc], arms.positionsOfTheArms[HidenArms._franc].position, arms.positionsOfTheArms[HidenArms._franc].localRotation, fatherOfGun);
                isFirstGun = true;
                break;
            case < rifleProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._rifle], arms.positionsOfTheArms[HidenArms._rifle].position, arms.positionsOfTheArms[HidenArms._rifle].localRotation, fatherOfGun);
                isFirstGun = true;
                break;
            case knifeProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._knife], arms.positionsOfTheArms[HidenArms._knife].position, arms.positionsOfTheArms[HidenArms._knife].localRotation, fatherOfGun);
                isFirstGun = true;
                break;

        }

    }

    public void changeFirstGun(Transform positionOnFloor, GameObject gun)
    {
        GameObject previousGun = firstWeapon;
        GunInformation gunInfo = gun.GetComponent<GunInformation>();

        
        firstWeapon = Instantiate(
            gun,
            arms.positionsOfTheArms[gunInfo.typeOfGun].position,
            transform.localRotation,
            fatherOfGun
        );


        if (previousGun != null)
        {
            previousGun.SetActive(true);
            GameObject droppedGun = Instantiate(previousGun,positionOnFloor.position, Quaternion.Euler(90, 0, 0),positionOnFloor);

        }

        deleteObjects(previousGun, gun);
    }

    public void changeSecondsGun(Transform positionOnFloor, GameObject gun)
    {
        GameObject previousGun = secondWeapon; 
        GunInformation gunInfo = gun.GetComponent<GunInformation>();

        
        secondWeapon = Instantiate(
            gun,
            arms.positionsOfTheArms[gunInfo.typeOfGun].position,
            transform.localRotation,
            fatherOfGun
        );

     
        if (previousGun != null)
        {
            previousGun.SetActive(true);
            GameObject droppedGun = Instantiate(previousGun,positionOnFloor.position,Quaternion.Euler(90, 0, 0),positionOnFloor); 
           
        }

        deleteObjects(previousGun, gun);
    }

    private void deleteObjects(GameObject gm1, GameObject gm2)
    {
        if(gm1 != null) 
            Destroy(gm1);
        if(gm2 != null)
            Destroy(gm2);
    }


    private GameObject getTypeOfGun(int typeOfGun)
    {
        switch (typeOfGun)
        {

            case HidenArms._revolver:
                return arms.inventoryArms[HidenArms._revolver];
            case HidenArms._desertEagle:
                return arms.inventoryArms[HidenArms._desertEagle];
            case HidenArms._subMachineGun:
                return arms.inventoryArms[HidenArms._subMachineGun];
            case HidenArms._franc:
                return arms.inventoryArms[HidenArms._franc];
            case HidenArms._rifle:
                return arms.inventoryArms[HidenArms._rifle];
            case HidenArms._knife:
                return arms.inventoryArms[HidenArms._knife];
        }
        return arms.inventoryArms[HidenArms._revolver];
    }
}
