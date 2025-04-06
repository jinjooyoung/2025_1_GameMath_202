using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public TextMeshProUGUI resultText;  // ��� ��� �ؽ�Ʈ UI
    public int trials = 100;            // �ùķ��̼� Ƚ�� (��: 1000�� ���� �� Ȯ���� ����)
    public int pullCount = 10;          // �� ���� �̴� Ƚ�� (��: 10ȸ �̱�)

    // ��í ����� ������ ī���� ����
    private int countC = 0;
    private int countB = 0;
    private int countA = 0;
    private int countS = 0;

    private int totalPulls = 0;         // �� ���� Ƚ�� (������)

    // ��í�� �̴� �Լ�
    public void PullGacha(int pullCount)
    {
        resultText.text = "";          // ��� �ؽ�Ʈ �ʱ�ȭ
        this.pullCount = pullCount;
        countC = 0;
        countB = 0;
        countA = 0;
        countS = 0;

        // ���� ���� ���� �� Ȯ�� ���� ����
        for (int i = 0; i < trials; i++)    // �ùķ��̼� ���� Ƚ����ŭ �ݺ�
        {
            for (int j = 0; j < pullCount; j++)     // �� ���࿡�� pullCount��ŭ �̱�
            {
                GetGachaResult(j == pullCount - 1 && pullCount == 10);  // ������ �̱�� A��� �̻� Ȯ��
            }
        }

        // �� ����� Ȯ�� ���
        float totalPulls = pullCount * trials;      // �� �ù� Ƚ��
        float probabilityC = (float)countC / totalPulls;
        float probabilityB = (float)countB / totalPulls;
        float probabilityA = (float)countA / totalPulls;
        float probabilityS = (float)countS / totalPulls;

        // �� ����� ������ pullCount�� �°� ���
        int resultC = Mathf.RoundToInt(probabilityC * pullCount);
        int resultB = Mathf.RoundToInt(probabilityB * pullCount);
        int resultA = Mathf.RoundToInt(probabilityA * pullCount);
        int resultS = Mathf.RoundToInt(probabilityS * pullCount);

        // ���� pullCount�� �ǵ��� ���� (�ݿø��� ���� �� ������ �ٸ� �� �ֱ� ������ ����)
        int totalResult = resultC + resultB + resultA + resultS;
        int difference = pullCount - totalResult;

        // ���̰� ���� ��� (�ݿø����� ���� ����) ���� Ȯ���� ���� ��޿� ���̸�ŭ �߰�
        if (difference != 0)
        {
            // Ȯ���� ���� ���� ����� ã�� ���̸� �߰�
            if (probabilityS >= probabilityA && probabilityS >= probabilityB && probabilityS >= probabilityC)
                resultS += difference;
            else if (probabilityA >= probabilityB && probabilityA >= probabilityC)
                resultA += difference;
            else if (probabilityB >= probabilityC)
                resultB += difference;
            else
                resultC += difference;
        }

        // ��� �ؽ�Ʈ ���
        string resultMessage = "Gacha Results:\n";
        resultMessage += $"S: {resultS}\n";
        resultMessage += $"A: {resultA}\n";
        resultMessage += $"B: {resultB}\n";
        resultMessage += $"C: {resultC}\n";

        // ���� ��� �ؽ�Ʈ�� ���
        resultText.text = resultMessage;

        DisplayProbability();
    }

    // ��í ����� �����ϴ� �Լ� (���� �� ���� ����� ����)
    private void GetGachaResult(bool isLastPull)
    {
        // 10ȸ �̱�� ������ �̱�� A��� �̻� Ȯ��
        if (isLastPull)
        {
            GetGuaranteedGrade();   // ������ �̱⿡�� A��� �̻��� ����
        }
        else
        {
            float randomValue = Random.value;       // 0 ~ 1 ������ ������
            GetGradeByProbability(randomValue);     // ����� ����
        }
    }

    // Ȯ���� �´� ����� �����ϴ� �Լ�
    private void GetGradeByProbability(float randomValue)
    {
        if (randomValue < 0.4f)
        {
            countC++;
        }
        else if (randomValue < 0.7f)
        {
            countB++;
        }
        else if (randomValue < 0.9f)
        {
            countA++;
        }
        else
        {
            countS++;
        }
    }

    // 10ȸ �̱� �� ������ �̱�� A��� �̻� Ȯ��
    private void GetGuaranteedGrade()
    {
        // Ȯ���� A, S ��� �� �ϳ��� ����
        if (Random.value < 0.66f)
        {
            countA++;
        }
        else
        {
            countS++;
        }
    }

    // �������� ������ ���� ����� ���� Ȯ���� �°� ����
    private void GetGradeForUserDisplay()
    {
        resultText.text = "";
        // �� ���� Ƚ�� (�ùķ��̼� ������� ������ ��)
        float total = countC + countB + countA + countS;

        // �� ��޿� �ش��ϴ� ������ ���
        float probabilityC = (float)countC / total;
        float probabilityB = (float)countB / total;
        float probabilityA = (float)countA / total;
        float probabilityS = (float)countS / total;

        // pullCount�� �°� �� ����� �� �� ���� ������ ���
        int countForC = Mathf.FloorToInt(probabilityC * pullCount);
        int countForB = Mathf.FloorToInt(probabilityB * pullCount);
        int countForA = Mathf.FloorToInt(probabilityA * pullCount);
        int countForS = pullCount - (countForC + countForB + countForA);  // ���� ������ S��޿� ����

        // ���� ��� ����Ʈ ����
        //List<string> resultList = new List<string>();

        // �� ��޿� �°� ��� ����Ʈ�� �߰�
        for (int i = 0; i < countForC; i++)
        {
            //resultList.Add("C");
            resultText.text += "C\n";
        }
        for (int i = 0; i < countForB; i++)
        {
            //resultList.Add("B");
            resultText.text += "B\n";
        }
        for (int i = 0; i < countForA; i++)
        {
            //resultList.Add("A");
            resultText.text += "A\n";
        }
        for (int i = 0; i < countForS; i++)
        {
            //resultList.Add("S");
            resultText.text += "S\n";
        }

        /*// ��� ����Ʈ�� �����ϰ� ���� (�������� ������ ������ ��������)
        for (int i = 0; i < resultList.Count; i++)
        {
            string temp = resultList[i];
            int randomIndex = Random.Range(i, resultList.Count);
            resultList[i] = resultList[randomIndex];
            resultList[randomIndex] = temp;
        }*/
    }

    // Ȯ�� ���� ���� ���
    private void DisplayProbability()
    {
        totalPulls = trials * pullCount;  // �� �̱� Ƚ��

        // Ȯ�� ���
        float probC = (float)countC / totalPulls;
        float probB = (float)countB / totalPulls;
        float probA = (float)countA / totalPulls;
        float probS = (float)countS / totalPulls;

        // Ȯ���� �ؽ�Ʈ�� ǥ��
        Debug.Log($"�� {totalPulls}����, {pullCount}�� �̱� | C: {probC * 100}% | B: {probB * 100}% | A: {probA * 100}% | S: {probS * 100}%");
    }
}
