using UnityEngine;

public class LightTower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Aca estoy verificando si el objeto que entra al collider tiene un componente "JuanitoManganito"
        // Cambien el nombre JuanitoManganito por el del public class del enemigo xD
        var enemy = other.GetComponent<JuanitoManganito>();
        if (enemy != null)
        {
            // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
            enemy.isVisible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Aca estoy verificando si el objeto que entra al collider tiene un componente "JuanitoManganito"
        // Cambien el nombre JuanitoManganito por el del public class del enemigo xD
        var enemy = other.GetComponent<JuanitoManganito>();
        if (enemy != null)
        {
            // Hace visible al enemigo para las unidades ofensivas, porque si no no lo ven y no pueden atacar
            enemy.isVisible = false;
        }
    }
}
