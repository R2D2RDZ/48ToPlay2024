using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CentralElectrica : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public List<Faros> bobinasConectadas;

    void Start()
    {
        bobinasConectadas = new List<Faros>();
    }

    public void ConsumirEnergia(float cantidad)
    {
        energiaTotal -= cantidad;
        if (energiaTotal < 0) energiaTotal = 0;

        // Actualiza la energía en todas las bobinas conectadas
        foreach (Faros bobina in bobinasConectadas)
        {
            bobina.ActualizarEnergiaDesdeCentral(energiaTotal);
        }
    }

    public void ConectarBobina(Faros bobina)
    {
        if (!bobinasConectadas.Contains(bobina))
        {
            bobinasConectadas.Add(bobina);
            bobina.ActualizarEnergiaDesdeCentral(energiaTotal);
        }
    }
}


