using UnityEngine;

public class GunController : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;

    GameObject cam;

    private float lastShot = 0f;

    void Start ()
    {
        cam = this.transform.parent.gameObject;
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
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            EnemyController enemy = hit.transform.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log(enemy.health);
            }
        }
    }
}
