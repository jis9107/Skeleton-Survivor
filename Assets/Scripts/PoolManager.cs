using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 1. 프리팹을 보관할 변수
    public GameObject[] prefabs;

    // 2. 풀 담당을 하는 리스트
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }
}
