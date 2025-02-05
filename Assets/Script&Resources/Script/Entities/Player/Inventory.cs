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
        switch (Random.Range(0, 101))
        {
            case < revolverProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._revolver], arms.positionsOfTheArms[HidenArms._revolver].position, arms.positionsOfTheArms[HidenArms._revolver].localRotation, fatherOfGun);
                break;
            case < desertEagleProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._desertEagle], arms.positionsOfTheArms[HidenArms._desertEagle].position, arms.positionsOfTheArms[HidenArms._desertEagle].localRotation, fatherOfGun);
                break;
            case < subMachineGunProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._subMachineGun], arms.positionsOfTheArms[HidenArms._subMachineGun].position, arms.positionsOfTheArms[HidenArms._subMachineGun].localRotation, fatherOfGun);
                break;
            case < francProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._franc], arms.positionsOfTheArms[HidenArms._franc].position, arms.positionsOfTheArms[HidenArms._franc].localRotation, fatherOfGun);
                break;
            case < rifleProbability:
                firstWeapon = Instantiate(arms.inventoryArms[HidenArms._rifle], arms.positionsOfTheArms[HidenArms._rifle].position, arms.positionsOfTheArms[HidenArms._rifle].localRotation, fatherOfGun);
                break;
            case knifeProbability:
                secondWeapon = Instantiate(arms.inventoryArms[HidenArms._knife], arms.positionsOfTheArms[HidenArms._knife].position, arms.positionsOfTheArms[HidenArms._knife].localRotation, fatherOfGun);
                break;

        }

    }

    public void changeFirstGun(Transform positionOnFloor)
    {
        GameObject deleteFirstGun = firstWeapon;
        GameObject deleteSecondGun = transform.GetChild(0).gameObject;

        // Guardar la información del arma antes de destruirla
        GunInformation gunInfo = deleteSecondGun.GetComponent<GunInformation>();

        if (gunInfo == null)
        {
            UnityEngine.Debug.LogError("GunInformation no encontrado en el arma.");
            return;
        }

        // Instanciar la nueva arma antes de destruir la anterior
        firstWeapon = Instantiate(
            deleteSecondGun,
            arms.positionsOfTheArms[gunInfo.typeOfGun].position,
            arms.positionsOfTheArms[gunInfo.typeOfGun].rotation,
            fatherOfGun
        );

        // Si hay un arma anterior, soltarla en el suelo
        if (deleteFirstGun != null)
        {
            Instantiate(deleteFirstGun, positionOnFloor.position, Quaternion.Euler(0, 0, 90), positionOnFloor);
            Destroy(deleteFirstGun, 2f); // Se destruye después de 2 segundos para evitar que desaparezca inmediatamente
        }

        // Destruir la anterior arma equipada después de asegurarse de que la nueva está creada
        Destroy(deleteSecondGun);
    }

    public void changeSecondGun(Transform positionOnFloor)
    {
        GameObject deleteFirstGun = secondWeapon;
        GameObject deleteSecondGun = transform.GetChild(0).gameObject;

        // Guardar la información del arma antes de destruirla
        GunInformation gunInfo = transform.GetChild(0).GetComponent<GunInformation>();

        if (gunInfo == null)
        {
            UnityEngine.Debug.LogError("GunInformation no encontrado en el arma.");
            return;
        }

        // Instanciar la nueva arma antes de destruir la anterior
        secondWeapon = Instantiate(
            deleteSecondGun,
            arms.positionsOfTheArms[gunInfo.typeOfGun].position,
            arms.positionsOfTheArms[gunInfo.typeOfGun].rotation,
            fatherOfGun
        );

        // Si hay un arma anterior, soltarla en el suelo
        if (deleteFirstGun != null)
        {
            Instantiate(deleteFirstGun, positionOnFloor.position, Quaternion.Euler(0, 0, 90), positionOnFloor);
            Destroy(deleteFirstGun, 2f); // Se destruye después de 2 segundos para evitar que desaparezca inmediatamente
        }

        // Destruir la anterior arma equipada después de asegurarse de que la nueva está creada
        Destroy(deleteSecondGun);

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
