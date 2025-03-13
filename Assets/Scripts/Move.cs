using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 targetPos;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �ǽ� 1 : Ű���� ��ǲ�� �޾Ƽ� X Y �� �����̴� ��ü ����
        /*float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");*/

        /*Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += move;*/

        //===========================================================================

        // �ǽ� 2 : normalized ����ؼ� �밢�� �̵� �ӵ��� �����ϰ�
        /*Vector3 direction = new Vector3 (moveX, moveY, 0).normalized;
        Vector3 move = direction * speed * Time.deltaTime;
        transform.position += move;*/

        //===========================================================================

        // �ǽ� 3 : normalized �� ���� �ʰ� ���� ����ؼ� ���ϱ�
        /*float magnitude = Mathf.Sqrt(moveX*moveX + moveY*moveY);

        if (magnitude != 0)     // 0���� ���� �� ����
        {
            Vector3 direction = new Vector3(moveX / magnitude, moveY / magnitude, 0);
            Vector3 move = direction * speed * Time.deltaTime;
            transform.position += move;
        }*/

        //===========================================================================

        // �ǽ� 4 : ���콺 Ŭ�� -> �ش� ��ġ�� �̵�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point;
            }
        }
        /*direction = (targetPos - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;*/

        //===========================================================================

        // �ǽ� 5 : ��Ȯ�� �� ���� �پ� �ٴϱ� + �̵� ����� ���� ���� �ذ�
        if ((targetPos - transform.position).magnitude >= 0.1f)
        {
            direction = (targetPos - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        Vector3 groundY = new Vector3(transform.position.x, 0.5f, transform.position.z);
        transform.position = groundY;
    }
}
