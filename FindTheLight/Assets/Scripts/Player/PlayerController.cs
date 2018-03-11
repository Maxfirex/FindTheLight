using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float jump = 10f;

    bool canJump = true;

    void Start () {
        //hides cursor when playing
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2f;
        }
    }

    void FixedUpdate () {
        //value for moving forwards and backwards
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //value for moving left and right
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //displays cursor on escape
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            FindObjectOfType<AudioManager>().Play("jump", false);
            GetComponent<Rigidbody>().AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = true;
        if (collision.gameObject.tag == "Wall") MakePlayerFall();
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = false;
    }

    void MakePlayerFall()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * 10f, ForceMode.Impulse);
    }
}
