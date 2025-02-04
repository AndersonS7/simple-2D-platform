using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //configurações iniciais
    [SerializeField] GameObject painelGameOver;
    [SerializeField] SpawnSouls spawnSouls;

    // controle da barra
    public Image timerBar;
    public float totalTime = 10f;
    private float currentTime;

    // gameover
    void Start()
    {
        Time.timeScale = 1f;
        painelGameOver.SetActive(false);
        spawnSouls.SpawnSoul();
        ResetTime();
    }

    void Update()
    {
        TimeController();
    }

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

    public void GameOver()
    {
        painelGameOver.SetActive(true);
    }

    public void ResetTime()
    {
        currentTime = totalTime;
        timerBar.fillAmount = 1f;
    }
}
