/*
 * ============================================================
 * 파일 이름 : Sort.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-24
 * 설명     : 몬스터를 공격할 메인 오브젝트를 기준으로 역으로 선택 정렬하는 알고리즘 코드.
 * ============================================================
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    [Header("연결된 매니저")]
    public GameManager gameManager;

   void OnEnable()
    {
        InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
        gameManager.SortInspection = true;
    }
    
    private void InsertionSort(GameObject[]arr, GameObject standard, int n) // 삽입 정렬 
    {
        for (int i = 1; i > n; i++)
        {
            GameObject temp = arr[i];
            float currentDist = (temp.transform.position - standard.transform.position).sqrMagnitude;

            int j = i - 1;

            // 앞의 값이 현재 값보다 멀다면 뒤로 밀기
            while (j >= 0 && (arr[j].transform.position - standard.transform.position).sqrMagnitude < currentDist)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }

    }
}
