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
        switch (charData.characterType)
        {
            case CharacterData.CharacterType.blue:
                icon.sprite = charData.charImage.sprite;
                charName.text = charName.text;
                charDamage.text = charDamage.text;
                charHealth.text = charHealth.text;
                break;

            case CharacterData.CharacterType.pink:
                icon.sprite = charData.charImage.sprite;
                charName.text = charName.text;
                charDamage.text = charDamage.text;
                charHealth.text = charHealth.text;
                break;

            case CharacterData.CharacterType.orange:
                icon.sprite = charData.charImage.sprite;
                charName.text = charName.text;
                charDamage.text = charDamage.text;
                charHealth.text = charHealth.text;
                break;

            case CharacterData.CharacterType.purple:
                icon.sprite = charData.charImage.sprite;
                charName.text = charName.text;
                charDamage.text = charDamage.text;
                charHealth.text = charHealth.text;
                break;
        }
    }
}
