using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Bobina : MonoBehaviour
{
    // Propiedad para mantener la energía al 100%
    public float energiaTotal = 100.0f;

    // Lista de torretas conectadas
    public List<Torreta> torretasConectadas;

    // Constructor para inicializar la Bobina
    public Bobina()
    {
        torretasConectadas = new List<Torreta>();
    }

    // Método para conectar una torreta a la Bobina
    public void ConectarTorreta(Torreta nuevaTorreta)
    {
        torretasConectadas.Add(nuevaTorreta);
        ActualizarEnergiaTorreta();
    }

    // Método para desconectar una torreta de la Bobina
    public void DesconectarTorreta(Torreta torreta)
    {
        torretasConectadas.Remove(torreta);
        ActualizarEnergiaTorreta();
    }

    // Método para distribuir la energía según las necesidades de cada torreta
    private void ActualizarEnergiaTorreta()
    {
        float energiaDisponible = energiaTotal;

        // Intenta suministrar energía a cada torreta en el orden de conexión
        foreach (Torreta torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia; // Suministra la energía requerida
                energiaDisponible -= torreta.ConsumoEnergia; // Resta la energía suministrada
            }
            else
            {
                torreta.Energia = 0; // No hay suficiente energía para esta torreta
            }
        }
    }
}

// Clase para representar una torreta
public class Torreta
{
    public float ConsumoEnergia { get; private set; } // Energía que necesita esta torreta
    public float Energia { get; set; } // Energía asignada a la torreta

    // Constructor para inicializar una torreta con un consumo específico
    public Torreta(float consumoEnergia)
    {
        ConsumoEnergia = consumoEnergia;
        Energia = 0;
    }
}

public class Bobina : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public List<Torreta> torretasConectadas;

    void Start()
    {
        ActualizarEnergiaTorreta();
    }

    public void ConectarTorreta(Torreta nuevaTorreta)
    {
        if (torretasConectadas == null)
        {
            torretasConectadas = new List<Torreta>();
        }

        torretasConectadas.Add(nuevaTorreta);
        ActualizarEnergiaTorreta();
    }

    /*private void ActualizarEnergiaTorreta()
    {
        float energiaDisponible = energiaTotal;
        foreach (Torreta torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia;
                energiaDisponible -= torreta.ConsumoEnergia;
            }
            else
            {
                torreta.Energia = 0;
            }
        }
    }
    private void ActualizarEnergiaTorreta()
    {
        float energiaDisponible = energiaTotal;
        foreach (Torreta torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia;
                energiaDisponible -= torreta.ConsumoEnergia;
            }
            else
            {
                torreta.Energia = 0;
            }

            // Mostrar la energía asignada en la Consola
            Debug.Log($"Torreta: {torreta.name}, Energía Asignada: {torreta.Energia}");
        }
    }

}*/

public class Faros : MonoBehaviour
{
    public float energiaTotal = 100.0f;
    public List<KarenTorretasPruebas> torretasConectadas;

    void Start()
    {
        torretasConectadas = new List<KarenTorretasPruebas>();
    }

    // Método llamado cuando un objeto entra en el rango de la Bobina
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro al Trigger1");
        KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
        if (torreta != null && torretasConectadas.Count >0 &&!torretasConectadas.Contains(torreta))
        {
            ConectarTorreta(torreta);
        }
    }

    // Método llamado cuando un objeto sale del rango de la Bobina
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Entro al Trigger2");
        KarenTorretasPruebas torreta = other.GetComponent<KarenTorretasPruebas>();
        if (torreta != null && torretasConectadas.Contains(torreta))
        {
            DesconectarTorreta(torreta);
        }
    }

    public void ConectarTorreta(KarenTorretasPruebas nuevaTorreta)
    {
        torretasConectadas.Add(nuevaTorreta);
        ActualizarEnergiaTorreta();
    }

    public void DesconectarTorreta(KarenTorretasPruebas torreta)
    {
        torretasConectadas.Remove(torreta);
        ActualizarEnergiaTorreta();
    }

    private void ActualizarEnergiaTorreta()
    {
        if (torretasConectadas.Count == 0)
        {
            Debug.Log("No se han detectado torretas en el rango.");
            return; // Salir del método si no hay torretas conectadas
        }

        float energiaDisponible = energiaTotal;

        foreach (KarenTorretasPruebas torreta in torretasConectadas)
        {
            if (energiaDisponible >= torreta.ConsumoEnergia)
            {
                torreta.Energia = torreta.ConsumoEnergia;
                energiaDisponible -= torreta.ConsumoEnergia;
                Debug.Log($"Torreta: {torreta.name}: {torreta.Energia} de energía");
            }
            else
            {
                torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energía");
            }
        }
    }


}


