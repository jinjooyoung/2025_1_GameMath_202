using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// �ֻ����� Ȯ�� �ڵ� ó�� trials �� ���������� ���ϴ� Ȯ���� ����� ���� ������ �ٺ������� ��¦ �ٸ�
// �ֻ��� : �ټ��� �õ��� ���� Ȯ���� ���������� ���߷��� ���
// ġ��Ÿ : ���� ������ ����� ���� Ȯ���� �����ϰ� �� ������ Ȯ���� ���� ���� ���ݿ��� ġ��Ÿ�� �߻����� ������ �����ϴ� ���
public class Critical : MonoBehaviour
{
    public TextMeshProUGUI crtText;         // ��� ��� �ؽ�Ʈ UI

    private int crtHits = 0;                // ���� ġ��Ÿ �߻� Ƚ��
    private int totalHits = 0;              // ������� ������ Ƚ��
    public int trials = 100;                // �õ� �� ��ü ���� Ƚ��
    public float criticalChance = 0.1f;     // ġ��Ÿ Ȯ��
    private bool lastHitCritical = false;   // ���� ������ ġ��Ÿ ����
    

    // ġ��Ÿ �ùķ��̼� ����
    public void RunSimulation()
    {
        crtHits = 0;        // ġ��Ÿ �߻� Ƚ�� �ʱ�ȭ
        totalHits = 0;      // ��ü ���� Ƚ�� �ʱ�ȭ

        for (int i = 0; i < trials; i++)
        {
            if (SimulateCritical())     // ġ��Ÿ �߻� ���� Ȯ��
            {
                crtHits++;              // ġ��Ÿ �߻��� ī��Ʈ
            }
            totalHits++;                // ���� Ƚ�� ����
        }

        // ġ��Ÿ �߻��� ���
        float criticalRate = (float)crtHits / totalHits * 100f;
        crtText.text = $"Critical ! : {crtHits} / {totalHits}\nCriticalRate : {criticalRate:F2}%";  // UI ������Ʈ
    }

    // ġ��Ÿ �߻� ���� �ùķ��̼�
    private bool SimulateCritical()
    {
        // ��ü ���� Ƚ���� ���� ġ��Ÿ �߻���
        float criticalRate = (float)crtHits / totalHits;

        // "ġ��Ÿ�� �߻��� �Ŀ��� 10%�� �ȳѰ� �ȴٸ�, ������ �߻�" ����
        if (lastHitCritical && criticalRate <= 0.1f)
        {
            // ������ ġ��Ÿ �߻�
            lastHitCritical = true;
            return true;
        }

        // "ġ��Ÿ�� �߻����� �ʾ��� �� 10%�� �Ѱ� �ȴٸ�, ������ �߻����� �ʵ���" ����
        if (!lastHitCritical && criticalRate > 0.1f)
        {
            // ������ ġ��Ÿ �߻� X
            lastHitCritical = false;
            return false;
        }

        // "���� ��찡 �ƴ϶�� 10% ������ ���" ����
        if (Random.value < criticalChance)
        {
            lastHitCritical = true;
            return true;
        }
        else
        {
            lastHitCritical = false;
            return false;
        }
    }
}
