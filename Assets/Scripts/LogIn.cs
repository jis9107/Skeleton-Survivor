using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    public InputField inputNick;

    public Button setNickName;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerNickName"))
            SceneManager.LoadScene(1);
    }
    public void OnClickSetButton()
    {
        string nick = inputNick.text;
        PlayerPrefs.SetString("PlayerNickName", nick);
        SceneManager.LoadScene(1);
    }
}
