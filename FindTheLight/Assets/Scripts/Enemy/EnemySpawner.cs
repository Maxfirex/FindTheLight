using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnTimer = 5f;
    public float spawnLoop = 5f;
    public float spawnNumber = 25f;

    private float spawned = 0;

    private GameObject enemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemies", spawnTimer, spawnLoop);
	}
	
	// Update is called once per frame
	void SpawnEnemies () {

        if (spawned != spawnNumber)
        {
            Instantiate(Resources.Load("Enemy"), new Vector3(Random.Range(-25f, 25f), 1f, Random.Range(-25f, 25f)), Quaternion.identity);
            spawned++;
        }
        else
        {
            CancelInvoke("SpawnEnemies");
        }
    }
}
