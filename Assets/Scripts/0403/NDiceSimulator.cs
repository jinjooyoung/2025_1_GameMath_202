using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NDiceSimulator : MonoBehaviour
{
    public int face = 6;    // 주사위로 사용할 면의 수

    public int[] counts;        // 1~face까지 나온 횟수 저장
    public int trials = 100;    // 시뮬 횟수
    public int max = 0;         // 가장 많이 나온 횟수
    public int num = 0;         // 최종적으로 보여줄 주사위 숫자

    public TextMeshProUGUI text;        // 숫자 보여줄 텍스트
    public TextMeshProUGUI des;         // 설명 텍스트

    public void RollDiceButton()
    {
        counts = new int[face];

        Debug.Log("주사위 굴림");
        max = 0;
        num = 0;
        for (int i = 0; i < trials; i++)     // 100번 반복
        {
            int result = Random.Range(1, face+1);        // 1부터 face까지 랜덤 숫자
            counts[result - 1]++;               // 해당 숫자 -1 자리의 counts 배열 원소를 ++
        }
        for (int i = 0; i < counts.Length; i++)     // face번 반복 (n면체)
        {
            if (max > counts[i])
            {
                continue;
            }

            max = counts[i];
            num = i + 1;
        }

        text.text = num.ToString();
        des.text = $"Roll dice {trials} times form 1 to {face} | {num} : {max} times";
    }
}
