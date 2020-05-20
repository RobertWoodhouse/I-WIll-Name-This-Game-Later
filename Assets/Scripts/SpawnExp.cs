using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExp : MonoBehaviour
{
    public float time = 10.0f, respawnTime = 10.0f;

    private float[] _spawnXPosRange = new[] { -2f, -1f, 0f, 1f, 2f }; // TODO set range for Exp

    [SerializeField]
    private GameObject[] _exp;

    [SerializeField]
    private GameObject _expSpawnPoint;

    void Update()
    {
        //if (time <= 0f)
        if (time <= 0f && StarterObstacles.IsStarterDestroyed == true) // TODO Add starter Starter Obstacles 
        {
            SpawnObject(_expSpawnPoint);
            time = respawnTime;
        }
        else time -= Time.deltaTime;
    }

    public void SpawnObject(GameObject pos)
    {
        System.Random rand = new System.Random();
        GameObject _expClone = Instantiate(_exp[Random.Range(0, _exp.Length)], new Vector3(0f, 4f), Quaternion.identity);
        int rangeIndex = rand.Next(_spawnXPosRange.Length);
        _expClone.transform.position = new Vector3(_spawnXPosRange[rangeIndex], pos.transform.localPosition.y);
        respawnTime = Random.Range(15, 30); // Set respawn time to random range
    }
}
