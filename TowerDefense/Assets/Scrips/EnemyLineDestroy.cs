using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineDestroy : MonoBehaviour
{
    public LineRenderer esteCable;
    public ControladorConexiones controller;

    private void Start()
    {
        esteCable = GetComponent<LineRenderer>();
        controller = Camera.main.GetComponent<ControladorConexiones>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            controller.DestruirCable(esteCable);
        }
    }
}
