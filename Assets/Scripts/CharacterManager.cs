using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterData[] charData;

    public Image icon;
    public Text charName;
    public Text charLv;
    public Text charDamage;
    public Text charHealth;

    // 추후에 저장 할 데이터
    public int nowCharacterId;

    private void Awake()
    {
        Init(nowCharacterId);
    }

    public void OnSelectCharacter(int id)
    {
        nowCharacterId = id;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();
    }

    public void OnClickSelectButton()
    {
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }

    public void Init(int id)
    {
        nowCharacterId = id;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }
}
