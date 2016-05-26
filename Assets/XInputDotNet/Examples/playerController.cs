using UnityEngine;
using XInputDotNetPure; // Required in C#

public class playerController : MonoBehaviour
{
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    
    
	public const float minValue = 0.3f; 
	//Trigger variables
	float heartBeatTime = 0f;
	const float timeToBeat = 1;
	private float pressTime = -1f;
	private float beatGap = 2f;
	private float rTriggerValue;
	private float lTriggerValue;
	public int heartBeat;
	private bool triggerCompare;
	
	// Bumper Variables
	float breathingTime = 0f;
	const float timeToBreathe = 1;
	public int breathing;
	private bool bumperCompare;
	private float breatheTime = -1f;
	
	//button Variables
	float thinkingTime = 0f;
	const float timeToThink = 1;
	public int thinking;
	private bool buttonCompare;
	private float thinkTime = -1f;
	
	//Right Stick Variables
	float punchingTime = 0f;
	const float timeToPunch = 1;
	public int punching;
	private bool stickCompare;
	private float punchTime = -1f;
	
	//multipliers
	private float heartBeatMultipler = 1f;
	private float breathingMultipler = 1f;
	private float brainFunctionMultipler = 1f;
	
	public GameObject rightShoulder;
	public GameObject leftShoulder;
	public GameObject torso;
	public GameObject head;
	public SpriteRenderer faceSprite;
	
	public Sprite face1,face2,face3;
	public GameObject rShoulderGUI, lShoulderGUI, torsoGUI,headGUI;
	
	// Use this for initialization
    void Start()
    {
		triggerCompare = false;
		heartBeat = 0;
		
		bumperCompare = false;
		breathing = 0;
		
		buttonCompare = false;
		thinking = 0;	
		
		stickCompare = false;
		punchTime = -1f;
		
    		}
	
