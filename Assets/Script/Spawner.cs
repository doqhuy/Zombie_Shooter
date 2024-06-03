using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawningRate = 2f; //Thời gian spawning
    public GameObject ZombiePrefab;
    public Transform[] SpawnPoints; //Điểm spawn
    public Player Player;

    private float LastSpawnTime;

    void Update()
    {
        if (Player == null) //Nếu player die
        {
            return;
        }
        if(LastSpawnTime + SpawningRate < Time.time) //Nếu thời gian spawn trước + thời gian spawning <time
        {
            var randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length - 1)]; //Chọn điểm Spawn ngẫu nhiên 
            Instantiate(ZombiePrefab, randomSpawnPoint.position, Quaternion.identity);   //Xác định điểm xuất hiện Prefab Zombie
            LastSpawnTime = Time.time;  //Xác định thời gian spawn
            SpawningRate *= 0.98f;
        }
    }
}
