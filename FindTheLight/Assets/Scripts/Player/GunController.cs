using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour {

    //public float range = 100f;
    public float fireRate = 5f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletSpeed = 30;
    public float lifeTime = 2;

    private float lastShot = 0f;

    void Start ()
    {
        FindObjectOfType<AudioManager>().Play("background", true);
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButton(0))
        {
            if (Time.time > 1/fireRate + lastShot)
            {
                Shoot();

                FindObjectOfType<AudioManager>().Play("shoot", true);

                lastShot = Time.time;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            FindObjectOfType<AudioManager>().Stop("shoot");
        }
	}

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        // Ignore spawn collision with weapon
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());
        // Setting bullet spawn position
        bullet.transform.position = bulletSpawn.position;

        Vector3 rotation = bullet.transform.rotation.eulerAngles;
        // Bullet facing forward from the gun
        bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        // Moving a bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        // Destroying bullet
        StartCoroutine(DestroyBullet(bullet, lifeTime));
    }

    private IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
