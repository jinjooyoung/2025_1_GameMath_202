using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public GameObject clearText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 85f)
        {
            clearText.SetActive(true);
            transform.position = new Vector3(0, 1, 0);
        }

        if (transform.position.x > 11.4f)
        {
            transform.position = new Vector3(11.4f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11.4f)
        {
            transform.position = new Vector3(-11.4f, transform.position.y, transform.position.z);
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3 (moveX, 0, moveZ).normalized;
        Vector3 move = transform.TransformDirection(direction) * moveSpeed * Time.deltaTime;
        transform.position += move;

        if (Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= RotateQ(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.rotation *= RotateQ(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
    }

    Quaternion RotateQ(Vector3 a)
    {
        return Quaternion.Euler(a.x, a.y, a.z);
    }
}
