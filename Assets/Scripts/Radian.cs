using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radian : MonoBehaviour
{
    public float degrees = 45f;
    public float radianValue = Mathf.PI / 3;

    // Start is called before the first frame update
    void Start()
    {
        float radians = degrees * Mathf.Deg2Rad;
        Debug.Log($"{degrees}�� -> ���� : {radians}");

        float degreeValue = radianValue * Mathf.Rad2Deg;
        Debug.Log($"���� / 3 ���� -> �� ��ȯ : {degreeValue}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
