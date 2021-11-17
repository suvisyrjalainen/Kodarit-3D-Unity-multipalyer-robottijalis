using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class pallo : MonoBehaviourPun, IPunObservable
{
    // Start is called before the first frame update

    public GUISkin Pisteet1;
    private static int Joukkue1_pisteet = 0;
    string pisteet_1 = "Joukkue 1 Pisteet: " + Joukkue1_pisteet;

    public GUISkin Pisteet2;
    public TMP_Text tmtext;
    private static int Joukkue2_pisteet = 0;
    string pisteet_2 = "Joukkue 2 Pisteet: " + Joukkue2_pisteet;

    //private GUIStyle myStyle;

    CharacterController hahmokontrolleri;
    Rigidbody rigidbody;

    public void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    void Start()
    {
        hahmokontrolleri = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        GUIStyle localStyle = new GUIStyle(GUI.skin.label);
        localStyle.normal.textColor = Color.black;
        localStyle.fontSize = Screen.width / 40;

        GUI.skin = Pisteet1;
        GUI.Label(new Rect(Screen.width / 4, 0, Screen.width / 8, 100), pisteet_1, localStyle);

        GUI.skin = Pisteet2;
        GUI.Label(new Rect(Screen.width / 2, 0, Screen.width / 8, 100), pisteet_2, localStyle); }

    void OnTriggerEnter(Collider other)
    {
        Vector3 aloituspaikka = new Vector3(0, 0, 0);
        Vector3 nopeus = new Vector3(0, 0, 0);

        print("osui");
        if (other.gameObject.tag == "maali1")
        {
            print("Ykköset saivat maalin");
            
            Joukkue1_pisteet += 1;
            pisteet_1 = "Joukkue 1 Pisteet: " + Joukkue1_pisteet;

            Debug.Log(pisteet_1);
            tmtext.text = pisteet_1;


            transform.position = aloituspaikka;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        if (other.gameObject.tag == "maali2")
        {
            print("Kakkoset saivat maalin");
            Joukkue2_pisteet += 1;
            pisteet_2 = "Joukkue 2 Pisteet: " + Joukkue2_pisteet;

            Debug.Log(pisteet_2);
            tmtext.text = pisteet_2;

            transform.position = aloituspaikka;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

    }


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Joukkue1_pisteet);
            stream.SendNext(Joukkue2_pisteet);
            Debug.Log(info);
        }
        else if (stream.IsReading)
        {
            Joukkue1_pisteet = (int)stream.ReceiveNext();
            Joukkue2_pisteet = (int)stream.ReceiveNext();
            Debug.Log(info);
        }
    }
}
