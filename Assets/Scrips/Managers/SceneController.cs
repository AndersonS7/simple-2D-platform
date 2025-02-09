using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] AudioController soundController;

    public void LoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Paused(GameObject gameController)
    {
        soundController.PlayMusic();
        gameController.GetComponent<GameController>().Paused = false;
    }
}
