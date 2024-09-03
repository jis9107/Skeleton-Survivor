using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unLockCharacter;

    enum Achive //업적들
    {
        UnLockPotato,
        UnLickBean
    }

    Achive[] achives; // 저장소

    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum 타입 값을 가져온다.
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
