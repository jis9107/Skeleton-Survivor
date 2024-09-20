using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Switch;
using UnityEngine.UI;

public class ChooseCharater : MonoBehaviour
{
    public CharacterData charData;

    public Image icon;
    public Text charName;
    public Text charLv;
    public Text charDamage;
    public Text charHealth;

    public void OnSelectCharacter()
    {
        icon.sprite = charData.charImage;
        charName.text = charData.charName;
        charDamage.text = charData.damage.ToString();
        charHealth.text = charData.maxHealth.ToString();
        GameManager.instance.playerId = charData.charId;

    }
}
