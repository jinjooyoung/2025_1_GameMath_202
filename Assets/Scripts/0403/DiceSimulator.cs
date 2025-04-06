using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSimulator : MonoBehaviour
{
    public int[] counts = new int[6];   // 1~6������ �ֻ��� ���ڰ� ���� ������ŭ ����
    public int trials = 100;
    public int max = 0;         // ���� ���� ���� Ƚ��
    public int num = 0;         // ���������� ������ �ֻ��� ����

    public TextMeshProUGUI text;

    public void RollDiceButton()
    {
        Debug.Log("�ֻ��� ����");
        max = 0;
        num = 0;
        for (int i = 0; i < counts.Length; i++)     // 6�� �ݺ� (����ü) �ʱ�ȭ
        {
            counts[i] = 0;
        }
        for (int i = 0; i < trials; i++)     // 100�� �ݺ�
        {
            int result = Random.Range(1, 7);        // 1���� 6���� ���� ����
            counts[result - 1]++;               // �ش� ���� -1 �ڸ��� counts �迭 ���Ҹ� ++
        }
        for (int i = 0; i < counts.Length; i++)     // 6�� �ݺ� (����ü)
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
