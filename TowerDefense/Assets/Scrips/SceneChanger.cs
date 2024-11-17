using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para usar SceneManager

public class SceneChanger : MonoBehaviour
{
    // M�todo para cambiar a la escena del nivel 1
    public void CambiarANivel1()
    {
        SceneManager.LoadScene("Test Map");
    }

    // M�todo para salir del juego
    public void Salir()
    {
        Application.Quit(); // Cierra el juego cuando se ejecuta
        Debug.Log("El juego se ha cerrado."); // Esto solo se ver� en el editor de Unity
    }

    // M�todo para volver al nivel 1 desde la escena de "Game Over"
    public void VolverAlInicio()
    {
        Time.timeScale = 1; // Restablece el tiempo en caso de que el juego est� pausado
        SceneManager.LoadScene("Test Map"); // Carga la escena del nivel 1
    }

    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1; // Restablece el tiempo en caso de que el juego est� pausado
        SceneManager.LoadScene("PantalladeInicio"); // Aseg�rate de que el nombre de la escena es correcto
    }
}


