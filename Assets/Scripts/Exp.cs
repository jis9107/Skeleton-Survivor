using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    public Rigidbody2D target;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            GameManager.instance.GetExp();
            gameObject.SetActive(false);
        }
    }
}
