using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Propiedades de la clase
    public int Hp { get; private set; }
    public int Electrum { get; private set; }

    // Instancia única
    private static Player instance;

    // Objeto para el bloqueo en caso de uso en hilos
    private static readonly object lockObj = new object();

    // Constructor privado para evitar instanciación externa
    private Player()
    {
        Hp = 100;       // Valor inicial de ejemplo
        Electrum = 50;  // Valor inicial de ejemplo
    }

    // Propiedad para obtener la única instancia
    public static Player Instance
    {
        get
        {
            // Implementación con bloqueo para asegurar que sea thread-safe
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Player();
                    }
                }
            }
            return instance;
        }
    }

    // Método para recibir daño
    public void DamageReceive(int damage)
    {
        Hp -= damage;
    }

    // Método para añadir electrum
    public void AddElectrum(int amount)
    {
        Electrum += amount;
    }
}
