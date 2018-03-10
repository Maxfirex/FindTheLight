using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 5f;
    public float damage = 5f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HelperController>().TakeDamage(damage);
        }
    }
}
