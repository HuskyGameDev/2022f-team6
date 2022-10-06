using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    [SerializeField] float safeZoneX; //value of how far the player can move in the x direction before the camera moves
    [SerializeField] float safeZoneY; //value of how far the player can move in the y direction before the camera moves
    [SerializeField] float cameraCatchUpSpeed; //the spped at which the camera catches up to the player
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - player.transform.position;
        float camDif = transform.position.x - player.transform.position.x;
        bool changeInX = false;
        bool changeInY = false;
        bool playerMovingX =false;
        bool playerMovingY = false;
        Vector3 newCameraPosition = transform.position;

        //checks to see if the player is moving
       if(player.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            playerMovingX = false;
        }
       else if(player.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            playerMovingX=true;
        }
       if(player.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            playerMovingY=true;
        }
       else if(player.GetComponent <Rigidbody2D>().velocity.y == 0)
        {
            playerMovingY = false;
        }
       //if the player is moving in the x or y direction
        if (playerMovingX || playerMovingY)
        {
            //makes the camera move when the player hits the safezone distance
            if (offset.x > safeZoneX)
            {
                changeInX = true;
                newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x - safeZoneX);
            }
            else if (offset.x < -safeZoneX)
            {
                changeInX = true;
                newCameraPosition.x = (player.transform.position.x + offset.x) - (offset.x + safeZoneX);
            }
            if (offset.y > safeZoneY)
            {
                changeInY = true;
                newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y - safeZoneY);
            }
            else if (offset.y < -safeZoneY)
            {
                changeInY = true;
                newCameraPosition.y = (player.transform.position.y + offset.y) - (offset.y + safeZoneY);
            }
            if (!changeInX)
            {
                newCameraPosition.x = transform.position.x;
            }
            if (!changeInY)
            {
                newCameraPosition.y = transform.position.y;
            }
            
        }
        //if the playing is standing still and the difference between the cameras position and the players position is outside of 1 or -1 the camera catches up to players x position
        else if (!playerMovingX && camDif > 1)
        {
            newCameraPosition.x = transform.position.x - (cameraCatchUpSpeed*Time.deltaTime);
            Debug.Log("camera catch up");

        }
        else if (!playerMovingX && camDif < -1)
        {
            newCameraPosition.x = transform.position.x + (cameraCatchUpSpeed * Time.deltaTime);
        }

       
        
        transform.position = newCameraPosition;

    }
}
