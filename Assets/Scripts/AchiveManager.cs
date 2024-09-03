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

    void Init()
    {

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
/*        PlayerPrefs.SetInt("MyData", 1); // Key Value 로 저장
        PlayerPrefs.SetInt("UnLockPotato", 0);
        PlayerPrefs.SetInt("UnLockBean", 0);*/
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
