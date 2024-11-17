using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject Tower;
    public Vector3 Position;

    public void SpawnTower()
    {
        Instantiate(Tower, Position, Quaternion.identity);
        Debug.LogWarning(Tower.name + " Created at " + Position);
    }
}