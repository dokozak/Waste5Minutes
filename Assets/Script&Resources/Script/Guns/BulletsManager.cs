using UnityEngine;
using UnityEngine.InputSystem;

public class BulletsManager : MonoBehaviour
{
    public int bulletsIn;
    public int bulletsMax;
    public int bulletsHave;

    private void OnReload(InputValue value)
    {
        if(bulletsIn == bulletsMax)
        {
            return;
        }
        //Add animation
        if(bulletsMax-bulletsIn <= bulletsHave)
        {
            bulletsHave -= bulletsMax - bulletsIn;
            bulletsIn = bulletsMax;
        }
        else
        {
            bulletsIn += bulletsHave;
            bulletsHave = 0;
        }
        
    }


}
