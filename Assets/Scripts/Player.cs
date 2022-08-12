using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public Slider slider;
    DeathDetector deathDetector;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    Rigidbody rigidbody;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private float walkingSpeed = .3f;
    private float runningSpeed = 5f;
    private float runningEndurance = 10;
    private float timer = 0;
    public TMP_Text timerText;
    public bool playerVic = false;

    // Start is called before the first frame update
    void Start()
    {
        deathDetector = FindObjectOfType<DeathDetector>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
        {
            rigidbody.sleepThreshold = 0;
            rigidbody.transform.Translate(Vector3.right * walkingSpeed * Time.fixedDeltaTime);

            if (runningEndurance < 10)
            {
                runningEndurance += walkingSpeed * Time.fixedDeltaTime;
            }
            else
            {
                runningEndurance = 10f;
            }
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && runningEndurance > 0)
        {
            rigidbody.transform.Translate(Vector3.right * walkingSpeed * runningSpeed * Time.fixedDeltaTime);
            runningEndurance -= 2f * Time.fixedDeltaTime;
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift) && runningEndurance < 10)
        {
            runningEndurance += walkingSpeed * Time.fixedDeltaTime;
        }

        slider.value = runningEndurance;

        timer += Time.fixedDeltaTime;
        int convertedTimer = (int)timer % 240;

        timerText.text = convertedTimer.ToString();

        if (timer >= 240 && deathDetector.gameOver == false && playerVic == false)
        {
            deathDetector.gameOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            deathDetector.gameOver = true;
            SceneManager.LoadScene(2);
        }
    }
}
