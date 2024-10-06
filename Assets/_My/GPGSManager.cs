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

    internal void ProcessAuthentication(SignInStatus status) // 11버전은 로그아웃이 X;
    {
        if (status == SignInStatus.Success)
        {
            string displayName = PlayGamesPlatform.Instance.GetUserDisplayName(); // 유저 디스플레이 네임 (변경 가능)
            string userID = PlayGamesPlatform.Instance.GetUserId(); // 유저 고유 아이디 (변경 불가능)

            logText.text = "로그인 성공 : " + displayName + " / " + userID;

        }
        else
        {
            logText.text = " 로그인 실패 ";
        }
    }
}
