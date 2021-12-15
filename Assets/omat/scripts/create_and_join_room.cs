using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//t‰m‰n avulla saadaan yhteys UI-elementteihin
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class create_and_join_room : MonoBehaviourPunCallbacks
{

    // createInput:iin syˆtet‰‰n uuden huoneen nimi
    // joinInput:iin syˆtet‰‰n olemassa olevan huoneen nimi
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    //T‰t‰ funktiota kutsutaan create-napilla. luo meille pelihuoneen
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        ExitGames.Client.Photon.Hashtable roomCustomProps = new ExitGames.Client.Photon.Hashtable();
        roomCustomProps.Add("PinkScore", 0);
        roomCustomProps.Add("BlueScore", 0);
        roomOptions.CustomRoomProperties = roomCustomProps;
        //T‰ll‰ k‰skyll‰ luodaan serverille uusi huone
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);



    }
    //  //T‰t‰ funktiota kutsutaan join-napilla. liityt‰‰n olemassa olevaan  pelihuoneeseen
    public void JoinRoom()
    {
        // t‰ll‰ k‰skyll‰ liityt‰‰n olemassa olevaan huoneeseen ja sulkujen sis‰‰n tulee huoneen nimi
        // joinInput sis‰lt‰‰ meid‰n huoneen nimen. N‰in k‰ytt‰j‰ voi syˆtt‰‰ haluamansa nimen.
        PhotonNetwork.JoinRoom(joinInput.text);

    }

    //t‰t‰ kutsutaan automaattisesti kun pelaaja yhdistyy pelihuoneeseen
    public override void OnJoinedRoom()
    {
        //meid‰n t‰ytyy k‰ytt‰‰ photonenginen omaa tapaa ladata  varsinainen peliscene
        //lainausmerkkien sis‰‰n varsinaisen peli-scenen nimi. Esim Game
        PhotonNetwork.LoadLevel("SampleScene");
    }

}
