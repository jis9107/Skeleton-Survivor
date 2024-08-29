using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ��� ��ũ��Ʈ������ �����ϱ� ���� �ν��ͽ�ȭ

    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public LevelUp uiLevelUp;

    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;
    public bool isLive;

    [Header("# Player Info")]
    public int health;
    public int maxHealth;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;

        // �ӽ� ��ũ��Ʈ (ù��° ĳ���� ����)
        uiLevelUp.Select(1);
    }

    private void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[Mathf.Min(level, nextExp.Length -1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0; // �ð��� �帣�� �ӵ�
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }


}
