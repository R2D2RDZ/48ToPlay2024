using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ne : MonoBehaviour
{
    public void Start()
    {
        CambiarANivel1ConCarga();
    }
    public void CambiarANivel1ConCarga()
    {
        StartCoroutine(CargarEscenaConRetraso("Test Map")); // Llama a la corrutina
    }
    private IEnumerator CargarEscenaConRetraso(string escena)
    {
       //bia a la pantalla de carga
        yield return new WaitForSeconds(5); // Espera 5 segundos
        SceneManager.LoadScene(escena); // Luego carga la escena del juego
    }
}
