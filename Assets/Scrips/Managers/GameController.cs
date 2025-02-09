using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    // player
    [SerializeField] GameObject playerPrefab;
    GameObject player;

    [Header("Obstacle")]
    [SerializeField] List<GameObject> obstacles;

    // start config
    [Header("start config")]
    [SerializeField] camFollow cam;
    [SerializeField] GameObject painelGameOver;
    [SerializeField] GameObject painelStart;
    [SerializeField] GameObject painelWin;
    [SerializeField] SpawnGem spawnGem;
    [SerializeField] Transform startPosPlayer;

    // audio
    [Header("audio")]
    [SerializeField] AudioController soundController;

    // ui gem
    [Header("ui gem")]
    [SerializeField] TextMeshProUGUI gemTxt;
    int gemCounter = 0;

    // bar controller
    [Header("bar controller")]
    [SerializeField] Image timerBar;
    [SerializeField] float totalTime = 10f;
    private float currentTime;

    bool paused = true;

    public bool Paused { get => paused; set => paused = value; }

    private void Awake()
    {
        player = Instantiate(playerPrefab);
        cam.Player = player.transform;
    }

    void Start()
    {
        painelStart.SetActive(true);
        soundController.PlayMusic();

        Time.timeScale = 1f;
        painelGameOver.SetActive(false);
        spawnGem.SpawnNewGem();
        ResetTime();
    }

    void Update()
    {
        if (!paused)
        {
            painelStart.SetActive(false);
            TimeController();

            // win
            if (gemCounter >= 20)
            {
                painelWin.SetActive(true);
                cam.ResetCam();
                paused = true;
                DestroyGems();
                Destroy(player);
            }
        }
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

    public void ReloadScene()
    {
        gemCounter = 0;
        gemTxt.text = gemCounter.ToString("D2");

        player = Instantiate(playerPrefab);
        cam.Player = player.transform;

        if (player != null)
        {
            player.transform.position = startPosPlayer.transform.position;
            spawnGem.SpawnNewGem();
            painelWin.SetActive(false);
            painelStart.SetActive(false);
            painelGameOver.SetActive(false);
            ResetTime();
            RestartObstacles();
            paused = false;
        }
    }

    public int CurrentGems()
    {
        return gemCounter;
    }

    public void GameOver()
    {
        DestroyGems();
        painelGameOver.SetActive(true);
        Destroy(player);
        paused = true;
    }

    private void DestroyGems()
    {
        GameObject[] gems = GameObject.FindGameObjectsWithTag("gem");

        foreach (GameObject gem in gems)
        {
            Destroy(gem);
        }
    }

    private void RestartObstacles()
    {
        foreach (GameObject ob in obstacles)
        {
            ob.SetActive(false);
        }
    }
}
