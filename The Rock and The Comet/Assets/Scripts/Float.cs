using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    public float movementTime;
    public float amplitude;

    private Vector3 offset;
    private Vector3 temp;

    private void FixedUpdate()
    {
        //floats powerup up and down using a sin wave
        float normalTime = Time.fixedTime / movementTime;
        float sinTime = normalTime * Mathf.PI * 2;
        float sinVal = Mathf.Sin(sinTime);
        temp = offset;
        temp.y += sinVal / amplitude;

        transform.position = temp;
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
