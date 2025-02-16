using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public TextMeshProUGUI time;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int second = (int)timer % 60;
        int minutes = (int)timer / 60;
        string text = (second > 9) ? second + "" : "0" + second;
        time.text = minutes + ":" + text;

        if(timer > 300f)
        {
           SceneManager.LoadScene("WinScene");
        }
    }
}
