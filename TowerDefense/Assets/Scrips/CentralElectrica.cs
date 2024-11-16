using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralElectrica : MonoBehaviour
{
    public float energiaTotalCentral = 100.0f;
    public List<Faros> bobinasConectadas;

    void Start()
    {
        bobinasConectadas = new List<Faros>();
    }

    public void ConsumirEnergia(float cantidad)
    {
        energiaTotalCentral -= cantidad;
        if (energiaTotalCentral < 0) energiaTotalCentral = 0;

        // Actualiza la energía en todas las bobinas conectadas
        foreach (Faros bobina in bobinasConectadas)
        {
            bobina.ActualizarEnergiaDesdeCentral(energiaTotalCentral);
        }
    }

    public void ConectarBobina(Faros bobina)
    {
        if (!bobinasConectadas.Contains(bobina))
        {
            bobinasConectadas.Add(bobina);
            bobina.ActualizarEnergiaDesdeCentral(energiaTotalCentral);
        }
    }
}