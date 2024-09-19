using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnData[] spawnData;


    public float levelTime;

    int level;
    float timer;
    float chestTimer;

    private void Awake()
    {
/*        spawnPoint = GetComponentsInChildren<Transform>();*/
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        chestTimer += Time.deltaTime;
        level = Mathf.Min((Mathf.FloorToInt(GameManager.instance.gameTime / levelTime)), spawnData.Length - 1);
        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();

            if(chestTimer > spawnData[level].spawnTime * 10)
            {
                chestTimer = 0;
                ChestSpawn();
            }
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }

    void ChestSpawn()
    {
        GameObject chest = GameManager.instance.pool.Get(4);
        chest.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
