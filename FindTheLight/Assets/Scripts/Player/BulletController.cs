using UnityEngine;

public class BulletController : MonoBehaviour {

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        EnemyController enemy = other.transform.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.GetComponent<HelperController>().TakeDamage(damage);
        }
    }
}
