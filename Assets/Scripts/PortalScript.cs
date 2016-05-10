using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Runtime.InteropServices;

public class PortalScript : MonoBehaviour {

    public RoomScript TeleportTo;

    private WorldScript worldScript;
    private WorldScript WorldScript
    {
        get
        {
            if (worldScript == null)
                worldScript = GetComponentInParent<WorldScript>();
            return worldScript;
        }
    }


	void Start ()
	{
	    var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.SetTexture("_MainTex", TeleportTo.Texture);

        gameObject.AddComponent(typeof(EventTrigger));
		EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
		
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(baseEventData => { WorldScript.SetWatchedPortal(this); });
		trigger.triggers.Add(entry);

		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback.AddListener(baseEventData => { WorldScript.SetUnWatchedPortal(this); });
		trigger.triggers.Add(entry);
	}

	void Update(){

	}
}