	// Update is called once per frame
    void Update()
    {
    	
    
    	if(Input.anyKeyDown){
    		Invoke ("ChangeSprite", 0.1f);
    	}
 
    
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {					
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }

        prevState = state;
        state = GamePad.GetState(playerIndex);

		// Set vibration according to triggers
        GamePad.SetVibration(playerIndex, state.Triggers.Left, state.Triggers.Right);
        
        //Debug.Log(state.Triggers.Right);
        HeartBeat();
        HeartPump();
        breatheIn();
        breatheOut();
        brainThought();
        brainAction();	
        FocusEnergy();
        ReleaseEnergy();
		LossHeart();
		LossBreathing();
		LossBrain();
		LossPunch();
		rTriggerValue = state.Triggers.Right;
		lTriggerValue = state.Triggers.Left;
		
		//THIS GAME ISN'T AS HARD AS IT WAS BEFORE
//			if (heartBeat <= 0){
//				breathing = 0;
//			}
//			if(breathing <= 0){
//				thinking = 0;
//			}	
//			if(thinking <=0){
//				punching = 0;
//			}
//			if(punching >= 1){
//				beatGap = 1f;
//				heartBeatMultipler = 1.75f;	
//				breathingMultipler = 1.5f;
//				brainFunctionMultipler = 1.25f;	
//			}
//			if (punching == 0 && thinking >= 1){
//				beatGap = 1.5f;
//				heartBeatMultipler = 1.5f;
//				breathingMultipler = 1.25f;
//			}
//			if (thinking == 0 && breathing >= 1){
//				//beatGap = 1.75f;
//				heartBeatMultipler = 1.25f;
//			}
		//MoveRShoulder();
    }
    
    
    void HeartBeat(){
    	if (rTriggerValue >= minValue){
			if(triggerCompare == false){
				pressTime = Time.deltaTime; 		
				triggerCompare = true;
				leftShoulder.SendMessage("MoveShoulder");
				lShoulderGUI.SendMessage("ShowLT");
				rShoulderGUI.SendMessage("ShowLT");
    		}
   		}
   	}
   	void HeartPump(){
		if (lTriggerValue >= minValue && triggerCompare && pressTime <= beatGap){
			if (rTriggerValue == 0){
				rightShoulder.SendMessage("MoveShoulder");
				lShoulderGUI.SendMessage("ShowRT");
				rShoulderGUI.SendMessage("ShowRT");
				pressTime = -1f;
				triggerCompare = false;
				heartBeat = heartBeat + 1;	
				
			}	
		}
//		if (triggerCompare && !(pressTime >= beatGap)){
//			pressTime = -1f;
//			triggerCompare = false;
// 		}  	
   	}
   	void breatheIn(){
   		if(heartBeat >= 1){
			if (prevState.Buttons.LeftShoulder == ButtonState.Pressed && state.Buttons.LeftShoulder == ButtonState.Released){
				if(bumperCompare == false){
					torso.SendMessage("UpTorso");
					breatheTime = Time.deltaTime;
					bumperCompare = true;
					torsoGUI.SendMessage("ShowRB");
		}
			}
		}
   	}
   	void breatheOut(){
   	//	if (heartBeat >= 50){
			if (prevState.Buttons.RightShoulder == ButtonState.Pressed && state.Buttons.RightShoulder == ButtonState.Released && bumperCompare && breatheTime <= beatGap){
				Debug.Log("is THIS HAPPENING?");
				torso.SendMessage("DownTorso");
				torsoGUI.SendMessage("ShowLB");
	   			breatheTime = -1f;
				bumperCompare = false;
	   			breathing = breathing + 1;
	  // 		}
	   	} 	
//	   	if (bumperCompare && !(breatheTime + beatGap >= beatGap)){
//	   			breatheTime = -1f;   			
//				bumperCompare = false;
//		}
	}
	void brainThought(){
	//	if (breathing >= 50){
			if (prevState.Buttons.Y == ButtonState.Pressed && state.Buttons.Y == ButtonState.Released){
				if(buttonCompare == false){
					thinkTime = Time.deltaTime;
					buttonCompare = true;
	//			}
			}
		}
	}		
	void brainAction(){
	//	if (breathing >= 50){
			if (prevState.Buttons.B == ButtonState.Pressed && state.Buttons.B == ButtonState.Released && buttonCompare && thinkTime <= beatGap){
				 thinkTime = -1f;
				buttonCompare = false;
				thinking= thinking + 1;
	//		}
		} 	
//		if ( buttonCompare &&!(thinkTime + beatGap >= beatGap)){
//			thinkTime = -1f;   			
//			buttonCompare = false;
//		}
	}
	void FocusEnergy(){
	//	if (thinking >= 50){
			if (prevState.Buttons.RightStick == ButtonState.Pressed && state.Buttons.RightStick == ButtonState.Released){
				if(stickCompare == false){
					punchTime = Time.deltaTime;
					stickCompare = true;
					headGUI.SendMessage("L3");
					
	//			}
			}
		}
	}
	void ReleaseEnergy(){
	//	if (thinking >= 50){
			if (prevState.Buttons.LeftStick == ButtonState.Pressed && state.Buttons.LeftStick == ButtonState.Released && stickCompare && punchTime <= beatGap){
				punchTime = -1f;
				stickCompare = false;
				punching= punching + 1;
				headGUI.SendMessage("R3");
	//		}
		} 	
//		if (stickCompare &&!(thinkTime + beatGap >= beatGap)){
//			thinkTime = -1f;   			
//			buttonCompare = false;
//		}
	}
	void LossHeart() {
		if(heartBeatTime >= timeToBeat){
			if(heartBeat >= 1){
				heartBeat -= 1;
			}
			heartBeatTime = 0f;
		}else{
			heartBeatTime += Time.deltaTime * heartBeatMultipler;
		}
	}
	void LossBreathing() {
		if(breathingTime >= timeToBreathe){
			if(breathing >= 1){
				breathing -= 1;
			}
			breathingTime = 0f;
		}else{
			breathingTime += Time.deltaTime * breathingMultipler;
		}
	}
	void LossBrain() {
		if(thinkingTime >= timeToThink){
			if(thinking >= 1){
				thinking -= 1;
			}
			thinkingTime = 0f;
		}else{
			thinkingTime += Time.deltaTime * brainFunctionMultipler;
		}
	}
	void LossPunch() {
		if(punchingTime >= timeToPunch){
			if(punching >= 1){
				punching -= 1;
			}
			punchingTime = 0f;
		}else{
			punchingTime += Time.deltaTime;
		}
	}
	
	void ChangeSprite(){
	faceSprite.sprite = face2;
	Invoke("RevertSprite", .5f);
		}
		
	void RevertSprite(){
		faceSprite.sprite = face1;
	}
}