using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpawner : MonoBehaviour
{
    public GameObject box;
    public Vector3 spawnOffset;
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawCube(transform.localPosition + spawnOffset, new Vector3(1, 1, 1));
    }
    public void SpawnItem()
    {
        Instantiate(box, transform.localPosition + spawnOffset, Quaternion.identity);
    }
}