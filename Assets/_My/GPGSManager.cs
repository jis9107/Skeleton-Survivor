using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPGSManager : MonoBehaviour
{
    [SerializeField] private Text logText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GPGS_LogIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status) // 11������ �α׾ƿ��� X;
    {
        if (status == SignInStatus.Success)
        {
            string displayName = PlayGamesPlatform.Instance.GetUserDisplayName(); // ���� ���÷��� ���� (���� ����)
            string userID = PlayGamesPlatform.Instance.GetUserId(); // ���� ���� ���̵� (���� �Ұ���)

            logText.text = "�α��� ���� : " + displayName + " / " + userID;

        }
        else
        {
            logText.text = " �α��� ���� ";
        }
    }
}
