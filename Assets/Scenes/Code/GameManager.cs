/*
 * ============================================================
 * 파일 이름 : GameManager.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-16
 * 설명     : 중복되어 사용되는 게임 오브젝트를 관리하는 GameManager 클래스.
 * ============================================================
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
[Header("UI")]
[SerializeField] public GameObject startUiObject;     // 시작화면 UI
[SerializeField] public GameObject gameUi;            // 게임 UI

[Header("게임 오브젝트")]
[SerializeField] public GameObject puzzleObject;      // 미리 배치된 퍼즐 오브젝트
[SerializeField] public GameObject candy;             // 캔디 오브젝트
[SerializeField] public GameObject operationobject;   // 조작버튼 오브젝트
[SerializeField] public GameObject scannerObject;     // 퍼즐 스캔용 오브젝트
[SerializeField] public GameObject inspection;        // 검사 오브젝트

[Header("퍼즐 관련")]
[SerializeField] public GameObject[] puzzleArray;         // 스캔된 퍼즐 오브젝트 배열
[SerializeField] public Vector3[] puzzleArrayTransform;   // 스캔된 퍼즐 좌표값 배열
[SerializeField] public int arrayScize = 122;             // 배열 크기

[Header("길찾기 관련")]
[SerializeField] public GameObject[] directionsArray;     // 길찾기용 배열
[SerializeField] public GameObject directionsMonster;     // 길찾기용 몬스터
[SerializeField] public int directionsNumber;              // 길찾기용 인덱스 번호

[Header("상태 변수")]
[SerializeField] public bool puzzleClear = false;         // 스캔 완료 여부 (이름 변경 예정)
[SerializeField] public bool shufflePossible = true;      // 셔플 가능 여부
[SerializeField] public bool sortInspection = false;      // 정렬 검사 여부

    void Start()
    {
        puzzleArray = new GameObject[arrayScize];
        puzzleArrayTransform = new Vector3[arrayScize];
        directionsArray = new GameObject[arrayScize];
    }

    public GameObject StartUiObject
    {
        get { return startUiObject; }
        set { startUiObject = value; }
    }

    public GameObject PuzzleObject
    {
        get { return puzzleObject; }
        set { puzzleObject = value; }
    }

    public GameObject Operationobject
    {
        get { return operationobject; }
        set { operationobject = value; }
    }

    public GameObject ScannerObject
    {
        get { return scannerObject; }
        set { scannerObject = value; }
    }

    public int ArrayScize
    {
        get { return arrayScize; }
        set { arrayScize = value; }
    }

    public GameObject[] PuzzleArray
    {
        get { return puzzleArray; }
        set { puzzleArray = value; }
    }

    public Vector3[] PuzzleArrayTransform
    {
        get { return puzzleArrayTransform; }
        set { puzzleArrayTransform = value; }
    }

    public bool PuzzleClear
    {
        get { return puzzleClear; }
        set { puzzleClear = value; }
    }

    public bool ShufflePossible
    {
        get { return shufflePossible; }
        set { shufflePossible = value; }
    }

    public GameObject GameUi
    {
        get { return gameUi; }
        set { gameUi = value; }
    }

    public GameObject DirectionsMonster
    {
        get { return directionsMonster; }
        set { directionsMonster = value; }
    }

    public GameObject[] DirectionsArray
    {
        get { return directionsArray; }
        set { directionsArray = value; }
    }

    public int DirectionsNumber
    {
        get { return directionsNumber; }
        set { directionsNumber = value; }
    }

    public GameObject Candy
    {
        get { return candy; }
        set { candy = value; }
    }

    public GameObject Inspection
    {
        get { return inspection; }
        set { inspection = value; }
    }

    public bool SortInspection
    {
        get { return sortInspection; }
        set { sortInspection = value; }
    }
}

