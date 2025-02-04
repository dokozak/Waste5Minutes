using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{
    public GameObject progressBar;

    private GameObject[] progressBarItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressBarItem = DisableProgressBar.progressBar;
        if (progressBarItem[0].activeSelf)
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
        if (progressBarItem[0].activeSelf)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < progressBarItem.Length; i++)
            {
                progressBarItem[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }

}
