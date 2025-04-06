using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// 주사위의 확률 코드 처럼 trials 가 높아질수록 원하는 확률에 가까워 지긴 하지만 근본적으로 살짝 다름
// 주사위 : 다수의 시도를 통해 확률을 실험적으로 맞추려는 방식
// 치명타 : 직전 공격의 결과에 따라 확률을 보정하고 그 조정된 확률에 따라 다음 공격에서 치명타가 발생할지 말지를 결정하는 방식
public class Critical : MonoBehaviour
{
    public TextMeshProUGUI crtText;         // 결과 출력 텍스트 UI

    private int crtHits = 0;                // 현재 치명타 발생 횟수
    private int totalHits = 0;              // 현재까지 공격한 횟수
    public int trials = 100;                // 시도 할 전체 공격 횟수
    public float criticalChance = 0.1f;     // 치명타 확률
    private bool lastHitCritical = false;   // 직전 공격의 치명타 여부
    

    // 치명타 시뮬레이션 실행
    public void RunSimulation()
    {
        crtHits = 0;        // 치명타 발생 횟수 초기화
        totalHits = 0;      // 전체 공격 횟수 초기화

        for (int i = 0; i < trials; i++)
        {
            if (SimulateCritical())     // 치명타 발생 여부 확인
            {
                crtHits++;              // 치명타 발생시 카운트
            }
            totalHits++;                // 공격 횟수 증가
        }

        // 치명타 발생률 계산
        float criticalRate = (float)crtHits / totalHits * 100f;
        crtText.text = $"Critical ! : {crtHits} / {totalHits}\nCriticalRate : {criticalRate:F2}%";  // UI 업데이트
    }

    // 치명타 발생 여부 시뮬레이션
    private bool SimulateCritical()
    {
        // 전체 공격 횟수에 따른 치명타 발생률
        float criticalRate = (float)crtHits / totalHits;

        // "치명타가 발생한 후에도 10%가 안넘게 된다면, 무조건 발생" 조건
        if (lastHitCritical && criticalRate <= 0.1f)
        {
            // 무조건 치명타 발생
            lastHitCritical = true;
            return true;
        }

        // "치명타가 발생하지 않았을 때 10%를 넘게 된다면, 무조건 발생하지 않도록" 조건
        if (!lastHitCritical && criticalRate > 0.1f)
        {
            // 무조건 치명타 발생 X
            lastHitCritical = false;
            return false;
        }

        // "위의 경우가 아니라면 10% 쌩으로 계산" 조건
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
