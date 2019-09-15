using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GazeButton : MonoBehaviour {

    public Image ButtonImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WhiteColor()
    {
        ButtonImage.color = Color.white;
    }

    public void RedColor()
    {
        ButtonImage.color = Color.red;
    }
}
