using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    AudioSource battleTheme;

    void Awake ()
    {
          battleTheme = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {

        battleTheme.loop = true;
        battleTheme.Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
