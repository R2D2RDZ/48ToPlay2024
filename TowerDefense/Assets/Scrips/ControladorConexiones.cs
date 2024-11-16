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
                        CrearCable(primeraBobina, bobinaSeleccionada);
                        primeraBobina = null;
                    }
                }
                else if (centralSeleccionada != null && primeraBobina != null)
                {
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

using System.Collections.Generic;
using UnityEngine;

public class ControladorConexiones : MonoBehaviour
{
    private Faros primeraBobina;
    public LineRenderer cablePrefab;
    private List<LineRenderer> cablesReutilizables = new List<LineRenderer>();
    private int cableIndex = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

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
                        CrearCable(primeraBobina, bobinaSeleccionada);
                        primeraBobina = null;
                    }
                }
                else if (centralSeleccionada != null && primeraBobina != null)
                {
                    centralSeleccionada.ConectarBobina(primeraBobina);
                    CrearCable(primeraBobina, centralSeleccionada);
                    primeraBobina = null;
                }
            }
        }
    }

    void CrearCable(MonoBehaviour origen, MonoBehaviour destino)
    {
        LineRenderer cable;
        if (cableIndex < cablesReutilizables.Count)
        {
            cable = cablesReutilizables[cableIndex];
            cable.gameObject.SetActive(true);
        }
        else
        {
            cable = Instantiate(cablePrefab);
            cablesReutilizables.Add(cable);
        }

        cable.positionCount = 2;
        cable.SetPosition(0, origen.transform.position);
        cable.SetPosition(1, destino.transform.position);
        cableIndex++;
    }

    public void ReiniciarCables()
    {
        foreach (LineRenderer cable in cablesReutilizables)
        {
            cable.gameObject.SetActive(false);
        }
        cableIndex = 0;
    }
}
