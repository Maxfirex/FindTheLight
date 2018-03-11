using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour {

    //public float range = 100f;
    public float fireRate = 5f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float bulletSpeed = 30f;
    public float lifeTime = 5f;

    private float lastShot = 0f;

    private GameObject muzzleFlash;

    void Start ()
    {
        FindObjectOfType<AudioManager>().Play("background", true);

        muzzleFlash = transform.GetChild(1).gameObject;
        Physics.IgnoreCollision(muzzleFlash.GetComponent<Collider>(), transform.GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButton(0))
        {
            if (Time.time > 1/fireRate + lastShot)
            {
                EnableComponents();
                Shoot();

                Invoke("DisableComponents", 1 / fireRate);

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
        Physics.IgnoreCollision(bullet.GetComponent<Collider>(), transform.parent.parent.GetComponent<Collider>());
        // Setting bullet spawn position
        bullet.transform.position = bulletSpawn.position;
        // Bullet facing forward from the gun
        bullet.transform.rotation = Quaternion.Euler(transform.eulerAngles);
        // Moving a bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
        // Destroying bullet
        Destroy(bullet, lifeTime);
    }
    void EnableComponents()
    {
        muzzleFlash.GetComponent<MeshRenderer>().enabled = true;
    }

    void DisableComponents()
    {
        muzzleFlash.GetComponent<MeshRenderer>().enabled = false;
    }
}
