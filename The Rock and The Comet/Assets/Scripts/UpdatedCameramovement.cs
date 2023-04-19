using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCameramovement : MonoBehaviour
{
    [SerializeField] float safeZoneX; //value of how far the player can move in the x direction before the camera moves
    [SerializeField] float safeZoneY; //value of how far the player can move in the y direction before the camera moves
    [SerializeField] float cameraCatchUpSpeed; //the spped at which the camera catches up to the player
    public GameObject player;

    //For keeping the camera within the level
    public Collider2D boundBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;
    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;


    // Use this for initialization
    void Start()
    {
        //Lets the camera know the size of the level's bound box
        minBounds = boundBox.bounds.min;
        maxBounds = boundBox.bounds.max;

        //For figuring out how wide the camera is (using orthographic size)
        theCamera = GameObject.Find("Camera").GetComponent<Camera>();
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = theCamera.transform.position - player.transform.position;
        float camDif = theCamera.transform.position.x - player.transform.position.x;
        bool changeInX = false;
        bool changeInY = false;
        bool playerMovingX =false;
        bool playerMovingY = false;
        Vector3 newCameraPosition = theCamera.transform.position;

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
                newCameraPosition.x = theCamera.transform.position.x;
            }
            if (!changeInY)
            {
                newCameraPosition.y = theCamera.transform.position.y;
            }
            
        }
        //if the playing is standing still and the difference between the cameras position and the players position is outside of 1 or -1 the camera catches up to players x position
        else if (!playerMovingX && camDif > 1)
        {
            newCameraPosition.x = theCamera.transform.position.x - (cameraCatchUpSpeed*Time.deltaTime);
            Debug.Log("camera catch up");

        }
        else if (!playerMovingX && camDif < -1)
        {
            newCameraPosition.x = theCamera.transform.position.x + (cameraCatchUpSpeed * Time.deltaTime);
        }

        newCameraPosition.z = theCamera.transform.position.z;
        theCamera.transform.position = newCameraPosition;

        //For making sure camera stays within level boundry box by checking min and max values
        float clampX = Mathf.Clamp(theCamera.transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampY = Mathf.Clamp(theCamera.transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        theCamera.transform.position = new Vector3(clampX, clampY, theCamera.transform.position.z);

    }
}
