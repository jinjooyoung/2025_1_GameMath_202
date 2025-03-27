using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeEnemy : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;
    public float rorationPerSec = 30f;
    public float viewDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= RotateQ(new Vector3(0, rorationPerSec * Time.deltaTime, 0));

        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;

        float x = gameObject.transform.position.x - player.position.x;
        float z = gameObject.transform.position.z - player.position.z;
        float magnitude = Mathf.Sqrt(x * x + z * z);    // 플레이어로부터 Enemy의 거리

        float dot = Dot(toPlayer, forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        if (angle < viewAngle / 2 && magnitude < viewDistance)
        {
            player.transform.position = new Vector3(0,1,0);
        }
    }

    // 내적
    float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    Quaternion RotateQ(Vector3 a)
    {
        return Quaternion.Euler(a.x, a.y, a.z);
    }
}
