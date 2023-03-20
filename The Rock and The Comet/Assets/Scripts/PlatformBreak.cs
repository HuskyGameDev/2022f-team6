using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{

    public float fallTime;
    public float respawnTime;
    public GameObject platformPrefab;

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
            Debug.Log("Respawn");
            Invoke("Fall", fallTime);

        }
        else if (isFalling)
        {

            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        isFalling = true;
        Invoke("Respawn", respawnTime);
        // Enable gravity and make the platform fall
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

    }

    private void Respawn()
    {
        Debug.Log("Respawn");

        isFalling = false;

        // Reset the platform position
        transform.position = respawnPosition;

        // Instantiate a new platform object at the original position
        GameObject newPlatform = Instantiate(platformPrefab, respawnPosition, Quaternion.identity);

        // Reset the isFalling variable on the new platform object
        newPlatform.GetComponent<PlatformBreak>().isFalling = false;
    }
}