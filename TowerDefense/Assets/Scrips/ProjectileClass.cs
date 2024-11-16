using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour
{

    public float damage = 1f;
    public float slow = 0f;
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Enemy"){
			collision.gameObject.GetComponent<EnemyAttributes>();
		}
		
	}
}
