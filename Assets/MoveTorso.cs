using UnityEngine;
using System.Collections;

public class MoveTorso : MonoBehaviour {
	public SpriteRenderer spriteRenderer;
	public Transform myTransform;
	public Vector3 minScale;
	public Vector3 maxScale; 
	public playerController playerController;
	public AudioSource myAudioSource;
	public Color GorillaColor;
	private Color StartingColor;

	// Use this for initialization
	void Start () {
		StartingColor = spriteRenderer.color;
		GorillaColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		GorillaColor.r = 1.0f - playerController.breathing * .02f;
		GorillaColor.g = 1.0f - playerController.breathing * .02f;
		
		spriteRenderer.color = GorillaColor*StartingColor;
		
	}
	void UpTorso(){
		myTransform.localScale = Vector3.Lerp(minScale ,maxScale, .1f * Time.deltaTime);
		Debug.Log ("WHYYY");
	}
	void DownTorso(){
		myTransform.localScale = Vector3.Lerp(maxScale, minScale, .1f * Time.deltaTime);
		GetComponent<AudioSource>().Play();
	}
}
