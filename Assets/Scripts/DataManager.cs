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
    public Text curMoneyText;
    public Text curLubyText;

    [Header("# GameData")]
    public int curMoney;
    public int luby;

    int totalKill;
    int totalMoney;
    float totalPlayTime;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("totalKill"))
            Init();
        Load();
    }


    public void Save()
    {
        totalMoney += GameManager.instance.inGameMoney;
        totalKill += GameManager.instance.kill;
        totalPlayTime += GameManager.instance.gameTime;

        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetFloat("totalPlayTime", totalPlayTime);
    }

    public void Load()
    {
        totalKill = PlayerPrefs.GetInt("totalKill");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalPlayTime = PlayerPrefs.GetInt("totalPlayTime");
    }

    void Init()
    {
        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetFloat("totalPlayTime", totalPlayTime);
    }

}
