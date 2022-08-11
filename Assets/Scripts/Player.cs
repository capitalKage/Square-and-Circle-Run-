using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    DeathDetector deathDetector;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    Rigidbody rigidbody;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private float walkingSpeed = .3f;
    private float runningSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        deathDetector = FindObjectOfType<DeathDetector>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.transform.Translate(Vector3.right * walkingSpeed * Time.fixedDeltaTime);
        }
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            rigidbody.transform.Translate(Vector3.right * walkingSpeed * runningSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathDetector.gameOver = true;
            Debug.Log(deathDetector.gameOver);
        }
    }
}
