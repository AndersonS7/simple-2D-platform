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
            if (Vector2.Distance(transform.position, target.transform.position) < 3)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
