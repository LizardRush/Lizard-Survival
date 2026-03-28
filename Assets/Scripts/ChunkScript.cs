using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ChunkScript :NetworkBehaviour
{
    public MapGenerate mapGenerate;
    public void Setup(MapGenerate map)
    {
        Debug.Log("xdrxgfhtcgkjlm;");
        mapGenerate = map;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mapGenerate.CreateNeighbors(transform.position);
    }
}
