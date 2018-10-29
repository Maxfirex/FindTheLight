using UnityEngine;
using UnityEngine.SceneManagement;

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

        StopPlayerMovementInAir();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //displays cursor on escape
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
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
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") canJump = false;
    }

    void StopPlayerMovementInAir()
    {
        // Get the velocity
        Vector3 horizontalMove = GetComponent<Rigidbody>().velocity;
        // Don't use the vertical velocity
        horizontalMove.y = 0;
        // Calculate the approximate distance that will be traversed
        float distance = horizontalMove.magnitude * Time.fixedDeltaTime;
        // Normalize horizontalMove since it should be used to indicate direction
        horizontalMove.Normalize();
        RaycastHit hit;

        // Check if the body's current velocity will result in a collision
        if (GetComponent<Rigidbody>().SweepTest(horizontalMove, out hit, distance))
        {
            // If so, stop the movement
            GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
        }
    }
}
