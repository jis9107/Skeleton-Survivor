using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [Header("#AchiveText")]
    public Text totalKillText;
    public Text totalmoneyText;
    public Text totalPlayTimeText;

    [Header("# GameData")]
    public int curMoney;
    public int luby;

    int totalKill;
    int totalMoney;
    int totalPlayTime;


    public void Save()
    {
        // ���� �� ������
        // 2. ��������
        // 3. ����
        // 4. ��, ����
    }

    public void Load()
    {

    }
}
