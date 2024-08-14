using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ��� ��ũ��Ʈ������ �����ϱ� ���� �ν��ͽ�ȭ

    public PoolManager pool;
    public Player player;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public int level;
    public int kill;
    public int exp;
    public int[] nextExp;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }

    }


}
