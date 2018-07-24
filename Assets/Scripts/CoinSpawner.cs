using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoinSpawner : NetworkBehaviour
{

    public GameObject CoinPrefab;
    public int numberOfCoins;

    //VIrtual Function
    //Server starts listening to the Network
    public override void OnStartServer() //similar to OnStartLocalPlayer
    {
        //When server starts --> random number of enemies at a random position and rotation
        //Spawned through NetworkServer.Spawn(enemy)
        for (int i = 0; i < numberOfCoins; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(50f, 750f),
                //Random.Range(1.0f, 8.0f),
                25,
                Random.Range(50.0f, 730.0f));

            var spawnRotation = Quaternion.Euler(
                0.0f,
                Random.Range(0, 180),
                0.0f);

            var coin = (GameObject)Instantiate(CoinPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(coin);
        }
    }
}
