using Photon.Pun;
using TMPro;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] TMP_InputField idInputField;

    private void OnEnable()
    {
        idInputField.text = string.Format("Player {0}", Random.Range(1000, 10000));
    }

    public void Login()
    {
        // 텍스트가 없을 때
        if (idInputField.text == "")
        {
            return;
        }

        // 닉네임 지정
        PhotonNetwork.LocalPlayer.NickName = idInputField.text;
        // 접속을 신청
        PhotonNetwork.ConnectUsingSettings();
    }
}
