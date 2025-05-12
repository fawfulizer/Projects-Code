using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int CurrentRoom;

    [SerializeField]
    List<GameObject> Rooms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementRoom()
    {
        if(CurrentRoom > 0) { CurrentRoom--; } 
        else { CurrentRoom = 3; }
        Debugg();
        UpdateCams();
    }

    public void IncrementRoom()
    {
        if (CurrentRoom < 3) { CurrentRoom++; }
        else { CurrentRoom = 0; }
        Debugg();
        UpdateCams();
    }

    void Debugg()
    {
        Debug.Log($"{CurrentRoom}");

    }

    public void UpdateCams()
    {
        //Lazy way
        switch (CurrentRoom)
        {
            case 0:
                Rooms[0].SetActive(true);
                Rooms[1].SetActive(false);
                Rooms[2].SetActive(false);
                Rooms[3].SetActive(false);
                Rooms[4].SetActive(false);
                break;
            case 1:
                Rooms[0].SetActive(false);
                Rooms[1].SetActive(true);
                Rooms[2].SetActive(false);
                Rooms[3].SetActive(false);
                Rooms[4].SetActive(false);
                break;
            case 2:
                Rooms[0].SetActive(false);
                Rooms[1].SetActive(false);
                Rooms[2].SetActive(true);
                Rooms[3].SetActive(false);
                Rooms[4].SetActive(false);
                break;
            case 3:
                Rooms[0].SetActive(false);
                Rooms[1].SetActive(false);
                Rooms[2].SetActive(false);
                Rooms[3].SetActive(true);
                Rooms[4].SetActive(false);
                break;
            case 4:
                Rooms[0].SetActive(false);
                Rooms[1].SetActive(false);
                Rooms[2].SetActive(false);
                Rooms[3].SetActive(false);
                Rooms[4].SetActive(true);
                break;

        }

    }
}
