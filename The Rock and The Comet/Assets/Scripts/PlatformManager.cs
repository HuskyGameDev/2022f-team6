using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject platformPrefab;

    public float wait;

    public Vector3 respawn;
    public GameObject platform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Spawn the initial platform
        platform = Instantiate(platformPrefab, respawn, Quaternion.identity);
    }

    public IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(wait);

        // Destroy the previous platform
        Destroy(platform);

        // Spawn a new platform at the respawn position
        platform = Instantiate(platformPrefab, respawn, Quaternion.identity);
    }
}