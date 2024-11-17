using UnityEngine;

public class LightTower : MonoBehaviour
{
    public LightClass luz;

    private void Start()
    {
        luz = GetComponent<LightClass>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (luz.isEnabled)
        {
            // Aca estoy verificando si el objeto que entra al collider tiene un componente "EnemyAttributes"
            var enemy = other.GetComponent<EnemyAttributes>();
            if (enemy != null)
            {
                // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
                enemy.isVisible = true;
            }
        }
        else
        {
            var enemy = other.GetComponent<EnemyAttributes>();
            enemy.isVisible = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (luz.isEnabled)
        {
            // Aca estoy verificando si el objeto que entra al collider tiene un componente "EnemyAttributes"
            var enemy = other.GetComponent<EnemyAttributes>();
            if (enemy != null)
            {
                // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
                enemy.isVisible = false;
            }
        }
        else
        {
            var enemy = other.GetComponent<HackerAttributes>();
            if(enemy != null)
            {
                luz.isEnabled = true;
            }
        }
    }
}
