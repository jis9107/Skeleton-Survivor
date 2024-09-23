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
/*        for(int i = 0; i < charData.Length; i++)
        {
            charData[i].level = dataManager.charlevel[i];
        }*/
        
        nowCharacterId = 0; // 나중에 받아올 값
        Init(nowCharacterId);
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

    public void OnClickSelectButton()
    {
        GameManager.instance.charDamage = charData[nowCharacterId].damage;
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }

    public void Init(int id)
    {
        nowCharacterId = id;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charLv.text = charData[id].level.ToString();
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();
    }

    public void CharacterUpgrade()
    {
        charData[nowCharacterId].level += 1;
        charData[nowCharacterId].damage = 10 * (charData[nowCharacterId].level);
        charData[nowCharacterId].maxHealth = 10 * (charData[nowCharacterId].level);
        Init(nowCharacterId);
    }
}
