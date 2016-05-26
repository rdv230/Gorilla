using UnityEngine;
using System.Collections;

public class ColorizeScript : MonoBehaviour {
	public SpriteRenderer thisBody;
	public SpriteRenderer bodyPart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		thisBody.color = bodyPart.color;
	}
}