using UnityEngine;

public class LifeEnemies : MonoBehaviour
{
    public int lifeEnemies;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (lifeEnemies < 0) { 
        
            Destroy(gameObject);
       }
    }

    public void loseLife(int life)
    {
        lifeEnemies -= life;
        audio.PlayOneShot(audio.clip);
    }
}
