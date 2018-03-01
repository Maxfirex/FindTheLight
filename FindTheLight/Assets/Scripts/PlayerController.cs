using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;

    void Start () {
        //hides cursor when playing
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        //value for moving forwards and backwards
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //value for moving left and right
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetKeyDown("escape"))
        {
            //displays cursor on escape
            Cursor.lockState = CursorLockMode.None;
        }

	}
}
