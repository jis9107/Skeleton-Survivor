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

    // 추후에 저장 할 데이터
    int nowCharacterId;
    int levelUpPirce;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SelectCharacter"))
            Init();
    }


    private void Start()
    {
        dataManager = data.GetComponent<DataManager>();

        nowCharacterId = PlayerPrefs.GetInt("SelectCharacter");
        Debug.Log(nowCharacterId);
        OnSelectCharacter(nowCharacterId);
        
    }
    public void OnSelectCharacter(int id)
    {
        nowCharacterId = id;
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
        

    }

    public void ApplyCharacter() // 캐릭터 선택 버튼을 눌렀을 시 GamaManager에 변수를 선택 된 캐릭터의 데이터로 변환하는 함수
    {
        Init();

        GameManager.instance.charDamage = charData[nowCharacterId].damage;
        GameManager.instance.playerId = charData[nowCharacterId].charId;
        GameManager.instance.maxHealth = charData[nowCharacterId].maxHealth;
    }

    public void CharacterUpgrade()
    {
        int money = dataManager.curMoney;

        if (money < levelUpPirce)
            return;

        int id = nowCharacterId;

        charData[id].level++;
        charData[id].damage += 10;
        charData[id].maxHealth += 15;
        dataManager.curMoney -= levelUpPirce;
        OnSelectCharacter(id);


    }

    private void Init()
    {
        PlayerPrefs.SetInt("SelectCharacter", nowCharacterId);

        PlayerPrefs.Save();
    }
}
