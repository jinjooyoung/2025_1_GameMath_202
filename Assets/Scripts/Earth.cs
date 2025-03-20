using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public Transform target;
    public float speed = 30;
    public float angle;
    float radians;

    // Update is called once per frame
    void Update()
    {
        angle+= Time.deltaTime * speed;
        radians = angle * Mathf.Deg2Rad;
        transform.position = new Vector3(target.position.x + Mathf.Cos(radians), 0, target.position.z + Mathf.Sin(radians));
    }
}
