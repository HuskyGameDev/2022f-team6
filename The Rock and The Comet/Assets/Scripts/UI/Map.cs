using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour

{
    [SerializeField] GameObject mapMenu;
    [SerializeField] GameObject playerUI;
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i<rooms.Length; i++)
        {
            if (rooms[i] != null)
            {
                rooms[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newRoom(Collider2D collision)
    {
            string roomNumber = collision.gameObject.name;
            Debug.Log("touched collider");
            switch (roomNumber)
            {
                case "Room0":
                    if (rooms[0]!=null) { rooms[0].SetActive(true); }
                    break;
                case "Room1":
                    if (rooms[1]!=null) { rooms[1].SetActive(true); }
                    break;
                case "Room2":
                    if (rooms[2] != null) { rooms[2].SetActive(true); }
                    break;
                case "Room3":
                    if (rooms[3] != null) { rooms[3].SetActive(true); }
                    break;
                case "Room4":
                    if (rooms[4] != null) { rooms[4].SetActive(true); }
                    break;
                case "Room5":
                    if (rooms[5] != null) { rooms[5].SetActive(true); }
                    break;
                case "Room6":
                    if (rooms[6] != null) { rooms[6].SetActive(true); }
                    break;
                case "Room7":
                    if (rooms[7] != null) { rooms[7].SetActive(true); }
                    break;
                case "Room8":
                    if (rooms[8] != null) { rooms[8].SetActive(true); }
                    break;
        }
    }
}
