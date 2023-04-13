using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour

{
    [SerializeField] GameObject mapMenu;
    [SerializeField] GameObject playerUI;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject room5;
    public GameObject room6;
    public GameObject room7;

    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        room2.SetActive(false);
        room3.SetActive(false);
        room4.SetActive(false);
        room5.SetActive(false);
        room6.SetActive(false);
        room7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isActive = !isActive;

            playerUI.SetActive(!isActive);
            mapMenu.SetActive(isActive);

            if (isActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void newRoom(Collider2D collision)
    {
            string roomNumber = collision.gameObject.name;
            Debug.Log("touched collider");
            switch (roomNumber)
            {
                case "Room2":
                    room2.SetActive(true);
                    break;
                case "Room3":
                    room3.SetActive(true);
                    break;
                case "Room4":
                    room4.SetActive(true);
                    break;
                case "Room5":
                    room5.SetActive(true);
                    break;
                case "Room6":
                    room6.SetActive(true);
                    break;
                case "Room7":
                    room7.SetActive(true);
                    break;
            }
    }
}
