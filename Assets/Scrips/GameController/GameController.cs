using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    // start config
    [SerializeField] GameObject painelGameOver;
    [SerializeField] SpawnGem spawnGem;

    // ui gem
    [SerializeField] TextMeshProUGUI gemTxt;
    int gemCounter;

    // bar controller
    [SerializeField] Image timerBar;
    [SerializeField] float totalTime = 10f;
    private float currentTime;

    void Start()
    {
        Time.timeScale = 1f;
        painelGameOver.SetActive(false);
        spawnGem.SpawnNewGem();
        ResetTime();
    }

    void Update()
    {
        TimeController();
    }

    // time
    private void TimeController()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerBar.fillAmount = currentTime / totalTime;
        }
        else
        {
            timerBar.fillAmount = 0f;
            GameOver();
            Time.timeScale = 0f;
        }
    }

    public void ResetTime()
    {
        currentTime = totalTime;
        timerBar.fillAmount = 1f;
    }

    // gems
    public void CountGem(int gem)
    {
        gemCounter += gem;
        gemTxt.text = gemCounter.ToString("D2");
        spawnGem.SpawnNewGem();
        ResetTime();
    }

    public int CurrentGems()
    {
        return gemCounter;
    }

    public void GameOver()
    {
        painelGameOver.SetActive(true);
    }
}
