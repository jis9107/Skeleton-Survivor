using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    float timer;

    Player player;

    private void Awake()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;

                if(timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;

        }

        // .. Test Code
        if (Input.GetButtonDown("Jump"))
        {
            LevelUp(10, 1);
        }
    }
    public void Init(ItemData data)
    {
        //Basic Set
        name = "Weapon" + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        //Property Set
        id = data.itemId;
        damage = data.baseDamage;
        count = data.baseCount;

        for(int i = 0; i < GameManager.instance.pool.prefabs.Length; i++)
        {
            if(data.projectile == GameManager.instance.pool.prefabs[i])
            {
                prefabId = i;
                break;
            }
        }

        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                speed = 0.3f;
                break;
        }

        // 특정 함수 호출을 모든 자식에게 방송한다.
        // 플레이어가 가지고 있는 모든 Gear에 한해서 ApplyGear를 실행시킨다.
        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if(id == 0)
            Batch();

        // 특정 함수 호출을 모든 자식에게 방송한다.
        // 플레이어가 가지고 있는 모든 Gear에 한해서 ApplyGear를 실행시킨다.
        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    void Batch() // 근접 무기 배치
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet;
            if( i < transform.childCount)  // 기존 오브젝트를 활용하고 모자란 것을 풀링에서 가져오기
            {
                bullet = transform.GetChild(i);
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero; // 위치 초기화
            bullet.localRotation = Quaternion.identity; // 회전 초기화

            Vector3 rotVec = Vector3.forward * 360 * i / count; // 무기 갯수에 맞춰 각도 변환
            bullet.Rotate(rotVec); 
            bullet.Translate(bullet.up * 1.5f, Space.World); // 플레이어 기준으로 배치

            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1 is Infinity Per.
        }
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;
        
        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir); // 지정된 축을 중심으로 목표를 향해 회전하는 함수
        bullet.GetComponent<Bullet>().Init(damage, count, dir);

    }
}
