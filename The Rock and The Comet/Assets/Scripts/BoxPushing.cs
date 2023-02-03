using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushing : MonoBehaviour

{
    /*This Goes On The Box
     * Tag the place where the box should be as BoxSpot
     * Has GetInPosition method to retrieve bool on if box is in place***/
  
    
    [SerializeField] bool inPosition;//true if box is where it should be
    [SerializeField] GameObject toggleObject;
  
    void Start()
    {
        inPosition = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxSpot"))
        {
            inPosition = true;
            toggleObject.SetActive(!toggleObject.activeSelf);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoxSpot"))
        {
            inPosition = false;
            toggleObject.SetActive(!toggleObject.activeSelf);
        }
    }
    public bool GetInPosition()
    {
        return inPosition;
    }
}
