using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    public float fallTime = 2;
    public float respawnTime;
    public GameObject platformPrefab;
    public GameObject dragon;

    private bool isFalling = false;
    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // Start falling after a delay
            Debug.Log("fall");
            Invoke("Fall", fallTime);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        isFalling = true;

        // Enable gravity and make the platform fall
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }

}