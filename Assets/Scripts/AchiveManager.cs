using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;
    public GameObject uiNotice;
    

    enum Achive //업적들
    {
        UnLockPotato,
        UnLickBean
    }
    Achive[] achives; // 저장소
    // Coroutine을 사용할 때 메모리 낭비를 방지하기 위해 미리 선언 (메모리 최적화)
    // TimeScale의 영향을 받지 않게 하기 위해서 Realtime 사용
    WaitForSecondsRealtime wait;


    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum 타입 값을 가져온다.
        wait = new WaitForSecondsRealtime(5);
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

    private void LateUpdate()
    {
        foreach (Achive achive in achives)
        {
            CheckAchive(achive);
        }
    }

    void CheckAchive(Achive achive)
    {
        bool isAchive = false;

        switch (achive)
        {
            case Achive.UnLockPotato:
                isAchive = GameManager.instance.kill >= 10;
                break;

            case Achive.UnLickBean:
                isAchive = GameManager.instance.gameTime == GameManager.instance.maxGameTime;
                break;
        }

        // isAchive가 true 상태이고 PlayerPrefs 에 achive가 0일 때 (해금이 안되어 있을 때)
        if(isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1); // 해금 
            
            for(int i = 0; i < uiNotice.transform.childCount; i++)
            {
                isAchive = i == (int)achive;
                uiNotice.transform.GetChild(i).gameObject.SetActive(isAchive);
            }

            StartCoroutine(NoticeRoutine());
        }
    }

    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);

        yield return wait;

        uiNotice.SetActive(false);
    }
}
