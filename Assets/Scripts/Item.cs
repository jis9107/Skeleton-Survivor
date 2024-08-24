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
            case ItemData.ItemTpye.Melee:
            case ItemData.ItemTpye.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data); // 초기화
                }
                break;

            case ItemData.ItemTpye.Glove:
                break;

            case ItemData.ItemTpye.Shoe:
                break;

            case ItemData.ItemTpye.Heal:
                break;
        }

        level++;

        if(level == data.damages.Length) // 레벨이 최대값이 된다면
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
