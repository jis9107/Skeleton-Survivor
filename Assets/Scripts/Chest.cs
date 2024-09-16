using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        int random = Random.Range(0, 5);

        if (random <= 2)
            random = 2;

        GameObject dropItem = GameManager.instance.pool.Get(random + 3);
        dropItem.transform.position = this.transform.position;

        gameObject.SetActive(false);
    }
}
