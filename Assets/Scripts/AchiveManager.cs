using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unLockCharacter;

    enum Achive //������
    {
        UnLockPotato,
        UnLickBean
    }
    Achive[] achives; // �����


    private void Awake()
    {
        achives = (Achive[])Enum.GetValues(typeof(Achive)); // enum Ÿ�� ���� �����´�.
    }

    void Init()
    {

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 0);
        }
/*        PlayerPrefs.SetInt("MyData", 1); // Key Value �� ����
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
