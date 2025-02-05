using UnityEngine;

public class GenerateItem : MonoBehaviour
{

    public GameObject [] item;

    public GameObject[] itemRespaw;
    private const int _noOneTarget = -1;
    private const int _revolver = 2;
    private const int _subMachineGun = 3;
    private const int _rifle = 0;
    private const int _franc = 4;
    private const int _knife = 5;
    private const int _desertEagle =1;

    private const int revolverProbability = 50;
    private const int desertEagleProbability = 75;
    private const int subMachineGunProbability = 89;
    private const int francProbability = 94;
    private const int rifleProbability = 99;
    private const int knifeProbability = 100;

    void Start()
    {
        for (int i = 0; i < itemRespaw.Length; i++) {
            Instantiate(getItem(), itemRespaw[0].transform.position, Quaternion.Euler(0, 0, 90), itemRespaw[0].transform);
        }
    }


    private GameObject getItem()
    {
        switch (Random.Range(0, 101))
        {
            case < revolverProbability:
                return item[_revolver];

            case < desertEagleProbability:
                return item[_desertEagle];
             
            case < subMachineGunProbability:
                return item[_subMachineGun];
              
            case < francProbability:
                return item[_franc];
             
            case < rifleProbability:
                return item[_rifle];
               
            case knifeProbability:
                return item[_knife];
            
            default:
                return item[_revolver];
        }
    }
}
