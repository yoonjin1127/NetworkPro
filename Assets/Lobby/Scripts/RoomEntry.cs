using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomEntry : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text currentPlayer;
    [SerializeField] Button joinRoomButton;

    private RoomInfo info;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        info = roomInfo;
        roomName.text = roomInfo.Name;
        currentPlayer.text = $"{roomInfo.PlayerCount} / {roomInfo.MaxPlayers}";
        joinRoomButton.interactable = roomInfo.PlayerCount < roomInfo.MaxPlayers;
    }

    public void JoinRoom()
    {
        PhotonNetwork.LeaveLobby();
        // 이 방에 들어가겠다고 신청
        PhotonNetwork.JoinRoom(info.Name);
    }
}
