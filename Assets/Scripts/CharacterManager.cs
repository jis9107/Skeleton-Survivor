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
            Init();
    }


    private void Start()
    {
        dataManager = data.GetComponent<DataManager>();

        inGameCharacterId = PlayerPrefs.GetInt("SelectCharacter");
        Debug.Log(inGameCharacterId);
        OnSelectCharacter(selectId);
        
    }
    public void OnSelectCharacter(int id)
    {
        if (inGameCharacterId != id)
            selectButton.SetActive(true);

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

        Init();

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
        PlayerPrefs.SetInt("SelectCharacter", inGameCharacterId);
    }
}
