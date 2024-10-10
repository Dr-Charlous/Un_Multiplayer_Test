using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private PlayerController _player;

    private void Start()
    {
        _player = GetComponent<PlayerController>();

        Color playerColor = Random.ColorHSV(); // Exemple de couleur
        Hashtable playerProperties = new Hashtable { { "PlayerColor", ColorUtility.ToHtmlStringRGB(playerColor) } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);

        _player.SpriteRenderer.color = playerColor;
    }

    public override void OnPlayerPropertiesUpdate(Player player, Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(player, changedProps);

        if (changedProps.ContainsKey("PlayerColor"))
        {
            string colorString = (string)changedProps["PlayerColor"];
            Color playerColor = Color.white;
            ColorUtility.TryParseHtmlString("#" + colorString, out playerColor);

            if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                _player.SpriteRenderer.color = playerColor;
            }
        }
    }
}