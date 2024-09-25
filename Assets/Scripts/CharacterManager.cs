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
    public int nowCharacterId;
    public int[] charLevelData;

    private void Awake()
    {
        //데이터 매니저에서 받아올 값 (레벨, 현재 캐릭터 Id)
        dataManager = GetComponent<DataManager>();
        Init();
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

    public void Init()
    {
        nowCharacterId = PlayerPrefs.GetInt("selectCharId");

        for(int i = 0; i < charData.Length; i++)
        {
            charData[i].level = PlayerPrefs.GetInt($"characterLevel {i}");
            charData[i].damage = charData[i].level * 10;
            charData[i].maxHealth = charData[i].level * 15;
        }
    }

    public void CharacterUpgrade()
    {
        charData[nowCharacterId].level += 1;
        charData[nowCharacterId].damage = 10 * (charData[nowCharacterId].level);
        charData[nowCharacterId].maxHealth = 10 * (charData[nowCharacterId].level);
        CharDataSave();
        Init();
    }

    public void CharDataSave()
    {
        for(int i = 0; i < charData.Length;i++)
        {
            PlayerPrefs.SetInt($"characterID {i}", charData[i].charId); // 캐릭터 아이디 저장
            PlayerPrefs.SetInt($"characterLevel {i}", charData[i].level); // 캐릭터 레벨 저장
        }

        PlayerPrefs.SetInt("selectCharId", nowCharacterId);

        PlayerPrefs.Save();
    }
}
