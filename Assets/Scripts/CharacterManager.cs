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
    public int nowCharacterId;
    public int[] charLevelData;

    private void Awake()
    {
        //������ �Ŵ������� �޾ƿ� �� (����, ���� ĳ���� Id)
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

    public void OnClickSelectButton() // ĳ���� ���� ��ư�� ������ �� GamaManager�� ������ ���� �� ĳ������ �����ͷ� ��ȯ�ϴ� �Լ�
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
            PlayerPrefs.SetInt($"characterID {i}", charData[i].charId); // ĳ���� ���̵� ����
            PlayerPrefs.SetInt($"characterLevel {i}", charData[i].level); // ĳ���� ���� ����
        }

        PlayerPrefs.SetInt("selectCharId", nowCharacterId);

        PlayerPrefs.Save();
    }
}
