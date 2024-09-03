using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achive //������
    {
        UnLockPotato,
        UnLickBean
    }
    Achive[] achives; // �����


    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum Ÿ�� ���� �����´�.

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

    private void Update()
    {
        
    }
}
