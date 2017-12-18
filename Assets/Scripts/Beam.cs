using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float time;

    void Start() {
        StartCoroutine(SelfDestruct(time));
    } 

	void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
	}

    IEnumerator SelfDestruct(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
