using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RescueSoul : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiScore;
    [SerializeField] int score = 0;
    [SerializeField] SpawnSouls spawnSpawn;
    [SerializeField] GameController gameControlle;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("soul"))
        {
            score++;
            uiScore.text = score.ToString();
            Destroy(col.gameObject, 0.1f);
            gameControlle.ResetTime();
            spawnSpawn.SpawnSoul();
        }
    }

    public int CurrentSouls()
    {
        return score;
    }
}
