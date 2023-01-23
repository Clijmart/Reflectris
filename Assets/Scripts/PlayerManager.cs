using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Vector3 spawnPosition;

    private GameObject player;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnPlayerBall()
    {
        player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
