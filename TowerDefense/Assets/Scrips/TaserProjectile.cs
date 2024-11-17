using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserProjectile : ProjectileClass
{
    // Start is called before the first frame update
    public float slowduration = 0f;
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Enemy"){
			collision.gameObject.GetComponent<EnemyAttributes>().Dañarse(damage);
            collision.gameObject.GetComponent<EnemyAttributes>().Status(slow, slowduration);
			Destroy(this.gameObject);
			Debug.Log("Le diste");
		}
	}
}
