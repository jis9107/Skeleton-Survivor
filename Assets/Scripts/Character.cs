using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // ���� ĳ���� �ɷ¿� ���� ���׷��̵�
    public static float Speed
    {
        //    get { return GameManager.instance.playerId == 0 ? 1.1f : 1f; }
        get { return 1f; }
    }
    public static float WeaponSpeed
    {
        get { return 1f;  }
    }
    public static float WeaponRate
    {
        get { return 1f; }
    }
    public static float Damage
    {
        get { return 1f; }
    }
    public static int Count
    {
        //    get { return GameManager.instance.playerId == 1 ? 1 : 0; }
        get { return 0; }
    }

}
