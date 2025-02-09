using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    [SerializeField] GameController controller;
    [SerializeField] List<GameObject> obstacle;

    // Update is called once per frame
    void Update()
    {
        switch (controller.CurrentGems())
        {
            case 3:
                obstacle[0].SetActive(true);
                break;
            case 6:
                obstacle[1].SetActive(true);
                break;
            case 9:
                obstacle[2].SetActive(true);
                break;
            case 15:
                obstacle[3].SetActive(true);
                break;
        }
    }
}
