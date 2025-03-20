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
        Debug.Log($"{degrees}도 -> 라디안 : {radians}");

        float degreeValue = radianValue * Mathf.Rad2Deg;
        Debug.Log($"파이 / 3 라디안 -> 도 변환 : {degreeValue}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
