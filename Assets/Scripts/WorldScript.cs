using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour
{
    public RoomScript FirstRoom;
    public Material DefaultPortalsMaterial;
    public float TeleportTriggerTime;

    private RoomScript currentRoom;
    private PortalScript watchedPortal;
    private float watchedTime;
    
    void Start ()
    {
        watchedTime = 0f;

        //Deactivate all room except the first one
        foreach (Transform child in transform)
	        child.gameObject.SetActive(false);

        currentRoom = FirstRoom;
        FirstRoom.gameObject.SetActive(true);
        RenderSettings.skybox = FirstRoom.Skybox;
    }
	
	void Update () {
	    if (watchedPortal != null)
	    {
	        watchedTime += Time.deltaTime;
            if (watchedTime >= TeleportTriggerTime)
            {
                RenderSettings.skybox = watchedPortal.TeleportTo.Skybox;

                currentRoom.gameObject.SetActive(false);
                currentRoom = watchedPortal.TeleportTo;
                currentRoom.gameObject.SetActive(true);
                
                watchedPortal = null;
                watchedTime = 0f;
            }
	    }
	}
    

    public void SetWatchedPortal(PortalScript portal)
    {
        watchedPortal = portal;
    }

    public void SetUnWatchedPortal(PortalScript portal)
    {
        if (watchedPortal == portal)
        {
            watchedTime = 0f;
            watchedPortal = null;
        }
    }
}
