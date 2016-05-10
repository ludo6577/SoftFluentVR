/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardboardScript : MonoBehaviour {
	//Image object for the reticule
	public Image Reticule;

	//Scale velocity and time
	public float ReticuleScaleVelocity;
	public float ReticuleScaleTime;
	
	//Base size of the reticule
	private Vector3 reticuleOriginalScale;
	private float reticuleCurrentScaleTime;

	//Currently watched portal
	[HideInInspector]
	public PortalScript WatchedPortal;

	private static CardboardScript instance;
	public static CardboardScript Get(){
		if (!instance)
			instance = new CardboardScript ();
		return instance;
	}

	void Awake()
	{
		instance = this;
		WatchedPortal = null;
		reticuleOriginalScale = Reticule.transform.localScale;
		reticuleCurrentScaleTime = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (WatchedPortal != null) {
			ScaleReticule (ReticuleScaleVelocity);

			reticuleCurrentScaleTime += Time.deltaTime;
			if (reticuleCurrentScaleTime > ReticuleScaleTime) {
				WatchedPortal.EnterRoom ();
				WatchedPortal = null;
				Reticule.transform.localScale = reticuleOriginalScale;
			}
		} else if (Reticule.transform.localScale.x > reticuleOriginalScale.x) {
			ScaleReticule (-ReticuleScaleVelocity);
			reticuleCurrentScaleTime -= Time.deltaTime;
		}
	}

	private void ScaleReticule(float velocity){
		var previousScale = Reticule.transform.localScale;
		Reticule.transform.localScale = new Vector3(previousScale.x + velocity * Time.deltaTime, 
		                                            previousScale.y + velocity * Time.deltaTime, 
		                                            previousScale.z + velocity * Time.deltaTime);
	}
}
*/