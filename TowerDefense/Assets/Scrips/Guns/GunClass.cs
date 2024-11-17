using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunClass : MonoBehaviour {
	//
	public float Energia { get; set; }

	int tick = 0;
	//[SerializeField] 
	public float damage = 1;
	public int cooldown = 1;
	public float speed = 5;
	public bool isEnabled = true;
	public float time = 0;

	//[SerializeField]
	public float cost;
	public float energyConsumed = 1;
	public bool isOn = false;
	//[SerializeField]
	public GameObject projectile;
	public GameObject flash;
	public List<GameObject> listEnemy;
	//

	public virtual void Attack() {
		if (listEnemy.Count > 0) {
			//Debug.Log("Hay hay  Enemigos");

			GameObject enemyTarget = null;
			int count = listEnemy.Count;
			for (int i = 0; i < count; i++) {
				if (listEnemy[i].GetComponent<EnemyAttributes>().isVisible) {
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
		} else {
			//Debug.Log("No hay enemigos");	
		}
	}
	void isTick() {
		tick++;
	}
	private void Start() {
		listEnemy = new List<GameObject>();
	}
	private void FixedUpdate() {
		isTick();
		if (isEnabled && isOn && (tick % cooldown) == 0) {
			Attack();
		} else {
			flash.SetActive(false);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Enemy" /*&& collision.gameObject.GetComponent<EnemyAttributes>().isVisible*/){
			//Debug.Log("Encontre un Enemigo");
			listEnemy.Add(collision.gameObject);
		}
		else{
			//Debug.Log("No hay enemigos");
		}
	}
	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag =="Enemy"){
			//Debug.Log("Se fue un Enemigo");
			listEnemy.Remove(collision.gameObject);
		} else {
			//Debug.Log("No hay enemigos");
		}
	}
}
