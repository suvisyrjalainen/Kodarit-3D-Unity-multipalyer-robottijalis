using System.Collections.Generic;
using UnityEngine;
//p‰‰st‰‰n k‰siksi Photon Engineen
using Photon.Pun;
//t‰ll‰ ladataan unityn sis‰ll‰ Scenej‰
using UnityEngine.SceneManagement;

public class connect_to_server : MonoBehaviourPunCallbacks
{
	private void Start()
	{
		//t‰m‰ yhdist‰‰ meid‰t photon servuun heti kun t‰m‰ kyseinen scene ladataan.
		PhotonNetwork.ConnectUsingSettings();
	}

	public override void OnConnectedToMaster()
	{
		// yhdist‰‰ meid‰t lobbyyn
		PhotonNetwork.JoinLobby();
	}

	public override void OnJoinedLobby()
	{
		//kun ollaan yhdistetty lobbyyn niin ladataan unityss‰ meid‰n
		//varsinainen lobby-scene. ""-merkkien sis‰‰n tulee scenen nimi.
		SceneManager.LoadScene("lobby");
	}
}
