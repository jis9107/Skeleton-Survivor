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

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
