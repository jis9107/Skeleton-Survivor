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

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("totalKill"))
            Save();
        Load();
    }


    public void Save()
    {
        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetInt("totalPlayTime", totalPlayTime);
    }

    public void Load()
    {
        totalKill = PlayerPrefs.GetInt("totalKill");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalPlayTime = PlayerPrefs.GetInt("totalPlayTime");
    }

}
