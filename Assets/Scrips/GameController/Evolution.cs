using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    [SerializeField] RescueSoul souls;
    [SerializeField] List<GameObject> obstacle;

    // Update is called once per frame
    void Update()
    {
        switch (souls.CurrentSouls())
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
        }
    }
}
