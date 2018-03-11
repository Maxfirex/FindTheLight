using UnityEngine;

public class BulletController : MonoBehaviour {

    public Transform effect;

    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;

        Transform newEffect = Instantiate(effect.transform, position, rotation);

        Destroy(newEffect.gameObject, 1);

        Destroy(gameObject);

        EnemyController enemy = collision.transform.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.GetComponent<HelperController>().TakeDamage(damage);
        }
    }
}
