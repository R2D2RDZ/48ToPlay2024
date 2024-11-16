using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    //int[,] gridlock = new int[18,10];

    string filepath = "Assets\\Level0.txt";

    [SerializeField] GameObject[] Square;

    public Vector2[] NavPoints;
    void Start()
    {

        if (File.Exists(filepath))
        {
            try
            {
                string[] lineas = File.ReadAllLines(filepath);
                NavPoints = new Vector2[int.Parse(lineas[0])+1];
                // Procesar cada línea y asignar valores a la matriz
                for (int i = 0; i < 18; i++) // Filas
                {
                    //Debug.Log(lineas[i+1]);
                    string[] valores = lineas[i+1].Split(new char[] { ' ' });

                    for (int j = 0; j < 10; j++) // Columnas
                    {
                        Debug.LogWarning(valores[j]);
                        if (int.Parse(valores[j]) == 0)
                        {
                            Instantiate(Square[0], new Vector3(i, j, 0), Quaternion.identity);
                        }
                        else {
                            Instantiate(Square[1], new Vector3(i, j, 0), Quaternion.identity);
                            NavPoints[int.Parse(valores[j])] = new Vector2(i,j);
                            //int.Parse(valores[j])
                            //Debug.LogError(NavPoints[int.Parse(valores[j])].position);
                        }
                    }
                }

                // Mostrar la matriz cargada
                Debug.Log("Matriz cargada desde el archivo:");
            }
            catch (Exception ex)
            {
                Debug.Log("Error al leer el archivo o procesar los datos: " + ex.Message);
            }
        }
        else
        {
            Debug.Log("El archivo especificado no existe.");
            Debug.Log(Directory.GetCurrentDirectory());
        }
    }

}


