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



    // ���Ŀ� ���� �� ������
    public int nowCharacterId = 0;

    private void Awake()
    {
        //������ �Ŵ������� �޾ƿ� �� (����, ���� ĳ���� Id)
        dataManager = GetComponent<DataManager>();

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

    public void ApplyCharacter() // ĳ���� ���� ��ư�� ������ �� GamaManager�� ������ ���� �� ĳ������ �����ͷ� ��ȯ�ϴ� �Լ�
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
}
