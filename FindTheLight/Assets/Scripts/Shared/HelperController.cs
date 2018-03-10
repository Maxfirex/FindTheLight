using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelperController : MonoBehaviour {

    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f) Die();
    }

    void Die()
    {
        Debug.Log(transform.name + " has been slain!");
        if (transform.name != "Player") Destroy(gameObject);
        else SceneManager.LoadScene("FindTheLight");
    }
}
