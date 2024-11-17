using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central2
{
    //public float energiaTotalCentral { get; private set; }
    private static Central2 _instance = null;

    // Objeto para el bloqueo en caso de uso en hilos
    private static readonly object lockObj = new object();

    public float energiaMax { get; private set; }
    public float energiaDisponible { get; private set; }

    // Constructor privado para evitar instanciación externa
    private Central2()
    {
        CentralElectrica.energiaTotalCentral = 100.0f;
        energiaMax = 100f;
        energiaDisponible = energiaMax;
    }

    // Propiedad para obtener la única instancia
    public static Central2 instance
    {
        get
        {
            // Implementación con bloqueo para asegurar que sea thread-safe
            if (_instance == null)
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new Central2();
                    }
                }
            }
            return _instance;
        }
    }

    public void GastarEnergia(float Energia)
    {
        CentralElectrica.energiaTotalCentral -= Energia;
        energiaDisponible -= Energia;

    }

    public void ResetEenergia()
    {
        CentralElectrica.energiaTotalCentral = 100.0f;
        energiaDisponible = energiaMax;
    }
}
