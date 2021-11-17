using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//t‰m‰n avulla saadaan yhteys UI-elementteihin
using UnityEngine.UI;
using Photon.Pun;
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
        // t‰ll‰ k‰skyll‰ luodaan uusi huone ja sulkujen sis‰‰n tulee huoneen nimi
        // createInput sis‰lt‰‰ meid‰n uuden huoneen nimen. N‰in k‰ytt‰j‰ voi syˆtt‰‰ haluamansa nimen.
        PhotonNetwork.CreateRoom(createInput.text);


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
