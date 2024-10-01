using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterData[] charData;
    public GameObject data;
    public GameObject selectButton;

    public Image icon;
    public Text charName;
    public Text charLv;
    public Text charDamage;
    public Text charHealth;
    public Text levelUpPriceText;

    DataManager dataManager;

    // ���Ŀ� ���� �� ������
    int inGameCharacterId; // �ΰ��ӿ� ����� ĳ���� ID (���� ��ư ���� ��)
    int selectId; // ĳ���� â�� ���� ���õ� ID
    int levelUpPirce;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SelectCharacter"))
            PlayerPrefs.SetInt("SelectCharacter", inGameCharacterId);
    }


    private void Start()
    {
        dataManager = data.GetComponent<DataManager>();

        Debug.Log(inGameCharacterId);
        Init();        
    }
    public void OnSelectCharacter(int id)
    {
        selectId = id;

        if (inGameCharacterId != selectId)
            selectButton.SetActive(true);
        else
            selectButton.SetActive(false);

        levelUpPirce = charData[id].level * 200;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charLv.text = charData[id].level.ToString();
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();
        levelUpPriceText.text = levelUpPirce.ToString();

        // ���׷��̵忡 �ʿ��� ���� ������ �� Text color�� ���������� ����
        if(dataManager.curMoney < levelUpPirce)
            levelUpPriceText.color = Color.red;
        else
            levelUpPriceText.color = Color.white;
    }

    public void ApplyCharacter() // ĳ���� ���� ��ư�� ������ �� GamaManager�� ������ ���� �� ĳ������ �����ͷ� ��ȯ�ϴ� �Լ�
    {
        inGameCharacterId = selectId;

        PlayerPrefs.SetInt("SelectCharacter", inGameCharacterId);

        GameManager.instance.charDamage = charData[inGameCharacterId].damage;
        GameManager.instance.playerId = charData[inGameCharacterId].charId;
        GameManager.instance.maxHealth = charData[inGameCharacterId].maxHealth;
    }

    public void CharacterUpgrade()
    {
        int money = dataManager.curMoney;

        if (money < levelUpPirce)
            return;

        int id = selectId;

        charData[id].level++;
        charData[id].damage += 10;
        charData[id].maxHealth += 15;
        dataManager.curMoney -= levelUpPirce;
        OnSelectCharacter(id);


    }

    private void Init()
    {
        inGameCharacterId = PlayerPrefs.GetInt("SelectCharacter");

        levelUpPirce = charData[inGameCharacterId].level * 200;
        icon.sprite = charData[inGameCharacterId].charImage;
        charName.text = charData[inGameCharacterId].charName;
        charLv.text = charData[inGameCharacterId].level.ToString();
        charDamage.text = charData[inGameCharacterId].damage.ToString();
        charHealth.text = charData[inGameCharacterId].maxHealth.ToString();
        levelUpPriceText.text = levelUpPirce.ToString();
    }
}
