using UnityEngine;

public class GunController : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    GameObject cam;

    void Start ()
    {
        cam = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
