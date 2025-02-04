using UnityEngine;

public class DisableProgressBar : MonoBehaviour
{
    public static GameObject[] progressBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        progressBar = GameObject.FindGameObjectsWithTag("ProgressBarItem");

        for (int i = 0; i < progressBar.Length; i++) { 
        progressBar[i].SetActive(false);
        }
    }
}
