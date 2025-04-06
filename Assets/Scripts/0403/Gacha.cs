using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public TextMeshProUGUI resultText;  // 결과 출력 텍스트 UI
    public int trials = 100;            // 시뮬레이션 횟수 (예: 1000번 시행 후 확률을 보정)
    public int pullCount = 10;          // 한 번에 뽑는 횟수 (예: 10회 뽑기)

    // 가챠 결과를 추적할 카운터 변수
    private int countC = 0;
    private int countB = 0;
    private int countA = 0;
    private int countS = 0;

    private int totalPulls = 0;         // 총 뽑은 횟수 (디버깅용)

    // 가챠를 뽑는 함수
    public void PullGacha(int pullCount)
    {
        resultText.text = "";          // 결과 텍스트 초기화
        this.pullCount = pullCount;
        countC = 0;
        countB = 0;
        countA = 0;
        countS = 0;

        // 여러 번의 시행 후 확률 보정 시작
        for (int i = 0; i < trials; i++)    // 시뮬레이션 시행 횟수만큼 반복
        {
            for (int j = 0; j < pullCount; j++)     // 각 시행에서 pullCount만큼 뽑기
            {
                GetGachaResult(j == pullCount - 1 && pullCount == 10);  // 마지막 뽑기는 A등급 이상 확정
            }
        }

        // 각 등급의 확률 계산
        float totalPulls = pullCount * trials;      // 총 시뮬 횟수
        float probabilityC = (float)countC / totalPulls;
        float probabilityB = (float)countB / totalPulls;
        float probabilityA = (float)countA / totalPulls;
        float probabilityS = (float)countS / totalPulls;

        // 각 등급의 갯수를 pullCount에 맞게 계산
        int resultC = Mathf.RoundToInt(probabilityC * pullCount);
        int resultB = Mathf.RoundToInt(probabilityB * pullCount);
        int resultA = Mathf.RoundToInt(probabilityA * pullCount);
        int resultS = Mathf.RoundToInt(probabilityS * pullCount);

        // 합이 pullCount가 되도록 조정 (반올림을 했을 때 총합이 다를 수 있기 때문에 조정)
        int totalResult = resultC + resultB + resultA + resultS;
        int difference = pullCount - totalResult;

        // 차이가 생긴 경우 (반올림으로 인한 차이) 가장 확률이 높은 등급에 차이만큼 추가
        if (difference != 0)
        {
            // 확률이 가장 높은 등급을 찾아 차이를 추가
            if (probabilityS >= probabilityA && probabilityS >= probabilityB && probabilityS >= probabilityC)
                resultS += difference;
            else if (probabilityA >= probabilityB && probabilityA >= probabilityC)
                resultA += difference;
            else if (probabilityB >= probabilityC)
                resultB += difference;
            else
                resultC += difference;
        }

        // 결과 텍스트 출력
        string resultMessage = "Gacha Results:\n";
        resultMessage += $"S: {resultS}\n";
        resultMessage += $"A: {resultA}\n";
        resultMessage += $"B: {resultB}\n";
        resultMessage += $"C: {resultC}\n";

        // 최종 결과 텍스트로 출력
        resultText.text = resultMessage;

        DisplayProbability();
    }

    // 가챠 결과를 결정하는 함수 (리턴 값 없이 결과만 추적)
    private void GetGachaResult(bool isLastPull)
    {
        // 10회 뽑기시 마지막 뽑기는 A등급 이상 확정
        if (isLastPull)
        {
            GetGuaranteedGrade();   // 마지막 뽑기에서 A등급 이상을 보장
        }
        else
        {
            float randomValue = Random.value;       // 0 ~ 1 사이의 랜덤값
            GetGradeByProbability(randomValue);     // 결과를 추적
        }
    }

    // 확률에 맞는 결과를 추적하는 함수
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

    // 10회 뽑기 시 마지막 뽑기는 A등급 이상 확정
    private void GetGuaranteedGrade()
    {
        // 확정된 A, S 등급 중 하나를 리턴
        if (Random.value < 0.66f)
        {
            countA++;
        }
        else
        {
            countS++;
        }
    }

    // 유저에게 보여줄 최종 등급을 실제 확률에 맞게 리턴
    private void GetGradeForUserDisplay()
    {
        resultText.text = "";
        // 총 뽑은 횟수 (시뮬레이션 결과에서 추적한 것)
        float total = countC + countB + countA + countS;

        // 각 등급에 해당하는 비율을 계산
        float probabilityC = (float)countC / total;
        float probabilityB = (float)countB / total;
        float probabilityA = (float)countA / total;
        float probabilityS = (float)countS / total;

        // pullCount에 맞게 각 등급을 몇 번 뽑을 것인지 계산
        int countForC = Mathf.FloorToInt(probabilityC * pullCount);
        int countForB = Mathf.FloorToInt(probabilityB * pullCount);
        int countForA = Mathf.FloorToInt(probabilityA * pullCount);
        int countForS = pullCount - (countForC + countForB + countForA);  // 남은 개수는 S등급에 배정

        // 뽑을 등급 리스트 생성
        //List<string> resultList = new List<string>();

        // 각 등급에 맞게 결과 리스트에 추가
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

        /*// 결과 리스트를 랜덤하게 섞기 (유저에게 보여줄 순서는 랜덤으로)
        for (int i = 0; i < resultList.Count; i++)
        {
            string temp = resultList[i];
            int randomIndex = Random.Range(i, resultList.Count);
            resultList[i] = resultList[randomIndex];
            resultList[randomIndex] = temp;
        }*/
    }

    // 확률 보정 상태 출력
    private void DisplayProbability()
    {
        totalPulls = trials * pullCount;  // 총 뽑기 횟수

        // 확률 계산
        float probC = (float)countC / totalPulls;
        float probB = (float)countB / totalPulls;
        float probA = (float)countA / totalPulls;
        float probS = (float)countS / totalPulls;

        // 확률을 텍스트로 표시
        Debug.Log($"총 {totalPulls}시행, {pullCount}개 뽑기 | C: {probC * 100}% | B: {probB * 100}% | A: {probA * 100}% | S: {probS * 100}%");
    }
}
