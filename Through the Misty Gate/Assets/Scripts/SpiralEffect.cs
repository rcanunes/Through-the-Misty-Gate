using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralEffect : MonoBehaviour
{
    [SerializeField]
    Transform Trail;

    [SerializeField]
    Transform TrailPrefab;

    void Update() {
        Trail.transform.RotateAround(transform.position, Vector3.up, 5f);

        Trail.position = Vector3.Slerp(Trail.transform.position, transform.position, 0.1f * Time.deltaTime);

        if(Vector3.Distance(Trail.transform.position, transform.position) < 0.5f) {
            Destroy(Trail.gameObject);

            Trail = Instantiate(TrailPrefab, transform);

            transform.position = new Vector3(0, 0, 0);
        }

        transform.Translate(0, 0.1f * Time.deltaTime, 0);
    }
}
