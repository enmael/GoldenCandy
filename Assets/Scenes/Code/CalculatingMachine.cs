using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatingMachine : MonoBehaviour
{
    [Header("연결된 매니저")]
    [SerializeField]public GameObject A;
    [SerializeField]public GameObject B;

    void Update()
    {
        float dist = (A.transform.position - B.transform.position).sqrMagnitude;
        Debug.Log("사이 거리 :" + dist);  
    }
}
