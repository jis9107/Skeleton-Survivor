using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterData[] charData;

    public GameObject data;
    public GameObject selectButton;
    public GameObject selectImage;

    public Image icon;
    public Text charName;
    public Text charLv;
    public Text charDamage;
    public Text charHealth;
    public Text levelUpPriceText;

    DataManager dataManager;

    // 추후에 저장 할 데이터
    int inGameCharacterId; // 인게임에 저장된 캐릭터 ID (선택 버튼 누를 시)
    int tempId; // 캐릭터 창을 통해 선택된 ID
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
        ApplyCharacter();
    }

    public void CheckSelect() // 선택 버튼 활성화, 비활성화를 위한 로직
    {
        if (tempId == inGameCharacterId)
        {
            selectButton.SetActive(false);
            selectImage.SetActive(true);
        }
        else
        {
            selectButton.SetActive(true);
            selectImage.SetActive(false);
        }
    }
    public void OnSelectCharacter(int id)
    {
        tempId = id;

        levelUpPirce = charData[id].level * 200;
        icon.sprite = charData[id].charImage;
        charName.text = charData[id].charName;
        charLv.text = charData[id].level.ToString();
        charDamage.text = charData[id].damage.ToString();
        charHealth.text = charData[id].maxHealth.ToString();
        levelUpPriceText.text = levelUpPirce.ToString();

        // 업그레이드에 필요한 돈이 부족할 시 Text color를 빨간색으로 변경
        if(dataManager.curMoney < levelUpPirce)
            levelUpPriceText.color = Color.red;
        else
            levelUpPriceText.color = Color.white;

        CheckSelect();
    }

    public void ApplyCharacter() // 캐릭터 선택 버튼을 눌렀을 시 GamaManager에 변수를 선택 된 캐릭터의 데이터로 변환하는 함수
    {
        inGameCharacterId = tempId;

        PlayerPrefs.SetInt("SelectCharacter", inGameCharacterId);

        GameManager.instance.charDamage = charData[inGameCharacterId].damage;
        GameManager.instance.playerId = charData[inGameCharacterId].charId;
        GameManager.instance.maxHealth = charData[inGameCharacterId].maxHealth;

        CheckSelect();
    }

    public void CharacterUpgrade()
    {
        int money = dataManager.curMoney;

        if (money < levelUpPirce)
            return;

        int id = tempId;

        charData[id].level++;
        charData[id].damage += 10;
        charData[id].maxHealth += 15;
        dataManager.curMoney -= levelUpPirce;
        OnSelectCharacter(id);
    }

    private void Init()
    {
        inGameCharacterId = PlayerPrefs.GetInt("SelectCharacter");
        tempId = inGameCharacterId;

        levelUpPirce = charData[inGameCharacterId].level * 200;
        icon.sprite = charData[inGameCharacterId].charImage;
        charName.text = charData[inGameCharacterId].charName;
        charLv.text = charData[inGameCharacterId].level.ToString();
        charDamage.text = charData[inGameCharacterId].damage.ToString();
        charHealth.text = charData[inGameCharacterId].maxHealth.ToString();
        levelUpPriceText.text = levelUpPirce.ToString();

        CheckSelect();
    }
}
