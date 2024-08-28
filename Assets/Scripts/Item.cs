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
    Text textName; 
    Text textDesc;
    
    public int level;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1]; // (ù ��° �ε����� �ڱ� �ڽ��̹Ƿ�, 2��° icon�̹����� �����´�.
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
        textName = texts[1];
        textDesc = texts[2];
        textName.text = data.itemName;
    }

    private void OnEnable()
    {
        textLevel.text = "Lv." + (level);

        switch (data.itemTpye)
        {
            case ItemData.ItemTpye.Melee:
            case ItemData.ItemTpye.Range:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100, data.counts[level]);
                break;

            case ItemData.ItemTpye.Glove:
            case ItemData.ItemTpye.Shoe:
                textDesc.text = string.Format(data.itemDesc, data.damages[level] * 100);
                break;
            
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
    }

    public void OnClick()
    {
        switch (data.itemTpye)
        { 
            // Melee, Range�� ���
            case ItemData.ItemTpye.Melee:
            case ItemData.ItemTpye.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data); // �ʱ�ȭ
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

            // Glove, Shoe ���
            case ItemData.ItemTpye.Glove:
            case ItemData.ItemTpye.Shoe:
                if (level == 0)
                {
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data); // �ʱ�ȭ
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

        if(level == data.damages.Length) // ������ �ִ밪�� �ȴٸ�
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
