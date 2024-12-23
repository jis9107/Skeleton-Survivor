using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject dataManager;

    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    public GameObject[] rewards;

    public GameObject uiNotice;

    DataManager data;
    

    enum Achive //캐릭터 해금 업적들
    {
        UnLockChar_2,
        UnLockChar_3,
    }

    enum MissionAchive // 미션 달성 업적들
    {
        KillAhcive,
        MoneyAchive,
        TimeAchive
    }

    MissionAchive[] missionAchives; // 미션 달성 업적 저장소
    Achive[] achives; // 저장소
    // Coroutine을 사용할 때 메모리 낭비를 방지하기 위해 미리 선언 (메모리 최적화)
    // TimeScale의 영향을 받지 않게 하기 위해서 Realtime 사용
    WaitForSecondsRealtime wait;


    private void Awake()
    {
        data = dataManager.GetComponent<DataManager>();

        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum 타입 값을 가져온다.
        missionAchives = (MissionAchive[])Enum.GetValues(typeof(MissionAchive));

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

        foreach(MissionAchive mission in missionAchives)
        {
            PlayerPrefs.SetInt(mission.ToString(), 0);
        }
    }

    private void Start()
    {
        UnlockCharacter();

        foreach (MissionAchive mission in missionAchives)
        {
            CheckMission(mission);
        }

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
            case Achive.UnLockChar_2:
                isAchive = GameManager.instance.kill >= 5000;
                break;

            case Achive.UnLockChar_3:
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

    void CheckMission(MissionAchive mission)
    {
        bool isAchive = false;

        switch(mission)
        {
            case MissionAchive.KillAhcive:
                isAchive = data.totalKill >= data.missionkill;
                if(isAchive)
                    rewards[0].SetActive(true);
                break;

            case MissionAchive.MoneyAchive:
                isAchive = data.totalMoney >= data.missionMoney;
                if (isAchive)
                    rewards[1].SetActive(true);
                break;

            case MissionAchive.TimeAchive:
                isAchive = data.totalPlayTime >= data.missionTime;
                if (isAchive)
                    rewards[2].SetActive(true);
                break;
        }
    }
    

/*    void CheckMission(MissionAchive missionAchive)
    {
        bool isAchive = false;

        switch (missionAchive)
        {
            case MissionAchive.KillAhcive:
                isAchive = data.totalKill >= data.missionkill;
                break;

            case MissionAchive.TimeAchive:
                isAchive = data.totalPlayTime >= data.missionTime;
                break;

            case MissionAchive.MoneyAchive:
                isAchive = data.totalMoney >= data.missionMoney;
                break;
        }

        // isAchive가 true 상태이고 PlayerPrefs 에 achive가 0일 때 (해금이 안되어 있을 때)
        if (isAchive && PlayerPrefs.GetInt(missionAchive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(missionAchive.ToString(), 1);
        }
        else
        {
            PlayerPrefs.SetInt(missionAchive.ToString(), 0);
        }
    }*/

    
    public void Reward(string missionName) // 업적 달성 후 보상 받기 클릭 시
    {
        switch (missionName)
        {
            case "Kill":
                data.curMoney += data.missionkill * 100;
                data.missionkill *= 2;
                break;

            case "Money":
                data.curMoney += (data.missionMoney / 2);
                data.missionMoney *= 2;
                break;

            case "Time":
                data.curMoney += 500;
                data.missionTime *= 2;
                break;

        }
        data.MissionApply();

        foreach(MissionAchive mission in missionAchives)
        {
            CheckMission(mission);
        }
        Debug.Log(data.missionkill);

    }

    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.SFX.LevelUp);

        yield return wait;

        uiNotice.SetActive(false);
    }
}
