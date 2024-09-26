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
        // 저장 할 변수들
        // 2. 스테이지
        // 3. 업적
        // 4. 돈, 보석
    }

    public void Load()
    {

    }
}
