using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFaros : MonoBehaviour
{
    public List<GunClass> torretasConectadas = new List<GunClass>();
    public List<NewFaros> bobinasConectadas = new List<NewFaros>();

    [SerializeField] bool estaConectada = false;
    [SerializeField] bool isCentral;


    public bool Conectar(NewFaros faro)
    {
        Debug.Log(bobinasConectadas.Count);
        if (!bobinasConectadas.Contains(faro))
        {
            bobinasConectadas.Add(faro);
            RevisarConexion();
            Debug.Log(gameObject.name + " conectado con " + faro.name);
            return true;
        }
        return false;
    }

    public bool Desconectar(NewFaros faro)
    {
        if (bobinasConectadas.Contains(faro))
        {
            bobinasConectadas.Remove(faro);
            estaConectada = false;
            RevisarConexion() ;
            Debug.Log(gameObject.name + " desconectado con " + faro.name);
            DesconectarTodoALV();
            return true;
        }
        return false;
    }

    void RevisarConexion()
    {
        foreach (NewFaros bobina in bobinasConectadas) {
            if (bobina.estaConectada || bobina.isCentral)
            {
                estaConectada = true;
                break;
            }
            else estaConectada = false;
        }
    }
    void OnOffTorretas()
    {
        foreach (GunClass torreta in torretasConectadas)
        {
            torreta.isOn = estaConectada;
        }
    }

    private void FixedUpdate()
    {
        RevisarConexion();
        OnOffTorretas();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entro al trigger");

        if (collision.CompareTag("Gun"))
        {
            GunClass torreta = collision.GetComponent<GunClass>();
            if (!torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Add(torreta);
                ActualizarEnergiaTorreta(torreta);
            }
            else
            {
                Debug.Log("Ya estaba registrada");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Salio del trigger");

        if (collision.CompareTag("Gun"))
        {
            GunClass torreta = collision.GetComponent<GunClass>();
            if (torretasConectadas.Contains(torreta))
            {
                torretasConectadas.Remove(torreta);
                LiberarEnergia(torreta);               
            }
            else
            {
                Debug.Log("No estaba registrada");
            }

        }
    }



    void ActualizarEnergiaTorreta(GunClass torreta)
    {
        if (!torreta.isOn)
        {
            if (Central2.instance.energiaDisponible >= torreta.energyConsumed)
            {
                Central2.instance.GastarEnergia(torreta.energyConsumed);
                torreta.isOn = true;
                Debug.Log("Energia restante: " + Central2.instance.energiaDisponible);
            }
            else {
                Debug.Log("Energia faltante. Disponible" );
            }
        }
        else
        {
            Debug.Log("Ya estaba prendida");
        }
    }

    void LiberarEnergia(GunClass torreta)
    {
        Central2.instance.GastarEnergia(-torreta.energyConsumed);
    }

    void DesconectarTodoALV()
    {
        GameObject[] bobinas = GameObject.FindGameObjectsWithTag("Bobina");
        foreach (GameObject bobina in bobinas)
        {
            bobina.GetComponent<NewFaros>().estaConectada = false;
        }
    }
}
