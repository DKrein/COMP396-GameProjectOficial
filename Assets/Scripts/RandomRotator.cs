using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start() {
		GetComponent<Rigidbody>().angularVelocity = new Vector2(0f,90f) * tumble;
	
	}
}
