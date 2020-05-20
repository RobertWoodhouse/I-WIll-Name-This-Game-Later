using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterObstacles : MonoBehaviour
{
    public static bool IsStarterDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        IsStarterDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //SwitchOnObstacleSpawn("StarterObstacles");
        SwitchOnObstacleSpawn();
    }

    public void SwitchOnObstacleSpawn(string objectTag)
    {
        var count = GameObject.FindGameObjectsWithTag(objectTag).Length;
        print("(" + objectTag + ") Tag | Count = " + count);
        if (count <= 0) IsStarterDestroyed = true;
    }

    public void SwitchOnObstacleSpawn()
    {
        var count = GameObject.FindGameObjectsWithTag("StarterObstacles").Length + GameObject.FindGameObjectsWithTag("StarterExpPower").Length + GameObject.FindGameObjectsWithTag("StarterExpSpeed").Length;
        print("Starer Tag Count = " + count);
        if (count <= 0) IsStarterDestroyed = true;
    }
}
