/*
 * ============================================================
 * 파일 이름 : UiManager.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-16
 * 설명     :게임 ui를 관리하는 코드이다.
 * ============================================================
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("연결된 매니저")]
    public GameManager gameManager;

    [Header("시작 버튼")]
    [SerializeField] private Button StartButton;
    
    [Header("방어 시작 버튼")]
    [SerializeField] private Button GameButton;

   void Start()
    {
        StartButton.onClick.AddListener(OnClickGameStart);
        GameButton.onClick.AddListener(OnClickGameUi);
    }

    public void OnClickGameStart()
    {
        gameManager.StartUiObject.SetActive(false);
        gameManager.Operationobject.SetActive(true);
        gameManager.PuzzleObject.SetActive(true);
        gameManager.ScannerObject.SetActive(true);
        gameManager.GameUi.SetActive(true);
    }

    public void OnClickGameUi()
    {
        if (gameManager.DirectionsArray[0] != null)
        {
            //gameManager.DirectionsArray[gameManager.DirectionsNumber] = gameManager.Candy;
            gameManager.Inspection.SetActive(true);

        }
        else
        {
            Debug.Log("길이 만들어지지 않음");
        }
    }
    
}
