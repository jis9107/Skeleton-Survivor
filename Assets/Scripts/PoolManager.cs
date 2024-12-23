using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 1. 프리팹을 보관할 변수
    public GameObject[] prefabs;

    // 2. 풀 담당을 하는 리스트
    List<GameObject>[] pools;

    private void Awake() // 풀 매니저에 등록되어 있는 프리팹을 리스트에 초기화
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) // 메모리 절약 함수
    {
        GameObject select = null;

        // 선택한 풀의 놀고(비활성화) 있는 게임 오브젝트 접근
            // 발견하면 select 변수에 할당

        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못 찾았다면? (모두 활성화 상태)
            // 새롭게 생성하고 select 변수에 할당
        if(!select) // select == null
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
