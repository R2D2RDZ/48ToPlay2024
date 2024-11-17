using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerAttributes : MonoBehaviour
{
    private bool isColliding = false;
    public EnemyAttributes hacker;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var luz = other.GetComponent<LightClass>();
        if (luz != null)
        {
            Debug.Log("ORALEEEE");
            // Si es luz si is colliding
            isColliding = true;
            luz.isEnabled = false;
            this.GetComponentInParent<EnemyAttributes>().speed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var luz = other.GetComponent<LightClass>();
        if (luz != null)
        {
            // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
            luz.isEnabled = true;
        }
    }
}
