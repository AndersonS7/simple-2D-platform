using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fx : MonoBehaviour
{
    [SerializeField] GameObject fx;

    private void Start()
    {
        if (fx != null)
        {
            fx.SetActive(false);
        }
    }

    public void ActiveFx()
    {
        fx.SetActive(true);
    }
}
