using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MapGenerate : NetworkBehaviour
{
    [SerializeField] private GameObject[] chunks;

    [SerializeField] private int height;
    [SerializeField] private int width;
    void GenerateChunk(Vector3 spawnPos)
    {
        GameObject chunk = chunks[Random.Range(0,chunks.Length)];
        Instantiate(chunk, spawnPos, Quaternion.identity);
        chunk.GetComponent<NetworkObject>().Spawn();
        chunk.GetComponent<ChunkScript>().mapGenerate = this;
    }
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;
        GenerateChunk(new Vector3(0, 0, 0));
    }
    public void CreateNeighbors(Vector3 position)
    {
        GenerateChunk(position + new Vector3(0, height, 0));
        GenerateChunk(position + new Vector3(0, -height, 0));
        GenerateChunk(position + new Vector3(width, 0, 0));
        GenerateChunk(position + new Vector3(-width, 0, 0));
        GenerateChunk(position + new Vector3(width, height, 0));
        GenerateChunk(position + new Vector3(width, -height, 0));
        GenerateChunk(position + new Vector3(-width, height, 0));
        GenerateChunk(position + new Vector3(-width, -height, 0));
    }
    
}
