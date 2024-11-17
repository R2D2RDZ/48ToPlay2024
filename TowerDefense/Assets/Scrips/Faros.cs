using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/*public class Faros : MonoBehaviour
{
    public CentralElectrica centralElectrica;
    //public CentralElectrica energiaTotalCentral;
    public float EnergiaTotal;
    public static List<GunClass> torretasConectadas = new();
    private bool estaConectada = false; // Indica si la bobina está conectada a la Central Eléctrica
    public List<Faros> bobinasConectadas = new List<Faros>();

    void Start()
    {
        //torretasConectadas = new List<GunClass>();
        EnergiaTotal = CentralElectrica.energiaTotalCentral;
        if (centralElectrica != null)
        {
            ConectarACentral();
        }
    }

    public void ConectarACentral()
    {
        estaConectada = true;
        PropagarConexion();
        ActualizarEnergiaTorreta();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        EnergiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina está activada porque está conectada a la Central
        ActualizarEnergiaTorreta();
        PropagarConexion();
    }

    public void ConectarABobina(Faros otraBobina)
    {
        if (!bobinasConectadas.Contains(otraBobina))
        {
            bobinasConectadas.Add(otraBobina);
            if (estaConectada) // Si esta Bobina ya está conectada, conecta la otra
            {
                otraBobina.ActualizarEnergiaDesdeCentral(EnergiaTotal);
            }
        }
    }

    private void PropagarConexion()
    {
        foreach (Faros bobina in bobinasConectadas)
        {
            if (!bobina.estaConectada) // Solo propaga si la Bobina aún no está conectada
            {
                bobina.estaConectada = true;
                bobina.EnergiaTotal = EnergiaTotal;
                bobina.PropagarConexion(); // Llamada recursiva para propagar el estado
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 1");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("Gun"))
        {
            GunClass torreta = other.GetComponent<GunClass>();
            if (torreta == null)
            {
                Debug.LogWarning("No encontro la clase GunClass");
                return;
            }
            if (!torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Add(torreta);
                ActualizarEnergiaTorreta();
            }
            else
            {
                Debug.Log("Ya estaba registrada");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 2");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("Gun"))
        {
            GunClass torreta = other.GetComponent<GunClass>();
            if (torreta == null)
            {
                Debug.LogWarning("No encontro la clase GunClass");
                return;
            }
            if (torretasConectadas.Contains(torreta))
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

        //float energiaDisponible = EnergiaTotal;
        Central2.instance.ResetEenergia();
        foreach (GunClass torreta in torretasConectadas)
        {
            if (CentralElectrica.energiaTotalCentral >= torreta.energyConsumed)
            {
                //torreta.Energia = torreta.energyConsumed;
                //energiaDisponible -= torreta.energyConsumed;
                Central2.instance.GastarEnergia(torreta.energyConsumed);
                Debug.Log($"Torreta: {torreta.name}: Activada, energía restante: {CentralElectrica.energiaTotalCentral}%");
            }
            else
            {
                //torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energía suficiente.");
            }
        }
    }
}*/

public class Faros : MonoBehaviour
{
    public CentralElectrica centralElectrica;
    //public CentralElectrica energiaTotalCentral;
    public float EnergiaTotal;
    public static List<GunClass> torretasConectadas = new();
    private bool estaConectada = false; // Indica si la bobina está conectada a la Central Eléctrica
    public List<Faros> bobinasConectadas = new List<Faros>();

    void Start()
    {
        //torretasConectadas = new List<GunClass>();
        EnergiaTotal = CentralElectrica.energiaTotalCentral;
        if (centralElectrica != null)
        {
            ConectarACentral();
        }
    }

    public void ConectarACentral()
    {
        estaConectada = true;
        PropagarConexion();
        ActualizarEnergiaTorreta();
    }

    public void ActualizarEnergiaDesdeCentral(float nuevaEnergia)
    {
        EnergiaTotal = nuevaEnergia;
        estaConectada = true; // La bobina está activada porque está conectada a la Central
        ActualizarEnergiaTorreta();
        PropagarConexion();
    }

    public void ConectarABobina(Faros otraBobina)
    {
        if (!bobinasConectadas.Contains(otraBobina))
        {
            bobinasConectadas.Add(otraBobina);
            if (estaConectada) // Si esta Bobina ya está conectada, conecta la otra
            {
                otraBobina.ActualizarEnergiaDesdeCentral(EnergiaTotal);
            }
        }
    }

    private void PropagarConexion()
    {
        foreach (Faros bobina in bobinasConectadas)
        {
            if (!bobina.estaConectada) // Solo propaga si la Bobina aún no está conectada
            {
                bobina.estaConectada = true;
                bobina.EnergiaTotal = EnergiaTotal;
                bobina.PropagarConexion(); // Llamada recursiva para propagar el estado
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 1");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("Gun"))
        {
            GunClass torreta = other.GetComponent<GunClass>();
            if (torreta == null)
            {
                Debug.LogWarning("No encontro la clase GunClass");
                return;
            }
            if (!torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Add(torreta);
                ActualizarEnergiaTorreta();
            }
            else
            {
                Debug.Log("Ya estaba registrada");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Entro al tigger 2");
        // Verificar si el objeto tiene el tag "GunClass"
        if (other.CompareTag("Gun"))
        {
            GunClass torreta = other.GetComponent<GunClass>();
            if (torreta == null)
            {
                Debug.LogWarning("No encontro la clase GunClass");
                return;
            }
            if (torretasConectadas.Contains(torreta))
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

        //float energiaDisponible = EnergiaTotal;
        Central2.instance.ResetEenergia();
        foreach (GunClass torreta in torretasConectadas)
        {
            if (CentralElectrica.energiaTotalCentral >= torreta.energyConsumed)
            {
                //torreta.Energia = torreta.energyConsumed;
                //energiaDisponible -= torreta.energyConsumed;
                Central2.instance.GastarEnergia(torreta.energyConsumed);
                Debug.Log($"Torreta: {torreta.name}: Activada, energía restante: {CentralElectrica.energiaTotalCentral}%");
            }
            else
            {
                //torreta.Energia = 0;
                Debug.Log($"Torreta: {torreta.name}: Sin energía suficiente.");
            }
        }
    }
}