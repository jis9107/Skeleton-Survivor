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
    

    enum Achive //������
    {
        UnLockPotato,
        UnLickBean
    }
    Achive[] achives; // �����
    // Coroutine�� ����� �� �޸� ���� �����ϱ� ���� �̸� ���� (�޸� ����ȭ)
    // TimeScale�� ������ ���� �ʰ� �ϱ� ���ؼ� Realtime ���
    WaitForSecondsRealtime wait;


    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum Ÿ�� ���� �����´�.
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

    IEnumerator NoticeRoutine()
    {
        uiNotice.SetActive(true);

        yield return wait;

        uiNotice.SetActive(false);
    }
}
