using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour {

    [SerializeField] private float speed;
	
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
