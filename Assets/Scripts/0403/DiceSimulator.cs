using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSimulator : MonoBehaviour
{
    public int[] counts = new int[6];   // 1~6까지의 주사위 숫자가 나온 갯수만큼 저장
    public int trials = 100;
    public int max = 0;         // 가장 많이 나온 횟수
    public int num = 0;         // 최종적으로 보여줄 주사위 숫자

    public TextMeshProUGUI text;

    public void RollDiceButton()
    {
        Debug.Log("주사위 굴림");
        max = 0;
        num = 0;
        for (int i = 0; i < counts.Length; i++)     // 6번 반복 (육면체) 초기화
        {
            counts[i] = 0;
        }
        for (int i = 0; i < trials; i++)     // 100번 반복
        {
            int result = Random.Range(1, 7);        // 1부터 6까지 랜덤 숫자
            counts[result - 1]++;               // 해당 숫자 -1 자리의 counts 배열 원소를 ++
        }
        for (int i = 0; i < counts.Length; i++)     // 6번 반복 (육면체)
        {
            if (max > counts[i])
            {
                continue;
            }

            max = counts[i];
            num = i + 1;
        }

        text.text = num.ToString();
    }
}
