using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fx : MonoBehaviour
{
    [SerializeField] GameObject fx;
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioClip sfxCoin;

    public void ActiveFx()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;

        if (fx != null)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioManager.PlayOneShot(sfxCoin);
            fx.SetActive(true);
        }
    }
}
