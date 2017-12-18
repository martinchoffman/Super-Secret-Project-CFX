using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour {

    [SerializeField] private Transform[] guns;
    [SerializeField] private GameObject ammo;       // Make Ammo class
    [SerializeField] private Transform shots;       // Retrieve shots transform from game controller

	void Update () {
		//if (Input.GetAxis("Fire1") > 0) {
  //          Fire();
  //      }
	}

    public void PressTrigger() {
        Fire();
    }

    private void Fire() {
        foreach (Transform gun in guns) {
            GameObject shot = Instantiate(ammo, gun);
            shot.transform.parent = shots;
        }
    }
}
