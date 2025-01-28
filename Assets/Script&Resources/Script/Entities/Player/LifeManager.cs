using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int lifePlayer = 2;
    public int maxLifePlayer = 4;
    public Image progressBar;

    private const float MINAMOUNT = 0.004f;

    // Update is called once per frame
    void Update()
    {
        float amount = (float)lifePlayer / (float)maxLifePlayer;
        amount = (amount < MINAMOUNT && lifePlayer>0) ? MINAMOUNT : amount;
        progressBar.fillAmount = amount;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyShot")){
            lifePlayer -= 1;
        }
        

    }
}
