using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{

    SpawnPoint SpawnPoint;

    void Start()
    {
        SpawnPoint = GameObject.FindObjectOfType<SpawnPoint>();
        CreatePlayer();

    }


    public void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Ball"), SpawnPoint.transform.position, Quaternion.identity);
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "StrokeAngleIndicator"), this.transform.position, Quaternion.identity);
    }
}
