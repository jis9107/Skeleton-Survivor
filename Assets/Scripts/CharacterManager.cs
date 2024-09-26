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
    public int[] charLevelData;
    public int[] charDamageData;
    public int[] charHealthData;

    private void Awake()
    {
        //������ �Ŵ������� �޾ƿ� �� (����, ���� ĳ���� Id)
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

    public void OnClickSelectButton() // ĳ���� ���� ��ư�� ������ �� GamaManager�� ������ ���� �� ĳ������ �����ͷ� ��ȯ�ϴ� �Լ�
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
            PlayerPrefs.SetInt($"characterID {i}", charData[i].charId); // ĳ���� ���̵� 
            PlayerPrefs.SetInt($"characterLevel {i}", charData[i].level); // ĳ���� ���� 
            PlayerPrefs.SetFloat($"charDamage {i}", charData[i].damage); // ĳ���� ������
            PlayerPrefs.SetFloat($"charHealth {i}", charData[i].maxHealth); // ĳ���� ü��
        }

        PlayerPrefs.SetInt("selectCharId", nowCharacterId);

        PlayerPrefs.Save();
    }
}
