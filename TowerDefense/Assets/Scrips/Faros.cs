using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Faros : MonoBehaviour
{
    public CentralElectrica centralElectrica;
    public CentralElectrica energiaTotalCentral;
    public float EnergiaTotal;
    public List<KarenTorretasPruebas> torretasConectadas;
    private bool estaConectada = false; // Indica si la bobina est� conectada a la Central El�ctrica

    void Start()
    {
        torretasConectadas = new List<KarenTorretasPruebas>();
        EnergiaTotal = energiaTotalCentral.energiaTotalCentral;
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        EnergiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina est� activada porque est� conectada a la Central
        ActualizarEnergiaTorreta();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 1");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("GunClass"))
        {
            KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
            if (torreta != null && !torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Add(torreta);
                ActualizarEnergiaTorreta();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 2");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("GunClass"))
        {
            KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
            if (torreta != null && torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Remove(torreta);
                ActualizarEnergiaTorreta();
            }
        }
    }

    public void ActualizarEnergiaTorreta()
    {
        if (!estaConectada || torretasConectadas.Count == 0)
        {
            Debug.Log("La Bobina no est� conectada o no hay torretas en el rango.");
            return;
        }

        float energiaDisponible = EnergiaTotal;
        foreach (KarenTorretasPruebas torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.energyConsumed)
            {
                torreta.Energia = torreta.energyConsumed;
                energiaDisponible -= torreta.energyConsumed;
                Debug.Log($"Torreta: {torreta.name}: Activada, energ�a restante: {energiaDisponible}%");
            }
            else
            {
                torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energ�a suficiente.");
            }
        }
    }
}
