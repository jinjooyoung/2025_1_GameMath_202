using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVVisualizer : MonoBehaviour
{
    public float viewAngle = 60f;
    public float viewDistance = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 forward = transform.forward * viewDistance;

        // ����
        Vector3 left = Quaternion.Euler(0, -viewAngle / 2, 0) * forward;
        // ������
        Vector3 right = Quaternion.Euler(0, viewAngle / 2, 0) * forward;

        Gizmos.DrawRay(transform.position, left);
        Gizmos.DrawRay(transform.position, right);

        // ĳ���� ���� ����
        Gizmos.color = Color.red;
        Gizmos.DrawRay (transform.position, forward);
    }
}
