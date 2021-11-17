using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class jalkapalloilija : MonoBehaviour
{
    public float nopeuskerroin = 5;
    private float horisontaalinenPyorinta = 0;

    public float painovoima = 50f;

    public int jokuVaan = 1;

    private Animator anim;

    PhotonView pView;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponentInChildren<Animator>();

        //Material team_color = Resources.Load("red_team", typeof(Material)) as Material;
        //GetComponent<Renderer>().material = team_color;

        pView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pView.IsMine)
        {
            //Eteen ja sivulle liikkuminen
            CharacterController hahmokontrolleri = GetComponent<CharacterController>();
            Vector3 nopeus = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical") * 3);

            //Hiirellä kääntyminen
            horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
            transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);
            nopeus = transform.rotation * nopeus;

            //painovoima, joka tuo pelaajaa alaspäin
            //nopeus.y = nopeus.y - painovoima * Time.deltaTime;
            nopeus.y = nopeus.y - painovoima;

            //liikkumisen pääkoodi
            hahmokontrolleri.Move(nopeus * Time.deltaTime * nopeuskerroin);

            //Animaatioiden käynnistys

            if (Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    anim.SetBool("run", true);
                }
                else
                {
                    anim.SetBool("background_walk", true);
                }
            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("background_walk", false);
            }



        }
    }

}
