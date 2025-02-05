using UnityEngine;

public class LifeEnemies : MonoBehaviour
{
    public int lifeEnemies;

    private void Update()
    {
        if (lifeEnemies < 0) { 
        
            Destroy(gameObject);
       }
    }
}
