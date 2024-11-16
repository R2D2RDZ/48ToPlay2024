using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunClass : MonoBehaviour
{
	//
	float time = 0;
	int tick = 0;
	//[SerializeField] 
	public float damage = 1;
	public int cooldown = 1;
	public float speed = 5;
	
	
	//[SerializeField]
	public float cost = 1;
	public float energyConsumed = 1;
	public bool isOn = true;
	//[SerializeField]
	public GameObject projectile;
	List<GameObject> listEnemy;  
	//
	
	void Attack()
	{
		if (listEnemy.Count > 0) {
			Debug.Log("Hay hay  Enemigos");
			Vector3 enemyPosition = listEnemy.First().transform.position;
			Vector3 myPosition = transform.position;
			Vector3 trayectoria = new Vector3 (enemyPosition.x - myPosition.x, enemyPosition.y - myPosition.y, enemyPosition.z).normalized;
			//programar una forma para evitar no atacar a enemigos fuera del rango
			GameObject newProjectile = Instantiate(projectile, myPosition, transform.rotation);
			newProjectile.GetComponent<ProjectileClass>().damage = damage;
			newProjectile.GetComponent<Rigidbody2D>().AddForce(trayectoria*speed);
			Destroy(newProjectile, 3f);
		}
		else {
			//Debug.Log("No hay enemigos");	
		}
	}
	void isTick()
	{
		tick++;
	}
	private void Start() {
		listEnemy = new List<GameObject>();
	}
	private void FixedUpdate() {
		isTick();
		if (isOn && (tick % cooldown) == 0) {
			Attack();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Enemy"){
			Debug.Log("Encontre un Enemigo");
			listEnemy.Add(collision.gameObject);
		}
		else{
			Debug.Log("No hay enemigos");
		}
	}
	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag =="Enemy"){
			Debug.Log("Se fue un Enemigo");
			listEnemy.Remove(collision.gameObject);
		} else {
			Debug.Log("No hay enemigos");
		}
	}
}
