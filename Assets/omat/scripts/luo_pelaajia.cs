using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class luo_pelaajia : MonoBehaviour
{
    public GameObject playerPink;
    public GameObject playerBlue;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update

    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minZ, maxZ));
        Vector3 spawnPosition = new Vector3(randomPosition.x, transform.position.y + 3, randomPosition.x);

        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);

        
        if (PhotonNetwork.LocalPlayer.ActorNumber % 2 == 0)
        {
            PhotonNetwork.Instantiate(playerPink.name, spawnPosition, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(playerBlue.name, spawnPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
