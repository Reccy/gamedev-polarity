using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    [SerializeField] float fadeInTime = 1f;
    [SerializeField] Text timeText;
    float endTimeInSeconds;

    Image panel;
    Timer timer;

    void Awake()
    {
        panel = GetComponent<Image>();
        timer = FindObjectOfType<Timer>();
    }

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartFadeIn()
    {
        SetTimers();
        StartCoroutine(FadeIn());
    }

    void SetTimers()
    {
        endTimeInSeconds = timer.timeInSeconds;

        int minutes = Mathf.FloorToInt(endTimeInSeconds / 60f);
        int seconds = Mathf.RoundToInt(endTimeInSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timeText.text = "Your time: " + minutes.ToString("00") + ":" + seconds.ToString("00");


        timer.gameObject.SetActive(false);

    }

    IEnumerator FadeIn()
    {
        float fadeInIncrements = 20f;

        while (panel.color.a < 1f)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + (1f / fadeInIncrements));
            yield return new WaitForSecondsRealtime(fadeInTime / fadeInIncrements);
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        yield return null;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
