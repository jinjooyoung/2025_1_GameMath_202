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
        // 실습 1 : 키보드 인풋을 받아서 X Y 로 움직이는 객체 생성
        /*float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");*/

        /*Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += move;*/

        //===========================================================================

        // 실습 2 : normalized 사용해서 대각선 이동 속도도 동일하게
        /*Vector3 direction = new Vector3 (moveX, moveY, 0).normalized;
        Vector3 move = direction * speed * Time.deltaTime;
        transform.position += move;*/

        //===========================================================================

        // 실습 3 : normalized 를 쓰지 않고 직접 계산해서 구하기
        /*float magnitude = Mathf.Sqrt(moveX*moveX + moveY*moveY);

        if (magnitude != 0)     // 0으로 나눌 수 없음
        {
            Vector3 direction = new Vector3(moveX / magnitude, moveY / magnitude, 0);
            Vector3 move = direction * speed * Time.deltaTime;
            transform.position += move;
        }*/

        //===========================================================================

        // 실습 4 : 마우스 클릭 -> 해당 위치로 이동
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

        // 실습 5 : 정확히 땅 위에 붙어 다니기 + 이동 종료시 떨림 현상 해결
        if ((targetPos - transform.position).magnitude >= 0.1f)
        {
            direction = (targetPos - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        Vector3 groundY = new Vector3(transform.position.x, 0.5f, transform.position.z);
        transform.position = groundY;
    }
}
