using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achive //업적들
    {
        UnLockPotato,
        UnLickBean
    }
    Achive[] achives; // 저장소


    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum 타입 값을 가져온다.

        if (!PlayerPrefs.HasKey("MyData")) //PlayerPrefs에 데이터가 없으면 초기화
        {
            Init();
        }

    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1); // Key Value 로 저장
        // 업적 초기화
        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
/*      
        PlayerPrefs.SetInt("UnLockPotato", 0);
        PlayerPrefs.SetInt("UnLockBean", 0);*/
    }

    private void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter()
    {
        for (int i = 0; i < lockCharacter.Length; i++)
        {
            string achiveName = achives[i].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achiveName) == 1;
            lockCharacter[i].SetActive(!isUnlock);
            unlockCharacter[i].SetActive(isUnlock);
        }
    }

    private void Update()
    {
        
    }
}
