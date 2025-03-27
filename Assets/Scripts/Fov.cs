using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fov : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;
    public Material enemy;

    void Start()
    {
        enemy = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;

        float dot = Dot(toPlayer, forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        enemy.color = Color.white;

        if (angle < viewAngle/2)
        {
            enemy.color = Color.red;
        }
    }

    // ³»Àû
    float Dot(Vector3 a, Vector3 b)
    {
        return a.x* b.x + a.y * b.y + a.z * b.z;
    }

    
}
