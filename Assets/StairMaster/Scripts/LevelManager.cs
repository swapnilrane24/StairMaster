using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //variables to store the reference to normal ground and finish ground prefab
    [SerializeField] private GameObject groundPrefab, finishGroundPrefab;
    //array of gameobject to store enemy ground prefabs
    [SerializeField] private GameObject[] enemyPrefabs;
    //variables to store the reference to player prefab
    [SerializeField] private GameObject playerPrefab;

    //variable which store the vector spawn position of ground
    private Vector3 groundSpawnPosition = new Vector3(0, 0, -2);

    void Start()
    {
        //we loop 5 times in For Loop
        for (int i = 0; i < 5; i++)
        {
            SpawnGround();  //1st we spawn the normal ground
            SpawnEnemy();   //2nd we spawn the enemy ground
        }

        SpawnGround();          //spawn the normal ground
        SpawnFinishGround();    //spawn the finish ground
        SpawnPlayer();          //spawn the player
    }

    //method to spawn the ground object
    void SpawnGround()
    {
        //We Instantiate ground at groundSpawnPosition position with its rotation similar to prefab rotation
        Instantiate(groundPrefab, groundSpawnPosition, Quaternion.identity);
        //we increase the groundSpawnPosition by 12 as our prefab size is 12
        groundSpawnPosition += Vector3.forward * 12;
    }

    //method to spawn the finish ground object
    void SpawnFinishGround()
    {
        //We Instantiate finish ground at groundSpawnPosition position with its rotation similar to prefab rotation
        Instantiate(finishGroundPrefab, groundSpawnPosition, Quaternion.identity);
    }

    //method to spawn the enemy ground object
    void SpawnEnemy()
    {
        //We Instantiate enemy ground at groundSpawnPosition position with its rotation similar to prefab rotation
        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], groundSpawnPosition, Quaternion.identity);
        groundSpawnPosition += Vector3.forward * 12;
    }

    //method to spawn the Player object
    void SpawnPlayer()
    {
        //We Instantiate Player at Vector3(0,0,0) position with its rotation similar to prefab rotation
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }
}
