/*
 * ============================================================
 * 파일 이름 : Scanner.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-16
 * 설명     : 오브젝트를 이동시켜 배열에 넣을 퍼즐 오브젝트를 스캔하여 넣는 코드.
 * ============================================================
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

    [Header("연결된 매니저")]
    public GameManager gameManager;

    [Header("스캔 관련 변수")]
    [SerializeField] int number = 0;
    public float speed = 1f; 
    
    void Update()
    {
        if (transform.position.y < 3)
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }

        if(gameManager.ArrayScize  == number)
        {
            gameManager.puzzleClear = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (number < gameManager.PuzzleArray.Length)
        {
            if (collision.CompareTag("Puzzle") || collision.CompareTag("Candy"))
            {
                gameManager.puzzleArray[number] = collision.gameObject;
                gameManager.puzzleArrayTransform[number]= collision.gameObject.transform.position;
                number++;

            }
        }
    }
}
