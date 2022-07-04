using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rotSpeed = 100f; //виносим поле в інспектор
    [SerializeField] float flySpeed = 100f;
    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Launch();
        Rotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            case "Battery":
                print("energy");
                break;
            default:
                print("boom!");
                break;
        }
    }

    void Launch()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * flySpeed);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Pause();
        }
    }
    void Rotation()
    {
        float rotationSpeed = rotSpeed * Time.deltaTime; //корекція різниці частоти кадрів

        rigidBody.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }
}
