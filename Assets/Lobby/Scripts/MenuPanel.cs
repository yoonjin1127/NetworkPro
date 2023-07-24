using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject createRoomPanel;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_InputField maxPlayerInputField;

    public void CreateRoomMenu()
    {
        createRoomPanel.SetActive(true);
    }

    public void CreateRoomConfirm()
    {
        string roomName = roomNameInputField.text;
        if (roomName == "")
            roomName = $"Room {Random.Range(1000, 10000)}";

        int maxPlayer = maxPlayerInputField.text == "" ? 8 : int.Parse(maxPlayerInputField.text);
        // �ּ� �ִ� ����
        maxPlayer = Mathf.Clamp(maxPlayer, 1, 8);

        // �ɼ� ���� �� �游���
        RoomOptions options = new RoomOptions { MaxPlayers = maxPlayer };
        PhotonNetwork.CreateRoom(roomName);
    }

    public void CreateRoomCancel()
    {
        createRoomPanel.SetActive(false);
    }

    public void RandomMatching()
    {
        // �������� ����
        string name = $"Room {Random.Range(1000, 10000)}";
        RoomOptions options = new RoomOptions { MaxPlayers = 8 };
        PhotonNetwork.JoinRandomOrCreateRoom(roomName: name, roomOptions: options);
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public void Logout()
    {
        PhotonNetwork.Disconnect();
    }
}
