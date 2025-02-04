using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SearchTarget : MonoBehaviour
{
    GameObject target;

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("gem");

        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
