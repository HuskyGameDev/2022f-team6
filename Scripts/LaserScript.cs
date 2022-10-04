using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
	public GameObject laser;
	bool reached = false;

	void onTriggerEnter(Collider other) {
		Debug.Log("test1 success");
		reached = true;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        laser = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		if (!reached) {
        	laser.transform.localScale = new Vector3(laser.transform.localScale.x + 0.1f, 0.1f, 0f);
			laser.transform.localPosition = new Vector3(laser.transform.localPosition.x + 0.0875f, laser.transform.localPosition.y, laser.transform.localPosition.z);
		}
    }
}
