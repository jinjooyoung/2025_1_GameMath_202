using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomTest : MonoBehaviour
{
    public TextMeshProUGUI[] labels = new TextMeshProUGUI[6];
    public int[] counts = new int[6];   // 1~6������ �ֻ��� ���ڰ� ���� ������ŭ ����
    public int trials = 100;

    private void Start()
    {
        for (int i = 0; i< trials; i++)     // 100�� �ݺ�
        {
            int result = Random.Range(1, 7);        // 1���� 6���� ���� ����
            counts[result - 1]++;               // �ش� ���� -1 �ڸ��� counts �迭 ���Ҹ� ++
        }
        for (int i = 0; i < counts.Length; i++)     // 6�� �ݺ� (����ü)
        {
            float percent = (float)counts[i] / trials * 100;    // �ش� ���ڰ� ���� Ȯ��(����) ���ϱ�
            string result = $"{i + 1}: {counts[i]}ȸ {percent:F2}%";     // ���� ���ڰ� �� �� ���԰� �� �ۼ�Ʈ�� Ȯ������ �Ҽ��� �� ��° �ڸ����� string���� ��Ÿ��
            labels[i].text = result;        // UI�� result�� ������
        }
    }
}
