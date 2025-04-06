using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NDiceSimulator : MonoBehaviour
{
    public int face = 6;    // �ֻ����� ����� ���� ��

    public int[] counts;        // 1~face���� ���� Ƚ�� ����
    public int trials = 100;    // �ù� Ƚ��
    public int max = 0;         // ���� ���� ���� Ƚ��
    public int num = 0;         // ���������� ������ �ֻ��� ����

    public TextMeshProUGUI text;        // ���� ������ �ؽ�Ʈ
    public TextMeshProUGUI des;         // ���� �ؽ�Ʈ

    public void RollDiceButton()
    {
        counts = new int[face];

        Debug.Log("�ֻ��� ����");
        max = 0;
        num = 0;
        for (int i = 0; i < trials; i++)     // 100�� �ݺ�
        {
            int result = Random.Range(1, face+1);        // 1���� face���� ���� ����
            counts[result - 1]++;               // �ش� ���� -1 �ڸ��� counts �迭 ���Ҹ� ++
        }
        for (int i = 0; i < counts.Length; i++)     // face�� �ݺ� (n��ü)
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
