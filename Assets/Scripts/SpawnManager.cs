using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Spawns;

    public GameObject Cube;

    private void Awake()
    {
        Vector3 randomPosition = Spawns[Random.Range(0, Spawns.Length)].transform.localPosition;

        PhotonNetwork.Instantiate(Cube.name, randomPosition, Quaternion.identity);
    }
}
