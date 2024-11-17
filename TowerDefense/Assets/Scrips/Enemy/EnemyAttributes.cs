using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int value;
    public float life = 10;
    public float speed = 10;
    public float reachDistance = 0.2f;
    public int maxSpeed = 10;
    public float damage = 10;
    public bool isVisible = false;

    public int currentNavPoint = 1;
    private Rigidbody2D rb2d;
    public LevelCreator points;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        points = Camera.main.GetComponent<LevelCreator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      /*  if (!(points.NavPoints.Length == 0) || !(currentNavPoint >= points.NavPoints.Length))
        {
            MoveToNextNavPoint();
        }*/
    }

    public void Dañarse(float daño){
        life -= daño;
        if(life<0f){
            Die();
        }
    }

    void Die(){
        Player.Instance.AddElectrum(value);
        Destroy(this.gameObject);
    }

    public void Status(float porcentaje, float tiempo){
        speed = speed*porcentaje;
        StartCoroutine(slow(tiempo));
    }

    IEnumerator slow(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        speed = maxSpeed;
    }

    void MoveToNextNavPoint()
    {
        Vector2 targetPosition = points.NavPoints[currentNavPoint];
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, targetPosition) < reachDistance)
        {
            currentNavPoint = (currentNavPoint + 1);
        }
    }

}
