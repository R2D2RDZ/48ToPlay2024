using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int life = 10;
    public float speed = 10;
    public int maxSpeed = 10;
    public int damage = 10;
    public bool isVisible = false;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            Dañarse(9);
        }
        float horizontal = speed; // A/D or Left/Right
        float vertical = 0;     // W/S or Up/Down

        // Move the object using transform in 2D space (X and Y)
        Vector2 movement = new Vector2(horizontal, vertical);
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    void Dañarse(int daño){
        life -= daño;
        if(life<0){
            Die();
        }
    }

    void Die(){
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

}
