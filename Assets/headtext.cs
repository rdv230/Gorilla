using UnityEngine;
using System.Collections;

public class headtext : MonoBehaviour {

	public GUIText myGUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void R3(){
	Debug.Log ("IS HAPPENING!");
	myGUI.text = "R3";
	}
	void L3(){
	myGUI.text = "L3";
	}
}
