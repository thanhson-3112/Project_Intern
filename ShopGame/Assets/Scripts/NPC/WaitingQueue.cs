using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitingQueue : MonoBehaviour
{
    //private List<NPCPathFollow> guestList;
    //private List<Vector3> positionList;
    //private Vector3 entrancePosition;

    //public WaitingQueue(List<Vector3> positionList)
    //{
    //    this.positionList = positionList;
    //    entrancePosition = positionList[positionList.Count - 1] + new Vector3(-.8f, 0); //
    //    World_Sprite.Create(entrancePosition, new Vector3(1, 1), Color.magenta);

    //    foreach(Vector3 position in positionList)
    //    {
    //        World_Sprite.Create(position, new Vector3(.3f, .3f), Color.green);
    //    }

    //    guestList = new List<NPCPathFollow>();
    //}

    //public bool CanAddGuest()
    //{
    //    return guestList.Count < positionList.Count;
    //}

    //public void AddGuest(NPCPathFollow guest)
    //{
    //    guestList.Add(guest);
    //    guest.SetGuestDestination(entrancePosition, () =>
    //    {

    //    });
    //}

    private List<NPCPathFollow> guestList;
    private List<Vector3> positionList;
    private Vector3 entrancePosition;

    public WaitingQueue(List<Vector3> positionList)
    {
        this.positionList = positionList;
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(-8f, 0);

        guestList = new List<NPCPathFollow>();
    }

    public bool CanAddGuest()
    {
        return guestList.Count < positionList.Count;
    }

    public void AddGuest(NPCPathFollow guest)
    {
        guestList.Add(guest);
        guest.MoveTo(positionList[guestList.IndexOf(guest)]);
    }

    public NPCPathFollow GetFirstInQueue()
    {
        if (guestList.Count == 0)
        {
            return null;
        }
        else
        {
            NPCPathFollow guest = guestList[0];
            guestList.RemoveAt(0);
            RelocateAllGuests();
            return guest;
        }
    }

    private void RelocateAllGuests()
    {
        for (int i = 0; i < guestList.Count; i++)
        {
            guestList[i].MoveTo(positionList[i]);
        }
    }
}

