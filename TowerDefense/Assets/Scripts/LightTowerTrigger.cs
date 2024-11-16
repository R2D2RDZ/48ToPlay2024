using UnityEngine;

public class LightTower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Aca estoy verificando si el objeto que entra al collider tiene un componente "EnemyAttributes"
        var enemy = other.GetComponent<EnemyAttributes>();
        Debug.Log("caca");
        if (enemy != null)
        {
            // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
            enemy.isVisible = true;
            enemy.Status(0.10f, 2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Aca estoy verificando si el objeto que entra al collider tiene un componente "EnemyAttributes"
        var enemy = other.GetComponent<EnemyAttributes>();
        if (enemy != null)
        {
            // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
            enemy.isVisible = false;
        }
    }
}
