using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public Transform player;
    public float viewAngle = 60f;

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        Vector3 forward = transform.forward;

        float dot = Vector3.Dot(forward, toPlayer);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        gameObject.transform.localScale = Vector3.one;

        float x = gameObject.transform.position.x - player.position.x;
        float z = gameObject.transform.position.z - player.position.z;

        float magnitude = Mathf.Sqrt(x*x + z*z);    // 플레이어로부터 Enemy의 거리

        if (angle < viewAngle / 2 && magnitude < 5)
        {
            gameObject.transform.localScale = Vector3.one * 2;
        }
    }
}
