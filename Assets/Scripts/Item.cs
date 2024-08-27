using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public Weapon weapon;
    public Gear gear;

    Image icon;
    Text textLevel;
    
    public int level;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1]; // (첫 번째 인덱스는 자기 자신이므로, 2번째 icon이미지를 가져온다.
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
    }

    private void LateUpdate()
    {
        textLevel.text = "Lv." + (level);
    }

    public void OnClick()
    {
        switch (data.itemTpye)
        { 
            // Melee, Range를 묶어서
            case ItemData.ItemTpye.Melee:
            case ItemData.ItemTpye.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data); // 초기화
                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                level++;
                break;

            // Glove, Shoe 묶어서
            case ItemData.ItemTpye.Glove:
            case ItemData.ItemTpye.Shoe:
                if (level == 0)
                {
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data); // 초기화
                }
                else
                {
                    float nextRate = data.damages[level];
                    gear.LevelUp(nextRate);
                }
                level++;
                break;

            case ItemData.ItemTpye.Heal:
                GameManager.instance.health = GameManager.instance.maxHealth;
                break;
        }

        if(level == data.damages.Length) // 레벨이 최대값이 된다면
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
