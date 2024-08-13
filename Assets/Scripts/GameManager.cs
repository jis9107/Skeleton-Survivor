using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 어느 스크립트에서도 접근하기 쉽게 인스터스화

    public PoolManager pool;
    public Player player;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

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
