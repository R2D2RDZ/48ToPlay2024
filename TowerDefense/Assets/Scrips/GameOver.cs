using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para usar SceneManager

public class GameOver: MonoBehaviour
{
    public static float energiaTotalCentral = 100.0f;

    void Update()
    {
        if (energiaTotalCentral <= 0)
        {
            PausarYGameOver();
        }
    }

    void PausarYGameOver()
    {
        Time.timeScale = 0; // Pausa el juego
        SceneManager.LoadScene("Game Over"); // Cambia a la escena de Game Over
    }

    // Método para consumir energía (de ejemplo)
    public void ConsumirEnergia(float cantidad)
    {
        energiaTotalCentral -= cantidad;
        if (energiaTotalCentral < 0) energiaTotalCentral = 0;
    }
}

