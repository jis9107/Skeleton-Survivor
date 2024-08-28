using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 어느 스크립트에서도 접근하기 쉽게 인스터스화

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
        nextExp = new int[]{ 3, 10, 25, 50, 90, 130, 180, 250, 400, 600 };

        // 임시 스크립트 (첫번째 캐릭터 선택)
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
        if (exp == nextExp[level])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0; // 시간이 흐르는 속도
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }


}
