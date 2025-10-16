using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private Button StartButton;
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
            gameManager.DirectionsMonster.SetActive(true);

        }
        else
        {
            Debug.Log("길이 만들어지지 않음");
        }
    }
    
}
