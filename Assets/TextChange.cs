using UnityEngine;
using System.Collections;

public class TextChange : MonoBehaviour {

	public GUIText myGUIText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ShowRT(){
	myGUIText.text = "RT";
	}
	void ShowLT(){
	myGUIText.text = "LT";
	}
}
