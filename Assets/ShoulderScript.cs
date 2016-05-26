using UnityEngine;
using System.Collections;

public class ShoulderScript : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Transform myTransform;
	public Vector3 minScale;
	public Vector3 maxScale; 
	public playerController playerController;
	public Color GorillaColor;
	public AudioSource myAudioSource;
	
	private Color StartingColor;
	// Use this for initialization
	void Start () {
		StartingColor = spriteRenderer.color;
		GorillaColor = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		
		GorillaColor.r = 1.0f - playerController.heartBeat * .02f;
		GorillaColor.g = 1.0f - playerController.heartBeat * .02f;
		
		Debug.Log("ShoulderBlue: " + GorillaColor);
		spriteRenderer.color = GorillaColor*StartingColor;
	 
		}
	
	void MoveShoulder(){
		myTransform.localScale = Vector3.Lerp(minScale ,maxScale, .1f * Time.deltaTime);
		
		Invoke("ShoulderFall",0.2f);
	}
	void ShoulderFall(){
		myTransform.localScale = Vector3.Lerp(maxScale, minScale, .1f * Time.deltaTime);
		GetComponent<AudioSource>().Play();
	}
}

