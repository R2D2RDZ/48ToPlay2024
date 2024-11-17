using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : GunClass
{
	private void OnTriggerEnter2D(Collider2D collision) {
        var hacker = collision.GetComponent<HackerAttributes>();
		if(hacker != null){
			Debug.Log("Encontre un Hecker");
            Debug.Log(collision.gameObject.transform.parent.gameObject.name);
			listEnemy.Add(collision.gameObject.transform.parent.gameObject);
		}
		else{
			Debug.Log("No hay Heckers");
		}
	}
	private void OnTriggerExit2D(Collider2D collision) {
        var hacker = collision.GetComponent<HackerAttributes>();
		if(hacker != null){
			Debug.Log("Se fue un Hecker");
			listEnemy.Remove(collision.gameObject.transform.parent.gameObject);
		} else {
			Debug.Log("No hay Heckers");
		}
	}

    public override void Attack() {
		if (listEnemy.Count > 0) {
			Debug.Log("Hay hay  Enemigos");

			GameObject enemyTarget = null;
			int count = listEnemy.Count;
			for (int i = 0; i < count; i++) {
				if (!listEnemy[i].GetComponent<EnemyAttributes>().isVisible) {
					enemyTarget = listEnemy[i];
					break;
				}
			}
			if (enemyTarget == null) {
				//Debug.Log("No hay Enemigos");
				return;
			}
			Vector3 enemyPosition = enemyTarget.transform.position;
			Vector3 myPosition = transform.position;
			Vector3 trayectoria = new Vector3(enemyPosition.x - myPosition.x, enemyPosition.y - myPosition.y, enemyPosition.z).normalized;
			Vector3 direccion = myPosition - enemyPosition;
			float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90;
			Quaternion myRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = myRotation;
			//programar una forma para evitar no atacar a enemigos fuera del rango
			GameObject newProjectile = Instantiate(projectile, myPosition, myRotation);
			newProjectile.GetComponent<ProjectileClass>().damage = damage;
			newProjectile.GetComponent<Rigidbody2D>().AddForce(trayectoria * speed);
			flash.SetActive(true);
			Destroy(newProjectile, time);
		}
    }
}
