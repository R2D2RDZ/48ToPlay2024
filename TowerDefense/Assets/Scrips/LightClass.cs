using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightClass : MonoBehaviour
{
        //
    public float Energia { get; set; }

    float time = 0;
	int tick = 0;
	//[SerializeField] 
	public float speed = 5;
	public bool isEnabled = true;
	
	//[SerializeField]
	public float cost;
	public float energyConsumed = 1;
	public bool isOn = true;
	
	private void Start() {
	}
	private void FixedUpdate() {
        if(isEnabled && isOn){
            GetComponent<CircleCollider2D>().enabled = true;
        }
        else{
            GetComponent<CircleCollider2D>().enabled = false;
        }
	}
}
