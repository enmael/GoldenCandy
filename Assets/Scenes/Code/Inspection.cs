/*
 * ============================================================
 * 파일 이름 : Inspection.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-24
 * 설명     : 생성된 길 배열에 문제가 있는지 확인하는 코드 문제가 있으면 초기화 해버린다. 
 * ============================================================
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class Inspection : MonoBehaviour
{
    [Header("연결된 매니저")]
    public GameManager gameManager;
    void Update()
    {
        if (gameManager.SortInspection == true)
        {
            CheckDistance(gameManager.directionsArray, gameManager.DirectionsNumber);
        }
    }

    public void CheckDistance(GameObject[] arr, int n)
    {
        bool a = true;
        for (int i = 0; i < n - 1; i++)
        {
            float d = (arr[i].transform.position - arr[i + 1].transform.position).sqrMagnitude;
            if (d > 1f)
            {
                VariableReset();
                a = false;
                break;
            }
        }
        if (a == true)
        {
            arr[n] = gameManager.Candy;
        }
    }
    
    private void VariableReset()
    {
        for (int i = 0; i < gameManager.DirectionsNumber; i++)
        {
            Destroy(gameManager.DirectionsArray[i]);
            gameManager.DirectionsArray[i] = null;
        }
        
        gameManager.DirectionsNumber = 0;
        gameManager.SortInspection = false;
        gameManager.Inspection.SetActive(false);
        
    }
}
