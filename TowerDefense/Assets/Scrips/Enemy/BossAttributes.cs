using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttributes : MonoBehaviour
{

    public EnemyAttributes atributos;
    public GameObject hijo;
    public const float birthTime = 2f;

    public bool birth = false;
    // Start is called before the first frame update
    void Start()
    {
        atributos = gameObject.GetComponent<EnemyAttributes>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!birth && atributos.currentNavPoint > 1){
            StartCoroutine(Birth());
        }
    }

    IEnumerator Birth()
    {
        birth=true;
        while(true){
            Debug.Log("HA NACIDO");
            Instantiate(hijo, atributos.points.NavPoints[atributos.currentNavPoint-1], transform.rotation);
            hijo.GetComponent<EnemyAttributes>().currentNavPoint = atributos.currentNavPoint+1;
            yield return new WaitForSeconds(birthTime);
        }
    }
}
