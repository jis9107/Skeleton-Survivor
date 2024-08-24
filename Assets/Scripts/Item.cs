using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public Weapon weapon;

    Image icon;
    Text textLevel;
    
    public int level;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1]; // (ù ��° �ε����� �ڱ� �ڽ��̹Ƿ�, 2��° icon�̹����� �����´�.
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
                break;

            // Glove, Shoe ���
            case ItemData.ItemTpye.Glove:
            case ItemData.ItemTpye.Shoe:


                break;

            case ItemData.ItemTpye.Heal:
                break;
        }

        level++;

        if(level == data.damages.Length) // ������ �ִ밪�� �ȴٸ�
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
