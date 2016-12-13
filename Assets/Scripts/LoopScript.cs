using UnityEngine;
using System.Collections;

public class LoopScript : MonoBehaviour {

    private Rigidbody2D rBody;
    private float posX;
	private float posY;
	private float newposX = 19.035f;
	private float newposY = 11f;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {
        posX = rBody.transform.position.x;
		posY = rBody.transform.position.y;
		if (posX > newposX)
        {
			Vector3 temp = new Vector3(-newposX, rBody.transform.position.y, rBody.transform.position.z);
            rBody.transform.position = temp;
        }
		else if (posX < -newposX) {
			Vector3 temp = new Vector3(newposX, rBody.transform.position.y, rBody.transform.position.z);
            rBody.transform.position = temp;
        }
		if (posY < -newposY) {
			Vector3 temp = new Vector3 (rBody.transform.position.x, newposY, rBody.transform.position.z);
			rBody.transform.position = temp;
		}
	}

}
