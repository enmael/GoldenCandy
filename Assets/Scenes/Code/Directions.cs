// #region 악 
// // // using System;
// // // using System.Collections;
// // // using System.Collections.Generic;
// // // using UnityEngine;

// // // public class Directions : MonoBehaviour
// // // {
// // //     public GameManager gameManager;

// // //     [SerializeField] float speed = 3.0f;

// // //     [SerializeField] int number = 0;

// // //     [SerializeField] bool arriveBool = true;

// // //     [SerializeField] bool arriveBool1 = true;

// // //     // void OnEnable()
// // //     // {
// // //     //     InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
// // //     // }
// // //     void Update()
// // //     {
// // //         if (arriveBool1 == true)
// // //         {
// // //             InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
// // //         }
// // //         else
// // //         {
// // //             if (number == gameManager.DirectionsNumber - 1)
// // //             {
// // //                 arriveBool = false;
// // //             }
// // //             if (gameManager.DirectionsArray[number].transform.position == gameManager.DirectionsMonster.transform.position && arriveBool == true)
// // //             {
// // //                 number++;

// // //             }
// // //             else
// // //             {
// // //                 Quest(number);
// // //             }

// // //         }

// // //     }

// // //     private void InsertionSort(GameObject[]arr, GameObject standard, int n) // 삽입 정렬 
// // //     {
// // //         for (int i = 1; i < n; i++)
// // //         {
// // //             GameObject temp = arr[i];
// // //             float currentDist = (temp.transform.position - standard.transform.position).sqrMagnitude;

// // //             int j = i - 1;

// // //             // 앞의 값이 현재 값보다 멀다면 뒤로 밀기
// // //             while (j >= 0 && (arr[j].transform.position - standard.transform.position).sqrMagnitude > currentDist)
// // //             {
// // //                 arr[j + 1] = arr[j];
// // //                 j--;
// // //             }
// // //             arr[j + 1] = temp;
// // //         }

// // //         arriveBool1 = false;

// // //     }


// // //     private void Quest(int n)
// // //     {
// // //         Vector2 pos = gameManager.DirectionsArray[n].transform.position;
// // //         Vector2 direction = (gameManager.DirectionsArray[n].transform.position - transform.position).normalized;
// // //         transform.position = Vector2.MoveTowards(transform.position, gameManager.DirectionsArray[n].transform.position, speed * Time.deltaTime);
// // //     }




// // // }
// #endregion

// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;

// public class Directions : MonoBehaviour
// {
//     [Header("연결된 매니저")]
//     public GameManager gameManager;

//     [Header("이동 관련")]
//     [SerializeField] float speed = 3.0f;
//     [SerializeField] int number = 0;
//     [SerializeField] bool arriveBool = true;
//     [SerializeField] bool arriveBool1 = true;

//     void OnEnable()
//     {
//         // 초기화가 아직 안 끝난 경우 대비 → 한 프레임 기다렸다가 실행
//         StartCoroutine(WaitAndSort());
//     }

//     IEnumerator WaitAndSort()
//     {
//         yield return null; // 한 프레임 대기 (GameManager 초기화 완료 대기)

//         if (gameManager == null)
//         {
//             //Debug.LogWarning("[Directions] gameManager가 연결되지 않았습니다!");
//             yield break;
//         }

//         if (gameManager.DirectionsArray == null || gameManager.Candy == null)
//         {
//             //Debug.LogWarning("[Directions] GameManager 내부의 DirectionsArray 또는 Candy가 null입니다!");
//             yield break;
//         }

//         InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
//     }

//     void Update()
//     {
//         // 이미 정렬 완료된 상태가 아니라면, 재정렬 시도
//         if (arriveBool1 && gameManager != null && gameManager.DirectionsArray != null && gameManager.Candy != null)
//         {
//             InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
//         }
//         else
//         {
//             // 목표 지점 도달 체크
//             if (number == gameManager.DirectionsNumber)
//                 arriveBool = false;

//             // 목표 지점에 도달했는지 확인
//             if (gameManager.DirectionsArray[number] != null &&
//                 gameManager.DirectionsMonster != null &&
//                 gameManager.DirectionsArray[number].transform.position == gameManager.DirectionsMonster.transform.position &&
//                 arriveBool)
//             {
//                 number++;
//             }
//             else
//             {
//                 Quest(number);
//             }
//         }
//     }

//     // 삽입 정렬 (기준 오브젝트로부터 가까운 순서대로)
//     private void InsertionSort(GameObject[] arr, GameObject standard, int n)
//     {
//         if (arr == null || standard == null)
//         {
//             Debug.LogWarning("[InsertionSort] 배열 또는 기준 오브젝트가 null입니다!");
//             return;
//         }

//         // null 제거
//         arr = arr.Where(obj => obj != null).ToArray();

//         int length = Mathf.Min(n, arr.Length);

//         for (int i = 1; i < length; i++)
//         {
//             GameObject temp = arr[i];
//             float currentDist = (temp.transform.position - standard.transform.position).sqrMagnitude;

//             int j = i - 1;

//             // 앞의 값이 현재 값보다 멀다면 뒤로 밀기
//             while (j >= 0 && (arr[j].transform.position - standard.transform.position).sqrMagnitude > currentDist)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }
//             arr[j + 1] = temp;
//         }

//         arriveBool1 = false;
//         Debug.Log("[InsertionSort] 정렬 완료!");
//     }

//     // 목표 위치로 이동
//     private void Quest(int n)
//     {
//         if (gameManager == null || gameManager.DirectionsArray == null || n >= gameManager.DirectionsArray.Length)
//             return;

//         if (gameManager.DirectionsArray[n] == null)
//             return;

