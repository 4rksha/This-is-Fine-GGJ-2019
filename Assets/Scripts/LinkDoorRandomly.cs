using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinkDoorRandomly : MonoBehaviour
{
    public GameObject[] Level1;
    public GameObject[] Level2;
    public GameObject[] Level3;


    // Start is called before the first frame update
    private void Start()
    {

        List<GameObject> Level1List = new List<GameObject>(Level1);
        List<GameObject> Level2List = new List<GameObject>(Level2);
        List<GameObject> Level3List = new List<GameObject>(Level3);

        Level1List = Shuffle(Level1List);
        Level2List = Shuffle(Level2List);
        Level3List = Shuffle(Level3List);

        LinkDoors(Level1List[Level1List.Count-1], Level2List[Level2List.Count-1]);
        Level1List.RemoveAt(Level1List.Count - 1);
        Level2List.RemoveAt(Level2List.Count - 1);

        List<GameObject> DoorsList = new List<GameObject>();
        DoorsList.AddRange(Level1List);
        DoorsList.AddRange(Level2List);
        Shuffle(DoorsList);

        LinkDoors(Level3List[Level3List.Count - 1], DoorsList[DoorsList.Count - 1]);
        Level3List.RemoveAt(Level3List.Count - 1);
        DoorsList.RemoveAt(DoorsList.Count - 1);

        DoorsList.AddRange(Level3List);

        while (DoorsList.Count > 1)
        {
            LinkDoors(DoorsList[DoorsList.Count - 1], DoorsList[DoorsList.Count - 2]);
            DoorsList.RemoveAt(DoorsList.Count - 1);
            DoorsList.RemoveAt(DoorsList.Count - 1);
        }

    }
    private void LinkDoors(GameObject door1, GameObject door2)
    {
        door1.GetComponent<TeleportTo>().LinkedDoor = door2;
        door2.GetComponent<TeleportTo>().LinkedDoor = door1;
    }
    private List<GameObject> Shuffle(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }
}
