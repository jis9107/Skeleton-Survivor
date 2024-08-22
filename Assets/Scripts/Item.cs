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
        textLevel.text = "Lv." + (level + 1);
    }


}
