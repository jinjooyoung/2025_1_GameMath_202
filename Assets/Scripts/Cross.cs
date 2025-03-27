using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerForward = transform.forward;
        Vector3 toTarget = (target.position - transform.position).normalized;

        if (IsLeft(playerForward, toTarget, Vector3.up))
        {
            Debug.Log("왼쪽");
        }
        else
        {
            Debug.Log("오른쪽");
        }
    }

    bool IsLeft(Vector3 forward, Vector3 targetDirection, Vector3 up)
    {
        Vector3 cross = CrossV(forward, targetDirection);
        return Vector3.Dot(cross, up) > 0;
    }

    // 외적
    Vector3 CrossV(Vector3 a, Vector3 b)
    {
        return new Vector3(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x);
    }
}


