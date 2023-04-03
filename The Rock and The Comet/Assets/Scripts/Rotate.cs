using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float degreesPerSecond;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //rotates the backside of the powerup
        angle += Time.fixedDeltaTime * degreesPerSecond;
        angle %= 360;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
