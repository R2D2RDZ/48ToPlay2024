using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/*public class ControladorConexiones : MonoBehaviour
{
    private Faros primeraBobina;
    public LineRenderer cablePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Faros bobinaSeleccionada = hit.collider.GetComponent<Faros>();
                CentralElectrica centralSeleccionada = hit.collider.GetComponent<CentralElectrica>();

                if (bobinaSeleccionada != null)
                {
                    if (primeraBobina == null)
                    {
                        primeraBobina = bobinaSeleccionada;
                    }
                    else
                    {
                        // Conectar las Bobinas y crear el cable
                        primeraBobina.ConectarABobina(bobinaSeleccionada);
                        CrearCable(primeraBobina, bobinaSeleccionada);
                        primeraBobina = null;
                    }
                }
                else if (centralSeleccionada != null && primeraBobina != null)
                {
                    // Conectar la Bobina a la Central Eléctrica
                    centralSeleccionada.ConectarBobina(primeraBobina);
                    CrearCable(primeraBobina, centralSeleccionada);
                    primeraBobina = null;
                }
            }
        }
    }

    void CrearCable(MonoBehaviour origen, MonoBehaviour destino)
    {
        LineRenderer cable = Instantiate(cablePrefab);
        cable.positionCount = 2;
        cable.SetPosition(0, origen.transform.position);
        cable.SetPosition(1, destino.transform.position);
    }
}*/

/*public class ControladorConexiones : MonoBehaviour
{
    private Faros primeraBobina;
    public LineRenderer cablePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Faros bobinaSeleccionada = hit.collider.GetComponent<Faros>();
                CentralElectrica centralSeleccionada = hit.collider.GetComponent<CentralElectrica>();

                if (bobinaSeleccionada != null)
                {
                    if (primeraBobina == null)
                    {
                        primeraBobina = bobinaSeleccionada;
                    }
                    else
                    {
                        // Conectar las Bobinas y crear el cable
                        primeraBobina.ConectarABobina(bobinaSeleccionada);
                        CrearCable(primeraBobina, bobinaSeleccionada);
                        primeraBobina = null;
                    }
                }
                else if (centralSeleccionada != null && primeraBobina != null)
                {
                    // Conectar la Bobina a la Central Eléctrica
                    centralSeleccionada.ConectarBobina(primeraBobina);
                    CrearCable(primeraBobina, centralSeleccionada);
                    primeraBobina = null;
                }
            }
        }
    }

    void CrearCable(MonoBehaviour origen, MonoBehaviour destino)
    {
        LineRenderer cable = Instantiate(cablePrefab);
        cable.positionCount = 2;
        cable.SetPosition(0, origen.transform.position);
        cable.SetPosition(1, destino.transform.position);
    }
}*/


public class ControladorConexiones : MonoBehaviour
{
    private Faros primeraBobina;
    public LineRenderer cablePrefab;
    public LayerMask LayerMask;
    private List<LineRenderer> cables = new List<LineRenderer>(); // Lista para almacenar los cables creados

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, -Mathf.Infinity,LayerMask);

            if (hit.collider != null)
            {
                // Comprobar si el clic fue en un cable
                LineRenderer cableSeleccionado = hit.collider.GetComponent<LineRenderer>();
                if (cableSeleccionado != null)
                {
                    DestruirCable(cableSeleccionado);
                    return;
                }

                Faros bobinaSeleccionada = hit.collider.GetComponent<Faros>();
                CentralElectrica centralSeleccionada = hit.collider.GetComponent<CentralElectrica>();

                if (bobinaSeleccionada != null)
                {
                    if (primeraBobina == null)
                    {
                        primeraBobina = bobinaSeleccionada;
                        Debug.Log(primeraBobina.name);
                    }
                    else
                    {
                        // Conectar las Bobinas y crear el cable
                        primeraBobina.ConectarABobina(bobinaSeleccionada);
                        CrearCable(primeraBobina, bobinaSeleccionada);
                        primeraBobina = null;
                        Debug.Log(bobinaSeleccionada.name);
                    }
                }
                else if (centralSeleccionada != null && primeraBobina != null)
                {
                    // Conectar la Bobina a la Central Eléctrica
                    centralSeleccionada.ConectarBobina(primeraBobina);
                    CrearCable(primeraBobina, centralSeleccionada);
                    primeraBobina = null;
                }
            }
        }
    }

    void CrearCable(MonoBehaviour origen, MonoBehaviour destino)
    {
        LineRenderer cable = Instantiate(cablePrefab);
        cable.positionCount = 2;
        float radio = Vector3.Distance(origen.transform.position, destino.transform.position) /2;
        cable.SetPosition(0, Vector3.left * radio);
        cable.SetPosition(1, Vector3.right * radio);
        cable.transform.position = (origen.transform.position + destino.transform.position) / 2;

        // Agregar un Collider2D al cable para detectar clics y colisiones
        BoxCollider2D collider = cable.gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector2(Vector3.Distance(origen.transform.position, destino.transform.position), 0.1f);
        //collider.transform.position = (origen.transform.position + destino.transform.position) / 2;
        collider.transform.rotation = Quaternion.FromToRotation(Vector3.right, destino.transform.position - origen.transform.position);

        cables.Add(cable); // Añadir el cable a la lista
    }

    void DestruirCable(LineRenderer cable)
    {
        cables.Remove(cable);
        Destroy(cable.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si un enemigo colisiona con un cable
        if (other.CompareTag("Enemigo"))
        {
            foreach (LineRenderer cable in cables)
            {
                if (cable.gameObject.GetComponent<Collider2D>() == other)
                {
                    DestruirCable(cable);
                    break;
                }
            }
        }
    }
}
