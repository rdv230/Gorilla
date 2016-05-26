using UnityEngine;
using System.Collections;

public class Winstate : MonoBehaviour {

	public GUIText myGUI;
	public playerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.breathing >= 50 && player.heartBeat >= 50 && player.punching >= 50){
		myGUI.text = "YOU WIN!";
	}
	}
}
