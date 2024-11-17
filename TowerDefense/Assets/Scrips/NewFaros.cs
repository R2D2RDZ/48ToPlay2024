using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFaros : MonoBehaviour
{
    public List<GunClass> torretasConectadas = new List<GunClass>();
    public List<NewFaros> bobinasConectadas = new List<NewFaros>();

    [SerializeField] bool estaConectada = false;
    [SerializeField] bool estaConCentral = false;
    [SerializeField] bool isCentral;

    




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
                Debug.Log("Energia faltante");
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
}
