using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/*public class Faros : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public CentralElectrica centralElectrica;
    public List<KarenTorretasPruebas> torretasConectadas;
    private bool estaConectada = false; // Indica si la bobina est� conectada a la Central El�ctrica

    void Start()
    {
        torretasConectadas = new List<KarenTorretasPruebas>();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        energiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina est� activada porque est� conectada a la Central
        ActualizarEnergiaTorreta();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
        if (torreta != null && !torretasConectadas.Contains(torreta))
        {
            torretasConectadas.Add(torreta);
            ActualizarEnergiaTorreta();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
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
            Debug.Log("La Bobina no est� conectada o no hay torretas en el rango.");
            return;
        }

        float energiaDisponible = energiaTotal;
        foreach (KarenTorretasPruebas torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia;
                energiaDisponible -= torreta.ConsumoEnergia;
                Debug.Log($"Torreta: {torreta.name}: Activada, energ�a restante: {energiaDisponible}%");
            }
            else
            {
                torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energ�a suficiente.");
            }
        }
    }
}*/


public class Faros : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public CentralElectrica centralElectrica;
    public List<KarenTorretasPruebas> torretasConectadas;
    private bool estaConectada = false; // Indica si la bobina est� conectada a la Central El�ctrica

    void Start()
    {
        torretasConectadas = new List<KarenTorretasPruebas>();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        energiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina est� activada porque est� conectada a la Central
        ActualizarEnergiaTorreta();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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

        float energiaDisponible = energiaTotal;
        foreach (KarenTorretasPruebas torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia;
                energiaDisponible -= torreta.ConsumoEnergia;
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







