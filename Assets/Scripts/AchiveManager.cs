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

    public GameObject[] lockReward;
    public GameObject[] unLockReward;

    public GameObject uiNotice;

    DataManager data;
    

    enum Achive //ĳ���� �ر� ������
    {
        UnLockChar_2,
        UnLockChar_3,
    }

    enum MissionAchive // �̼� �޼� ������
    {
        KillAhcive,
        TimeAchive,
        MoneyAchive
    }

    MissionAchive[] missionAchives; // �̼� �޼� ���� �����
    Achive[] achives; // �����
    // Coroutine�� ����� �� �޸� ���� �����ϱ� ���� �̸� ���� (�޸� ����ȭ)
    // TimeScale�� ������ ���� �ʰ� �ϱ� ���ؼ� Realtime ���
    WaitForSecondsRealtime wait;


    private void Awake()
    {
        data = dataManager.GetComponent<DataManager>();

        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum Ÿ�� ���� �����´�.
        missionAchives = (MissionAchive[])Enum.GetValues(typeof(MissionAchive));

        wait = new WaitForSecondsRealtime(5);
        if (!PlayerPrefs.HasKey("MyData")) //PlayerPrefs�� �����Ͱ� ������ �ʱ�ȭ
        {
            Init();
        }
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1); // Key Value �� ����
        // ���� �ʱ�ȭ
        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }

        foreach (MissionAchive missionAchive in missionAchives)
        {
            PlayerPrefs.SetInt(missionAchive.ToString(), 0);
        }

    }

    private void Start()
    {
        UnlockCharacter();

        foreach (MissionAchive missionAchive in missionAchives)
        {
            CheckMission(missionAchive);
        }

        UnLockMissionReward();
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

    void UnLockMissionReward()
    {
        for(int i = 0; i < lockReward.Length; i++)
        {
            string rewardName = missionAchives[i].ToString();
            bool isUnLock = PlayerPrefs.GetInt(rewardName) == 1;
            lockReward[i].SetActive(!isUnLock);
            unLockReward[i].SetActive(isUnLock);
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

        // isAchive�� true �����̰� PlayerPrefs �� achive�� 0�� �� (�ر��� �ȵǾ� ���� ��)
        if(isAchive && PlayerPrefs.GetInt(achive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1); // �ر� 
            
            for(int i = 0; i < uiNotice.transform.childCount; i++)
            {
                isAchive = i == (int)achive;
                uiNotice.transform.GetChild(i).gameObject.SetActive(isAchive);
            }

            StartCoroutine(NoticeRoutine());
        }
    }

    void CheckMission(MissionAchive missionAchive)
    {
        bool isAchive = false;

        switch (missionAchive)
        {
            case MissionAchive.KillAhcive:
                isAchive = data.missionkill >= data.totalKill;
                break;

            case MissionAchive.TimeAchive:
                isAchive = data.missionTime >= data.totalPlayTime;
                break;

            case MissionAchive.MoneyAchive:
                isAchive = data.missionMoney >= data.totalMoney;
                break;
        }

        // isAchive�� true �����̰� PlayerPrefs �� achive�� 0�� �� (�ر��� �ȵǾ� ���� ��)
        if (isAchive && PlayerPrefs.GetInt(missionAchive.ToString()) == 0)
        {
            PlayerPrefs.SetInt(missionAchive.ToString(), 1);
        }

        else
        {
            PlayerPrefs.SetInt(missionAchive.ToString(), 0);
        }
    }

    
    public void Reward(string missionName) // ���� �޼� �� ���� �ޱ� Ŭ�� ��
    {
        switch (missionName)
        {
            case "kill":
                data.curMoney += data.missionkill;
                data.missionkill *= 2;
                break;
        }

        foreach (MissionAchive missionAchive in missionAchives)
        {
            CheckMission(missionAchive);
        }

        UnLockMissionReward();
        data.MissionApplyText();
    }



    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.SFX.LevelUp);

        yield return wait;

        uiNotice.SetActive(false);
    }
}
