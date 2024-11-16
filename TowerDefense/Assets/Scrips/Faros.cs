using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/*public class Faros : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public CentralElectrica centralElectrica;
    public List<GunClass> torretasConectadas;
    private bool estaConectada = false; // Indica si la bobina está conectada a la Central Eléctrica

    void Start()
    {
        torretasConectadas = new List<GunClass>();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        energiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina está activada porque está conectada a la Central
        ActualizarEnergiaTorreta();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GunClass torreta = other.GetComponent<GunClass>();
        if (torreta != null && !torretasConectadas.Contains(torreta))
        {
            torretasConectadas.Add(torreta);
            ActualizarEnergiaTorreta();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GunClass torreta = other.GetComponent<GunClass>();
        if (torreta != null && torretasConectadas.Contains(torreta))
        {
            torretasConectadas.Remove(torreta);
            ActualizarEnergiaTorreta();
        }
    }

    public void ActualizarEnergiaTorreta()
    {
        if (!estaConectada || torretasConectadas.Count == 0)
        {
            Debug.Log("La Bobina no está conectada o no hay torretas en el rango.");
            return;
        }

        float energiaDisponible = energiaTotal;
        foreach (GunClass torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.energyConsumed)
            {
                torreta.Energia = torreta.energyConsumed;
                energiaDisponible -= torreta.energyConsumed;
                Debug.Log($"Torreta: {torreta.name}: Activada, energía restante: {energiaDisponible}%");
            }
            else
            {
                torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energía suficiente.");
            }
        }
    }
}*/



public class Faros : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public CentralElectrica centralElectrica;
    public List<KarenTorretasPruebas> torretasConectadas;
    private bool estaConectada = false; // Indica si la bobina está conectada a la Central Eléctrica

    void Start()
    {
        torretasConectadas = new List<KarenTorretasPruebas>();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        energiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina está activada porque está conectada a la Central
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
            Debug.Log("La Bobina no está conectada o no hay torretas en el rango.");
            return;
        }

        float energiaDisponible = energiaTotal;
        foreach (KarenTorretasPruebas torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.energyConsumed)
            {
                torreta.Energia = torreta.energyConsumed;
                energiaDisponible -= torreta.energyConsumed;
                Debug.Log($"Torreta: {torreta.name}: Activada, energía restante: {energiaDisponible}%");
            }
            else
            {
                torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energía suficiente.");
            }
        }
    }
}
