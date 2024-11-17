using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    // Propiedades de la clase
    public float Hp { get; private set; }
    public int Electrum { get; private set; }

    // Instancia �nica
    private static Player instance;

    // Objeto para el bloqueo en caso de uso en hilos
    private static readonly object lockObj = new object();

    // Constructor privado para evitar instanciaci�n externa
    private Player()
    {
        Hp = 100;       // Valor inicial de ejemplo
        Electrum = 50;  // Valor inicial de ejemplo
    }

    // Propiedad para obtener la �nica instancia
    public static Player Instance
    {
        get
        {
            // Implementaci�n con bloqueo para asegurar que sea thread-safe
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

    // M�todo para recibir da�o
    public void DamageReceive(float damage)
    {
        Hp -= damage;
        if(Hp <= 0){
            gameOver();
        }
    }

    // M�todo para a�adir electrum
    public void AddElectrum(int amount)
    {
        Electrum += amount;
    }

    public void gameOver(){
        //en el canvas le dice que ya perdiste
    }
}
