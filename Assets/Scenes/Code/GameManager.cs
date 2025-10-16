using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject startUiObject; //시작화면 ui
    [SerializeField] public GameObject puzzleObject;  // 미리 배치된 퍼즐 게임 오브젝트
    [SerializeField] public GameObject operationobject; // 조작버튼 오브젝트
    [SerializeField] public GameObject scannerObject;  //맵에 추가되어 있는 퍼즐 오브젝트를 스캔하는 오브젝트

    [SerializeField] public GameObject[] puzzleArray;  //스캔된 퍼즐 오브젝트를 저장하는 배열
    [SerializeField] public Vector3[] puzzleArrayTransform; //스캔된 퍼즐 오브젝트의 좌표값을 저장하는 배열
    [SerializeField] public int arrayScize = 122;   // puzzleArray,puzzleArrayTransform의 배열값을 저장하는 배열

    [SerializeField] public bool puzzleClear = false; //스캔이 끝났는지 확인하는 변수 나중에 이름 변경 예정

    [SerializeField] public bool shufflePossible = true;  //수정중 

    [SerializeField] public GameObject[] directionsArray; //길찾기용 배열

    [SerializeField] public GameObject gameUi; //게임ui

    [SerializeField] public GameObject directionsMonster; //길찾는 몬스터


    void Start()
    {
        puzzleArray = new GameObject[arrayScize];
        puzzleArrayTransform = new Vector3[arrayScize];
        directionsArray = new GameObject[arrayScize];
    }

    public GameObject StartUiObject
    {
        get { return startUiObject; }
        set { value = startUiObject; }
    }

    public GameObject PuzzleObject
    {
        get { return puzzleObject; }
        set { value = puzzleObject; }
    }

    public GameObject Operationobject
    {
        get { return operationobject; }
        set { value = operationobject; }
    }

    public GameObject ScannerObject
    {
        get { return scannerObject; }
        set { value = scannerObject; }
        
    }
    public int ArrayScize
    {
        get { return arrayScize; }
        set { value = arrayScize; }
    }

    public GameObject[] PuzzleArray
    {
        get { return puzzleArray; }
        set { value = puzzleArray; }

    }

    public Vector3[] PuzzleArrayTransform
    {
        get { return puzzleArrayTransform; }
        set { value = puzzleArrayTransform; }
    }

    public bool PuzzleClear
    {
        get { return puzzleClear; }
        set { value = puzzleClear; }

    }
    
    public bool ShufflePossible
    {
        get { return shufflePossible; }
        set { value = shufflePossible; }

    }
    
    public GameObject GameUi
    {
        get { return gameUi; }
        set { value = gameUi; }
    }

    public GameObject DirectionsMonster
    {
        get { return directionsMonster; }
        set { value = directionsMonster; }
    }

    public GameObject[] DirectionsArray
    {
        get { return directionsArray; }
        set { value = directionsArray; }
        
    }

}
