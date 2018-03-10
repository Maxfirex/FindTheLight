using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float spawnTimer = 5f;
    public float spawnNumber = 5f;

    private GameObject enemy;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnEnemies", spawnTimer, spawnNumber);
	}
	
	// Update is called once per frame
	void SpawnEnemies () {
        //if (player.transform.GetComponent<PlayerHealth>().health <= 0f || SpawnNumber <= 0f)
        //{
        //    return;
        //}
        //else
        //{
            Instantiate(Resources.Load("Enemy"), new Vector3(Random.Range(-25f, 25f), 1f, Random.Range(-25f, 25f)), Quaternion.identity);
            spawnNumber--;
            //print(spawnNumber);
        //}
    }
}
