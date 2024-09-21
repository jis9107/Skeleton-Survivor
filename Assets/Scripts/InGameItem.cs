using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem.Switch;
using static ItemData;

public class InGameItem : MonoBehaviour
{
   public enum Type
    {
        bomb,
        coin,
        mag
    }

    public Type itemTpye;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        switch(itemTpye)
        {
            case Type.bomb:
                StartCoroutine("Bomb");
                break;

            case Type.coin:
                GameManager.instance.GetInGameMoney(1000);
                this.gameObject.SetActive(false);
                break;

            case Type.mag:
                this.gameObject.SetActive(false);
                break;
        }
    }

    IEnumerator Bomb()
    {
        GameManager.instance.enemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        GameManager.instance.enemyCleaner.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
