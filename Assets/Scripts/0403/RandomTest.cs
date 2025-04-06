using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomTest : MonoBehaviour
{
    public TextMeshProUGUI[] labels = new TextMeshProUGUI[6];
    public int[] counts = new int[6];   // 1~6까지의 주사위 숫자가 나온 갯수만큼 저장
    public int trials = 100;

    private void Start()
    {
        for (int i = 0; i< trials; i++)     // 100번 반복
        {
            int result = Random.Range(1, 7);        // 1부터 6까지 랜덤 숫자
            counts[result - 1]++;               // 해당 숫자 -1 자리의 counts 배열 원소를 ++
        }
        for (int i = 0; i < counts.Length; i++)     // 6번 반복 (육면체)
        {
            float percent = (float)counts[i] / trials * 100;    // 해당 숫자가 나온 확률(비율) 구하기
            string result = $"{i + 1}: {counts[i]}회 {percent:F2}%";     // 무슨 숫자가 몇 번 나왔고 몇 퍼센트의 확률인지 소수점 두 번째 자리까지 string으로 나타냄
            labels[i].text = result;        // UI로 result를 보여줌
        }
    }
}
