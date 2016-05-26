using UnityEngine;
using System.Collections;

public class ChestTextChange : MonoBehaviour {

	public GUIText myGUIText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ShowLB(){
	myGUIText.text = "LB";
	}
	void ShowRB(){
	myGUIText.text = "RB";
	}
}
