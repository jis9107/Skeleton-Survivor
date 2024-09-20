using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptble Object/CharacterData")]
public class CharacterData : ScriptableObject
{
    public enum CharacterType
    {
        blue,
        pink,
        orange,
        purple
    }

    [Header("# Character Info")]
    public CharacterType characterType;
    public int charId;
    public string charName;
    public Image charImage;

    [Header("# Character Status")]
    public float speed;
    public float damage;
    public float maxHealth;
    public int level;
}
