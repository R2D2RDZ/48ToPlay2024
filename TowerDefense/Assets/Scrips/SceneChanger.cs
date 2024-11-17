using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para usar SceneManager

public class SceneChanger : MonoBehaviour
{
    public void CambiarANivel1ConCarga()
    {
        StartCoroutine(CargarEscenaConRetraso("Test Map")); // Llama a la corrutina
    }

    // Corrutina para manejar la pantalla de carga y el retraso
    private IEnumerator CargarEscenaConRetraso(string escena)
    {
        SceneManager.LoadScene("Carga"); // Cambia a la pantalla de carga
        yield return new WaitForSeconds(5); // Espera 5 segundos
        SceneManager.LoadScene(escena); // Luego carga la escena del juego
    }

    // Método para salir del juego
    public void Salir()
    {
        Application.Quit(); // Cierra el juego cuando se ejecuta
        Debug.Log("El juego se ha cerrado."); // Esto solo se verá en el editor de Unity
    }

    // Método para volver al nivel 1 desde la escena de "Game Over"
    public void VolverAlInicio()
    {
        Time.timeScale = 1; // Restablece el tiempo en caso de que el juego esté pausado
        SceneManager.LoadScene("Test Map"); // Carga la escena del nivel 1
    }

    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1; // Restablece el tiempo en caso de que el juego esté pausado
        SceneManager.LoadScene("PantalladeInicio"); // Asegúrate de que el nombre de la escena es correcto
    }
}


