using UnityEngine;
using System.Collections;

public class LoopScript : MonoBehaviour {

    private Rigidbody2D rBody;
    private float posX;

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

        if (posX > 20)
        {
            Vector3 temp = new Vector3(-19.5f, rBody.transform.position.y, rBody.transform.position.z);
            rBody.transform.position = temp;
        }
        else if (posX < -20) {
            Vector3 temp = new Vector3(19.5f, rBody.transform.position.y, rBody.transform.position.z);
            rBody.transform.position = temp;
        }
	}

}
