using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MapGenerate : NetworkBehaviour
{
    [SerializeField] private GameObject[] chunks;

    void GenerateChunk(Vector3 spawnPos)
    {
        GameObject chunk = chunks[Random.Range(0,chunks.Length)];
        Instantiate(chunk, spawnPos, Quaternion.identity);
    }
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;
        GenerateChunk(new Vector3(0, 0, 0));
    }
}
