using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ObstacleManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    public float zSpawn = 0f;
    public float distance = 20f;
    public int numberofObstacles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    public MeshRenderer[] renderer;
    public Text score;
    public int obMoveTime;
    public int speedUpTime1;
    public int speed1;
    public int speedUpTime2;
    public int speed2;
    public Rigidbody player;
    public int obSideTime1;
    public int sideSpeed1;
    public int speedUpTime3;
    public int speed3;
    public int obSideTime2;
    public int sideSpeed2;
    public int speedUpTime4;
    public int speed4;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberofObstacles; i++)
        {
            SpawnObstacle(UnityEngine.Random.Range(0, obstaclePrefabs.Length));
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (playerTransform.position.z -20 > zSpawn - (numberofObstacles * distance))
        {
            SpawnObstacle(UnityEngine.Random.Range(0, obstaclePrefabs.Length));
            DeleteObstacle();
        }

        if(playerTransform.position.z > speedUpTime1)
        {
            player.GetComponent<PlayerMovement>().maxSpeed = speed1; 
        }

        if (playerTransform.position.z > obMoveTime)
        {
            foreach (GameObject obs in obstaclePrefabs)
            {
                Vector3 obsta = renderer[Array.IndexOf(obstaclePrefabs, obs)].bounds.size;
                if (obsta.x != 20)
                {
                    obs.GetComponent<ObstacleMovement>().enabled = true;
                }
            }
        }


        if (playerTransform.position.z > speedUpTime2)
        {
            player.GetComponent<PlayerMovement>().maxSpeed = speed2;
        }


        if (playerTransform.position.z > obSideTime1)
        {
            foreach (GameObject obs in obstaclePrefabs)
            {
                Vector3 obsta = renderer[Array.IndexOf(obstaclePrefabs, obs)].bounds.size;
                if (obsta.x != 20)
                {
                    obs.GetComponent<ObstacleMovement>().sideSpeed = sideSpeed1;
                }
            }
        }


        if (playerTransform.position.z > speedUpTime3)
        {
            player.GetComponent<PlayerMovement>().maxSpeed = speed3;
        }

        if (playerTransform.position.z > obSideTime2)
        {
            foreach (GameObject obs in obstaclePrefabs)
            {
                Vector3 obsta = renderer[Array.IndexOf(obstaclePrefabs, obs)].bounds.size;
                if (obsta.x != 20)
                {
                    obs.GetComponent<ObstacleMovement>().sideSpeed = sideSpeed2;
                }
            }
        }

        if (playerTransform.position.z > speedUpTime4)
        {
            player.GetComponent<PlayerMovement>().maxSpeed = speed4;
        }
    }

    public void SpawnObstacle(int obstacleIndex)
    {
        GameObject go = Instantiate(obstaclePrefabs[obstacleIndex], transform.forward * zSpawn, transform.rotation);
        Vector3 obst = renderer[obstacleIndex].bounds.size;

    
            go.transform.position = new Vector3(UnityEngine.Random.Range(-10 - go.transform.position.x + obst.x / 2, 10 + go.transform.position.x - obst.x / 2), go.transform.position.y, go.transform.position.z);
        
        activeTiles.Add(go);
        zSpawn += distance;
    }

    private void DeleteObstacle()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    public void reset()
    {

        foreach (GameObject obs in obstaclePrefabs)
        {
            obs.GetComponent<ObstacleMovement>().enabled = false;
            obs.GetComponent<ObstacleMovement>().sideSpeed = 10;
        }
    }
}
