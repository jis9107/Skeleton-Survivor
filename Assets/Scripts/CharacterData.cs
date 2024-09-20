using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptble Object/CharacterData")]
public class CharacterData : ScriptableObject
{
    public enum Character
    {
        blue,
        pink,
        orange,
        purple
    }

    [Header("# Character Info")]
    public Character character;
    public int charId;
    public string charName;
    public Sprite charImage;

    [Header("# Character Status")]
    public float speed;
    public float damage;
    public float maxHealth;
    public int level;

}
