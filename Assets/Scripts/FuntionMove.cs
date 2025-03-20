using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuntionMove : MonoBehaviour
{
    public float speed = 5f;
    public float angle = 30f;
    float radians = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))   // 오른쪽 화살표를 누르면
        {
            angle += 15f; 
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            angle -= 15f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
        }

        radians = angle * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
        transform.position += direction * speed * Time.deltaTime;
    }
}
