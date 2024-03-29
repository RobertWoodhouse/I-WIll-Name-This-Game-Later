﻿using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float timer = 16.0f, respawnTime = 2.0f, respawnTimeMin = 0.5f, respawnTimeMax = 1.5f;

    [SerializeField]
    private GameObject[] _obstacles, _obstaclesDestructable;

    [SerializeField]
    private GameObject _obstacleSpawnPoint;

    private static int _SpawnSwitchCounter = 5;

    void Update()
    {
        if (timer <= 0f && StarterObstacles.IsStarterDestroyed == true) // Spawn after StartObstacles have been destroyed
        {
            SpawnObject(_obstacleSpawnPoint);
            timer = Random.Range(respawnTimeMin, respawnTimeMax);
        }
        else timer -= Time.deltaTime;
    }

    public void SpawnObject(GameObject pos)
    {
        int rangeIndex;
        System.Random rand = new System.Random();

        GameObject obstacleClone;

        if (_SpawnSwitchCounter >= 0)
        {
            obstacleClone = Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], new Vector3(0f, 4f), Quaternion.identity);
            _SpawnSwitchCounter--;
        }
        else
        {
            obstacleClone = Instantiate(_obstaclesDestructable[Random.Range(0, _obstaclesDestructable.Length)], new Vector3(0f, 4f), Quaternion.identity);
            _SpawnSwitchCounter = Random.Range(5, 7);
        }

        if (transform.parent != null)
        {
            rangeIndex = rand.Next(obstacleClone.GetComponentInParent<ObjectSpawnPos>().SpawnXPosRange.Length);
            obstacleClone.transform.position = new Vector3(obstacleClone.GetComponentInParent<ObjectSpawnPos>().SpawnXPosRange[rangeIndex], pos.transform.localPosition.y);
        }
        else
        {
            rangeIndex = rand.Next(obstacleClone.GetComponent<ObjectSpawnPos>().SpawnXPosRange.Length);
            obstacleClone.transform.position = new Vector3(obstacleClone.GetComponent<ObjectSpawnPos>().SpawnXPosRange[rangeIndex], pos.transform.localPosition.y);
        }
    }
}