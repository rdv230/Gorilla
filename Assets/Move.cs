using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Transform myTransform;
//	public Vector3 minScale;
//	public Vector3 maxScale; 
	public playerController playerController;
	public Color GorillaColor;
	public AudioSource myAudioSource;

	private Color StartingColor;

	void Start () {
		StartingColor = spriteRenderer.color;
		GorillaColor = Color.white;
	}
	

	void Update () {
		GorillaColor.r = 1.0f - playerController.punching * .02f;
		GorillaColor.g = 1.0f - playerController.punching * .02f;
		
		spriteRenderer.color = GorillaColor*StartingColor;
	}
}