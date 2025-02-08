using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{
    public GameObject progressBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if (DisableProgressBar.progressBar[0].activeSelf)
        {
            Destroy(gameObject);
        }
        else
        {
            Instantiate(progressBar, this.transform.position, Quaternion.identity, transform);
        }
    }


    private void Update()
    {
        if (DisableProgressBar.progressBar[0].activeSelf)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < DisableProgressBar.progressBar.Length; i++)
            {
                DisableProgressBar.progressBar[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }

}
