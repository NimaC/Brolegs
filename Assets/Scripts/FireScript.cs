using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public Rigidbody2D Fire;
	
	private BolegController bolegCtrl;
	public string fireButton = "Fire_P1";

	
	// Use this for initialization
	void Start () {
	
	}
	void Awake ()
    {
        bolegCtrl = transform.root.GetComponent<BolegController>();
    }
		

	// Update is called once per frame
	void Update () {
		if (Input.GetButton(fireButton)){
			Vector3 tempPlace = new Vector3 (BolegController.positionX, BolegController.positionY, BolegController.positionZ);
			Vector3 tempScale = new Vector3 (BolegController.scaleX, BolegController.scaleY, BolegController.scaleZ);
			Debug.Log(BolegController.scaleX);
			transform.localScale = tempScale;
		    transform.position = tempPlace;
		}
		
		else{
			transform.position = new Vector3 (100,100,100);
		}

		/* if(BolegController.facingRight){
			transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		} */
}
}
