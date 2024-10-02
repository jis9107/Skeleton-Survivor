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

    void Init() // HasKey�� ���ٸ� ����
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
        totalKillText.text = string.Format("���� ����ų �� : {0}", totalKill);
        totalMoneyText.text = string.Format("���� ���� �Ӵ� : {0}", totalMoney);
        totalPlayTimeText.text = string.Format("���� �÷��� Ÿ�� : {0}", totalPlayTime);

        curMoneyText.text = curMoney.ToString();
        curLubyText.text = curLuby.ToString();
    }

    public void MissionApply() // �̼� ���� �� 
    {
        PlayerPrefs.SetInt("missionkill", missionkill);
        PlayerPrefs.SetInt("missionMoney", missionMoney);
        PlayerPrefs.SetInt("missionTime", missionTime);

        killMissionText.text = string.Format("���� ų {0}ų �޼��ϱ�", missionkill);
        moneyMissionText.text = string.Format("���� �Ӵ� {0} �޼��ϱ�", missionMoney);
        timeMossionText.text = string.Format("�÷��� Ÿ�� {0}�� �޼��ϱ�", missionTime);
        curMoneyText.text = curMoney.ToString();
        curLubyText.text = curLuby.ToString();
    }
}
