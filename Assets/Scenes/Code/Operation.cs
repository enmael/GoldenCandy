/*
 * ============================================================
 * 파일 이름 : Operation.cs
 * 작성자   : enmael
 * 생성 날짜 : 2025-10-16
 * 설명     : 방향키로 오브젝트를 조작하고 x키로 오브젝트 삭제, 그리고 길 배열 만듬.
 * ============================================================
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    [Header("연결된 매니저")]
    public GameManager gameManager;

    [Header("조작 관련된 변수")]
    [SerializeField] float posX = 1f;
    [SerializeField] float posY = 1f;
    [SerializeField] bool cont = false;

    [Header("추가 관련 변수")]
    [SerializeField] Vector3 pos;
    [SerializeField] GameObject createdObject;


    private bool hasSpawned = false; // 한 번 생성 여부 체크

    void Update()
    {
        pos = transform.position;

        // 방향키 한 칸씩 이동
        if (Input.GetKeyDown(KeyCode.UpArrow)) { pos.y += posY; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { pos.y -= posY; }
        if (Input.GetKeyDown(KeyCode.RightArrow)) { pos.x += posX; }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { pos.x -= posX; }

        transform.position = pos;

        // X키 입력 처리
        if (Input.GetKey(KeyCode.X))
        {
            if (hasSpawned == false)
            {
                SpawnObject();
                cont = true;
                hasSpawned = true; // 한 번 생성 후 다시 생성 막음
            }
        }
        else
        {
            cont = false;
            hasSpawned = false; // 키를 떼면 다시 생성 가능
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPos = pos;

        // 생성된 오브젝트 인스턴스를 변수에 저장
        GameObject newObj = Instantiate(createdObject, spawnPos, Quaternion.identity);
        string baseName = createdObject.name;
        newObj.name = baseName + "_" + gameManager.DirectionsNumber;
        // 배열에 생성된 오브젝트 인스턴스를 저장
        gameManager.DirectionsArray[gameManager.DirectionsNumber] = newObj;
        

        gameManager.DirectionsNumber++;
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        if (cont && collision.CompareTag("Puzzle"))
        {
            collision.gameObject.SetActive(false);
            
        }
    }
}
