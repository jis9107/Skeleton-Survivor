using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterData[] charData;

    DataManager dataManager;

    public Image icon;
    public Text charName;
    public Text charLv;
    public Text charDamage;
    public Text charHealth;



    // 추후에 저장 할 데이터
    public int nowCharacterId = 0;
    public int[] charLevelData;
    public int[] charDamageData;
    public int[] charHealthData;

    private void Awake()
    {
        //데이터 매니저에서 받아올 값 (레벨, 현재 캐릭터 Id)
        dataManager = GetComponent<DataManager>();

        if (PlayerPrefs.HasKey("selectCharId"))
            CharDataLoad();
        OnSelectCharacter(nowCharacterId);
    }

    public void OnSelectCharacter(int id)
    {
        nowCharacterId = id;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charLv.text = charData[id].level.ToString();
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();

        CharDataSave();
    }

    public void OnClickSelectButton() // 캐릭터 선택 버튼을 눌렀을 시 GamaManager에 변수를 선택 된 캐릭터의 데이터로 변환하는 함수
    {
        GameManager.instance.charDamage = charData[nowCharacterId].damage;
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }

    public void Apply()
    {
        for (int i = 0; i < charData.Length; i++)
        {
            charData[i].level = 1;
            charData[i].damage = charData[i].damage + ((charData[i].level-1) * 10);
            charData[i].maxHealth = charData[i].maxHealth + ((charData[i].level - 1) * 15);
        }
    }

    public void CharDataLoad()
    {
        nowCharacterId = PlayerPrefs.GetInt("selectCharId");

        for (int i = 0; i < charData.Length; i++)
        {
            charData[i].charId = PlayerPrefs.GetInt($"characterID {i}");
            charData[i].level = PlayerPrefs.GetInt($"characterLevel {i}");
        }
    }

    public void CharacterUpgrade()
    {
        charData[nowCharacterId].level ++;
        charData[nowCharacterId].damage += 10;
        charData[nowCharacterId].maxHealth += 10;
        CharDataSave();
    }

    public void CharDataSave()
    {
        for(int i = 0; i < charData.Length;i++)
        {
            PlayerPrefs.SetInt($"characterID {i}", charData[i].charId); // 캐릭터 아이디 
            PlayerPrefs.SetInt($"characterLevel {i}", charData[i].level); // 캐릭터 레벨 
            PlayerPrefs.SetFloat($"charDamage {i}", charData[i].damage); // 캐릭터 데미지
            PlayerPrefs.SetFloat($"charHealth {i}", charData[i].maxHealth); // 캐릭터 체력
        }

        PlayerPrefs.SetInt("selectCharId", nowCharacterId);

        PlayerPrefs.Save();
    }
}
