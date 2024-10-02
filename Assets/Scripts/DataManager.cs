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

    [Header("# MissionText")]
    public Text killMissionText;
    public Text moneyMissionText;
    public Text timeMossionText;

    [Header("# Mission")]
    public int missionkill;
    public int missionMoney;
    public int missionTime;

    [Header("# inGame")]
    public int curMoney;
    public int curLuby;
    public int totalKill;
    public int totalMoney;
    public int totalPlayTime;



    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Data"))
            Init();
        Load();
    }

    private void Start()
    {
        ApplyText();
        MissionApply();
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

        missionkill = PlayerPrefs.GetInt("missionkill");
        missionMoney = PlayerPrefs.GetInt("missionMoney");
        missionTime = PlayerPrefs.GetInt("missionTime");

        curMoney = PlayerPrefs.GetInt("curMoney");
        curLuby = PlayerPrefs.GetInt("curLuby");
    }

    void Init() // HasKey가 없다면 생성
    {
        PlayerPrefs.SetInt("Data", 1);

        PlayerPrefs.SetInt("totalKill", totalKill);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        PlayerPrefs.SetInt("totalPlayTime", totalPlayTime);
        PlayerPrefs.SetInt("curMoney", curMoney);
        PlayerPrefs.SetInt("curLuby", curLuby);

        PlayerPrefs.SetInt("missionkill", missionkill);
        PlayerPrefs.SetInt("missionMoney", missionMoney);
        PlayerPrefs.SetInt("missionTime", missionTime);

        PlayerPrefs.Save();
    }

    public void ApplyText()
    {
        totalKillText.text = string.Format("현재 누적킬 수 : {0}", totalKill);
        totalMoneyText.text = string.Format("현재 누적 머니 : {0}", totalMoney);
        totalPlayTimeText.text = string.Format("현재 플레이 타임 : {0}", totalPlayTime);

        curMoneyText.text = curMoney.ToString();
        curLubyText.text = curLuby.ToString();
    }

    public void MissionApply() // 미션 성공 후 
    {
        PlayerPrefs.SetInt("missionkill", missionkill);
        PlayerPrefs.SetInt("missionMoney", missionMoney);
        PlayerPrefs.SetInt("missionTime", missionTime);

        killMissionText.text = string.Format("누적 킬 {0}킬 달성하기", missionkill);
        moneyMissionText.text = string.Format("누적 머니 {0} 달성하기", missionMoney);
        timeMossionText.text = string.Format("플레이 타임 {0}초 달성하기", missionTime);
        curMoneyText.text = curMoney.ToString();
        curLubyText.text = curLuby.ToString();
    }
}
