/*
 * ============================================================
 * 파일 이름 : Shuffle.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-16
 * 설명     : 피셔 에이츠 셔플을 활용해서 오브젝트의 위치를 셔플 하는 코드
 * ============================================================
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [Header("연결된 매니저")]
    public GameManager gameManager;

    private System.Random rnd = new System.Random();

    [SerializeField] public bool shuffleGANEUNG = true;
    void Update()
    {
        if(shuffleGANEUNG == true && gameManager.PuzzleClear ==true)
        {
            FisherShuffle();
            shuffleGANEUNG = false;
            gameManager.ShufflePossible = false;  
            //ShufflePossible   
        }
    }


    public void FisherShuffle()
    {
        for (int i = gameManager.ArrayScize - 1; i > 0; i--)
        {
            int value = rnd.Next(0, i + 1);

            Vector3 tempPos = gameManager.PuzzleArrayTransform[i];

            gameManager.PuzzleArrayTransform[i] = gameManager.PuzzleArrayTransform[value];
            gameManager.PuzzleArrayTransform[value] = tempPos;

        }

        for (int v = 0; v < gameManager.ArrayScize; v++)
        {
            gameManager.PuzzleArray[v].transform.position = gameManager.PuzzleArrayTransform[v];

        }

    }
}