//         Vector2 targetPos = gameManager.DirectionsArray[n].transform.position;
//         Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
//         transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
//     }
// }
// #region 수정안 
// // using System.Collections;
// // using System.Collections.Generic;
// // using System.Linq;
// // using UnityEngine;

// // public class Directions : MonoBehaviour
// // {
// //     [Header("연결된 매니저")]
// //     public GameManager gameManager;

// //     [Header("이동 관련")]
// //     [SerializeField] float speed = 3.0f;
// //     [SerializeField] int number = 0;
// //     [SerializeField] bool arriveBool = true;
// //     [SerializeField] bool arriveBool1 = true;

// //     [SerializeField] Vector2 startPos;

// //     void OnEnable()
// //     {
// //         // 초기화가 아직 안 끝난 경우 대비 → 한 프레임 기다렸다가 실행
// //         StartCoroutine(WaitAndSort());
// //     }

// //     void Start()
// //     {
// //         startPos = gameManager.DirectionsMonster.transform.position;
// //     }

// //     IEnumerator WaitAndSort()
// //     {
// //         yield return null; // 한 프레임 대기 (GameManager 초기화 완료 대기)

// //         if (gameManager == null)
// //         {
// //             //Debug.LogWarning("[Directions] gameManager가 연결되지 않았습니다!");
// //             yield break;
// //         }

// //         if (gameManager.DirectionsArray == null || gameManager.Candy == null)
// //         {
// //             //Debug.LogWarning("[Directions] GameManager 내부의 DirectionsArray 또는 Candy가 null입니다!");
// //             yield break;
// //         }

// //         InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
// //     }

// //     void Update()
// //     {
// //         // 이미 정렬 완료된 상태가 아니라면, 재정렬 시도
// //         if (arriveBool1 && gameManager != null && gameManager.DirectionsArray != null && gameManager.Candy != null)
// //         {
// //             InsertionSort(gameManager.DirectionsArray, gameManager.Candy, gameManager.DirectionsNumber);
// //         }
// //         else
// //         {
// //             // 목표 지점 도달 체크
// //             if (number == gameManager.DirectionsNumber - 1)
// //                 arriveBool = false;

// //             // 목표 지점에 도달했는지 확인
// //             if (gameManager.DirectionsArray[number] != null &&
// //                 gameManager.DirectionsMonster != null &&
// //                 gameManager.DirectionsArray[number].transform.position == gameManager.DirectionsMonster.transform.position &&
// //                 arriveBool)
// //             {
// //                 number++;
// //             }
// //             else
// //             {
// //                 Quest(number);
// //             }
// //         }
// //     }

// //     // 삽입 정렬 (기준 오브젝트로부터 가까운 순서대로)
// //     private void InsertionSort(GameObject[] arr, GameObject standard, int n)
// //     {
// //         if (arr == null || standard == null)
// //         {
// //             //Debug.LogWarning("[InsertionSort] 배열 또는 기준 오브젝트가 null입니다!");
// //             return;
// //         }

// //         // null 제거
// //         arr = arr.Where(obj => obj != null).ToArray();

// //         int length = Mathf.Min(n, arr.Length);

// //         for (int i = 1; i < length; i++)
// //         {
// //             GameObject temp = arr[i];
// //             float currentDist = (temp.transform.position - standard.transform.position).sqrMagnitude;

// //             int j = i - 1;

// //             // 앞의 값이 현재 값보다 멀다면 뒤로 밀기
// //             while (j >= 0 && (arr[j].transform.position - standard.transform.position).sqrMagnitude > currentDist)
// //             {
// //                 arr[j + 1] = arr[j];
// //                 j--;
// //             }
// //             arr[j + 1] = temp;
// //         }

// //         // 🔍 정렬된 오브젝트 간 거리 검사
// //         for (int i = 0; i < length - 1; i++)
// //         {
// //             if (arr[i] == null || arr[i + 1] == null) continue;

// //             float dist = Vector3.Distance(arr[i].transform.position, arr[i + 1].transform.position);
// //             if (dist > 1f)
// //             {
// //                 //Debug.LogError($"[Directions] 오류 발생: {arr[i].name} 과 {arr[i + 1].name} 사이 거리 {dist:F2} > 1");
// //                 //비활성화된 퍼즐 오브젝트 몽땅 활성화 하고

// //                 //게임 매니저 number , number 초기화 
// //                 gameManager.DirectionsNumber = 0;
// //                 number = 0;

// //                 //배열 전체 초기화 를 넣어야함
// //                 // for (int z = 0; z < gameManager.DirectionsArray.Length; z++)
// //                 // {
// //                 //     Destroy(gameManager.DirectionsArray[z]);
// //                 //     gameManager.DirectionsArray[z] = null;
// //                 // }
// //                 // // 초기 위치로 이동하기.
// //                 // gameManager.DirectionsMonster.transform.position = startPos;
// //                 // // 코드 비활성화 처리하기.
// //                 // gameManager.DirectionsMonster.SetActive(false);
// //             }
// //         }

// //         arriveBool1 = false;
// //         //Debug.Log("[InsertionSort] 정렬 및 거리 검사 완료!");
// //     }

// //     // 목표 위치로 이동
// //     private void Quest(int n)
// //     {
// //         if (gameManager == null || gameManager.DirectionsArray == null || n >= gameManager.DirectionsArray.Length)
// //             return;

// //         if (gameManager.DirectionsArray[n] == null)
// //             return;

// //         Vector2 targetPos = gameManager.DirectionsArray[n].transform.position;
// //         Vector2 direction = (targetPos - (Vector2)transform.position).normalized;
// //         transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
// //     }
// // }
// #endregion

