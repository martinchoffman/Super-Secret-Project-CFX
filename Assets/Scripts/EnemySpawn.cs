using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    [SerializeField] private GameObject[] enemies;      // Create Enemy class
    [SerializeField] private float spawnHeight;         // Distance from the center of the planet to spawn enemies
    [SerializeField] private float delay;
    [SerializeField] private float delayVariability;    // Float in seconds that delay can differ +-

    private bool spawning = false;

	void Update () {
		if (!spawning) {
            float offsetDelay = Random.Range(delay - delayVariability, delay + delayVariability);
            StartCoroutine(SpawnEnemy(offsetDelay));
        }
	}

    private IEnumerator SpawnEnemy(float delay) {
        spawning = true;
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 spawnPoint = new Vector3(Mathf.Cos(angle) * spawnHeight + transform.position.x, Mathf.Sin(angle) * spawnHeight + transform.position.y, transform.position.z);

        print("Angle: " + angle);
        print("Cos: " + Mathf.Cos(angle));
        print("Sin: " + Mathf.Sin(angle));

        yield return new WaitForSeconds(delay);

        GameObject enemy = Instantiate(enemies[0]);        // Create a system for randomly spawning enemies based on their difficulty coefficient and the current difficulty multiplier
        enemy.transform.position = spawnPoint;
        enemy.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        spawning = false;
    }
}
