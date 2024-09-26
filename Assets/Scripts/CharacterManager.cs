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
    int nowCharacterId;

    private void Awake()
    {
        //데이터 매니저에서 받아올 값 (레벨, 현재 캐릭터 Id)
        dataManager = GetComponent<DataManager>();

        if (!PlayerPrefs.HasKey("SelectCharacter"))
            Init();

        nowCharacterId = PlayerPrefs.GetInt("SelectCharacter");
        Debug.Log(nowCharacterId);
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
    }

    public void ApplyCharacter() // 캐릭터 선택 버튼을 눌렀을 시 GamaManager에 변수를 선택 된 캐릭터의 데이터로 변환하는 함수
    {
        GameManager.instance.charDamage = charData[nowCharacterId].damage;
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }

    public void CharacterUpgrade()
    {
        int id = nowCharacterId;

        charData[id].level ++;
        charData[id].damage += 10;
        charData[id].maxHealth += 15;
        OnSelectCharacter(id);
    }

    private void Init()
    {
        PlayerPrefs.SetInt("SelectCharacter", nowCharacterId);
    }
}
