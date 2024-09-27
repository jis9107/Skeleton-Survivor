using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [Header("# Text")]
    public Text totalKillText;
    public Text totalMoneyText;
    public Text totalPlayTimeText;
    public Text curMoneyText;
    public Text curLubyText;

    [Header("# GameData")]
    public int curMoney;
    public int curLuby;

    [Header("# Achive")]


    int totalKill;
    int totalMoney;
    int totalPlayTime;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("totalKill"))
            Init();
        Load();
    }

    private void Start()
    {
        ApplyText();
    }


    public void Save()
    {
        totalMoney += GameManager.instance.inGameMoney;
        totalKill += GameManager.instance.kill;
        totalPlayTime += (int)GameManager.instance.gameTime;
        curMoney += GameManager.instance.inGameMoney;
        

        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetInt("totalPlayTime", totalPlayTime);

        PlayerPrefs.SetInt("curMoney", curMoney);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        totalKill = PlayerPrefs.GetInt("totalKill");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalPlayTime = PlayerPrefs.GetInt("totalPlayTime");

        curMoney = PlayerPrefs.GetInt("curMoney");
        curLuby = PlayerPrefs.GetInt("curLuby");
    }

    void Init() // HasKey가 없다면 생성
    {
        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetInt("totalPlayTime", totalPlayTime);
        PlayerPrefs.SetInt("curMoney", curMoney);
        PlayerPrefs.SetInt("curLuby", curLuby);

        PlayerPrefs.Save();
    }

    void ApplyText()
    {
        totalKillText.text = totalKill.ToString();
        totalMoneyText.text = totalMoney.ToString();
        totalPlayTimeText.text = totalPlayTime.ToString();
        curMoneyText.text = curMoney.ToString();
        curLubyText.text = curLuby.ToString();
    }

}
