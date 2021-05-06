using UnityEngine;
using System.Collections;

public class ObjectReplyIdAndMove : MonoBehaviour //This Script Needs ObjectGrabIdAndMove script on player to link for the called player bools.

{


//Find Player and Headcam

	public GameObject FindPlayer ;
	public string ChangeFindPlayerTag = "MainPlayer" ;

	public GameObject FindHeadcam ;
	public string ChangeFindHeadcamTag = "HeadCam" ;

//Object Type
	
	public string ObjectType = "Moveable_Object" ;
	public string ObjectClass = "Non_Equipable" ;
	public string ObjectUse = "Placeable" ;
	public float Gravity = Physics.gravity.y ;

//Main IDs

	public string ObjectID = "" ;
	public string CheckRayhitID = "" ;
	public string CheckEqualID = "" ;

//timer and xyz positioncheck bools

	private bool OkX = false ;
	private bool OkY = false ;
	private bool OkZ = false ;
	private bool TimerDone = false ;
	private bool TimerDoneTriggered = false ;

//Intial player grabed lock bool

	private bool isPlayerGrabing = false ;

//Main bools

	public bool PlayerGrabbed = false ;
	public bool CorrectID = false ;
	public bool isObjectHeld = false ;
	public bool ObjectInPlace = false ;
	public bool ObjectActivated = false ;
	public bool RotatingObject = false ;

//Inversion bools

	public bool InvertRotate = false ;
	public bool InvertRotateSideway = false ;
	public bool InvertRotateVertical = false ;

	public bool InvertMouseRotate = false ;
	public bool InvertMouseRSideway = false ;
	public bool InvertMouseRVertical = false ;

	public bool UseDefaultRotaions = false ;
	public bool OverideDiagnals = false ;
	public bool OverideRotateToFace = false ;

//AutoInvertRotate on 180 degree, Bool

	public bool AutoDefault = false ;
	public bool AutoSwapAxis = false ;
	public bool AutoDiagnals = false ;
	public bool AutoSwapDiagnals = false ;
	public bool ObjectUpsideDown = false ;
	public bool ObjectFacingFD = false ;

//Extra bools

	public bool ArrowkeysEnabled = false ;
	public bool OverideDisableGravity = false ;
	public bool OverideDisableContstraints = false ;
	public bool OverideDisableController = false ;
	public bool OverideCollidersOn = false ;

//Movement floats

	private float MoveUp = 0.0f ;
	private float MoveDw = 0.0f ;
	private float MoveUpDown = 0.0f ;

	private float MoveRG = 0.0f ;
	private float MoveLF = 0.0f ;
	private float MoveRightLeft = 0.0f ;

	private float MoveFD = 0.0f ;
	private float MoveBK = 0.0f ;
	private float MoveFdAndBk = 0.0f ;

	private float MoveRotateR = 0.0f ;
	private float MoveRotateL = 0.0f ;
	private float MoveRotateRandL = 0.0f ;

	private float MoveRotateSidewayR = 0.0f ;
	private float MoveRotateSidewayL = 0.0f ;
	private float MoveRotateSidewayRandL = 0.0f ;

	private float MoveRotateVerticalUp = 0.0f ;
	private float MoveRotateVerticalDw = 0.0f ;
	private float MoveRotateVerticalUpandDw = 0.0f ;

//temp Automove transisition offset floats

	private float Xtransition = 0.0f ;
	private float Ytransition = 0.0f ;
	private float Ztransition = 0.0f ;

//Invert Axis Floats

	private float InvertRotate1 =0.0f ;
	private float InvertRotateSideways1 = 0.0f ;
	private float InvertRotateVertical1 = 0.0f ;
	
	public float InvertMouseRotate1 = 0.0f ;
	public float InvertMouseRSideways1 = 0.0f ;
	public float InvertMouseRVertical1 = 0.0f ;

//Axis input floats

	private float Haxis = 0.0f ;
	private float Vaxis = 0.0f ;

	private float yaw = 0.0f ;
	private float yawFlash = 0.0f ;
	public float yawInc = 0.0f ;
	
	private float pitch = 0.0f ;
	private float pitchFlash = 0.0f ;
	public float pitchInc = 0.0f ;

//Timer for mouse flash for flashing yaw and pitch into Increments

	private float Timer = 0.0f ;

	public float MouseScroll = 0.0f ;
	public float EulerX = 0.0f ;
	public float EulerY = 0.0f ;
	public float EulerZ = 0.0f ;
	public float LocEulerX = 0.0f ;
	public float LocEulerY = 0.0f ;
	public float LocEulerZ = 0.0f ;
	public float RotationX = 0.0f ;
	public float RotationY = 0.0f ;
	public float RotationZ = 0.0f ;
	public float LocRotationX = 0.0f ;
	public float LocRotationY = 0.0f ;
	public float LocRotationZ = 0.0f ;

//MouseSpeed

	public float MouseSpeedH = 3.0f ;
	public float MouseSpeedV = 3.0f ;

//Sensitivty Settings

	public float MoveSensitivity = 5.0f ;
	public float RotateSensitivity = 4.0f ;
	public float MouseMoveSensitivity = 6.1111111f ;
	public float MouseRotateSensitivity = 6.1111111f ;
	public float MouseScrollSensitivity = 5.0f ;

//Automove Transitionspeed and overide bool

	public bool OverrideAutomove = false ;
	public bool UseAutoPosition = false ;
	public bool ColliderOn = false ;

//Automove offsets

	private float AutomoveTransitionSpeed = 0.00511111f ;
	private float AutomoveHeightOffsetY = 1.0f ;
	private float AutomoveSidewaysOffsetX = -0.6f ;
	private float AutomoveInFrontOffsetZ = 2.5f ;

//Mouse Flash timer's, time to wait for flashing yaw and pitch into Increments

	public float Timetowait = 0.051111f ;
	public float GimbleLockOffset = 3.89f ;
	public float TempInvertMouseRotate1 = 0.0f ;
	public float TempInvertMouseRotate2 = 0.0f ;
	public float TempInvertMouseRVertical1 = 0.0f ;
	public float TempInvertMouseRVertical2 = 0.0f ;

//Private Vectors

	private Vector3 PlayerPosition = new Vector3 ( 0.0f , 0.0f , 0.0f );
	private Vector3 ObjectCurrentPosition = new Vector3 ( 0.0f , 0.0f , 0.0f );
	private Vector3 ObjectMove = new Vector3 ( 0.0f , 0.0f , 0.0f );
	private Vector3 ObjectMove2 = new Vector3 ( 0.0f , 0.0f , 0.0f );
	private Vector3 ObjectMove3 = new Vector3 ( 0.0f , 0.0f , 0.0f );
	private Vector3 ObjectRotation = new Vector3 ( 0.0f , 0.0f , 0.0f );

	private Vector3 UpAndDown = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 RightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 ForwardAndBack = new Vector3 (0.0f , 0.0f , 0.0f ) ;

	private Vector3 RRightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 RSRightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 RVUpAndDown = new Vector3 (0.0f , 0.0f , 0.0f ) ;

	private Vector3 MouseMoveUpDw = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 MouseMoveSideways = new Vector3 (0.0f , 0.0f , 0.0f ) ;
	private Vector3 MouseScrollFB = new Vector3 (0.0f , 0.0f , 0.0f ) ;

//Controller and rigbody calls.

	public Rigidbody Rig ;
	public Collider SphereCol ;
	public Collider BoxCol ;
	public Collider CapsualCol ;
	public Collider MeshCol ;
	public Collider WheelCol;

	public CharacterController Cont ;

//Control Bindings

	public KeyCode ObjectActivte = KeyCode.Mouse1 ;
	public KeyCode RotateObject = KeyCode.R ;
	public KeyCode Up = KeyCode.Keypad8 ;
	public KeyCode Dw = KeyCode.Keypad2 ;
	public KeyCode RG = KeyCode.Keypad6 ;
	public KeyCode LF = KeyCode.Keypad4 ;
	public KeyCode FD = KeyCode.KeypadPlus ;
	public KeyCode BK = KeyCode.KeypadMinus ;
	public KeyCode RotateL = KeyCode.Keypad9 ;
	public KeyCode RotateR = KeyCode.Keypad7 ;
	public KeyCode RotateSidewayR = KeyCode.Keypad3 ;
	public KeyCode RotateSidewayL = KeyCode.Keypad1 ;
	public KeyCode RotateVerticalUp = KeyCode.KeypadDivide ;
	public KeyCode RotateVerticalDw = KeyCode.Keypad0 ;

//

// Use this for initialization
	void Start () 
	
{
	
//FindPlayer Code Below

		FindPlayer = GameObject.FindWithTag (ChangeFindPlayerTag);

//FindHeadcam Code Below

		FindHeadcam = GameObject.FindWithTag (ChangeFindHeadcamTag) ;

//Find Object ID Code Below

		ObjectID = this.transform.root.gameObject.name ;

//Rigidbody Input Code Below 

		Rig = gameObject.GetComponent < Rigidbody > () ;

//Collider call Input

		SphereCol = gameObject.GetComponent < SphereCollider > () ;
		BoxCol = gameObject.GetComponent < BoxCollider > () ;
		CapsualCol = gameObject.GetComponent < CapsuleCollider > () ;
		MeshCol = gameObject.GetComponent < MeshCollider > () ;
		WheelCol = gameObject.GetComponent < WheelCollider > () ;

//Controller Input Code Below

		Cont = gameObject.GetComponent < CharacterController > ();

}

//

// Update is called once per frame
	void Update () 

//Main Code Below Here

{

		//IsPlayerGrabbing Code.

{

			if (PlayerGrabbed == true) 

				isPlayerGrabing = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().isGrabbed ;

			else 

				isPlayerGrabing = false;

}

//

{

			if ( isPlayerGrabing == false )

				PlayerGrabbed = false ;

};

//

{

			if ( PlayerGrabbed == false )

				isPlayerGrabing = false ;


};

//Code to Get the Ids the player has grabbed for its targetObject.

{
			
			if (isPlayerGrabing == true )
				
				CheckRayhitID = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().ObjectRayId ;

			else

				CheckRayhitID = null ;

};
	
//
		
{
			
			if ( isPlayerGrabing == true )
				
				CheckEqualID = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().EqualId ;
			
			else
				
				CheckEqualID = null ;
			
};

//Input Code to activate isObjectHeld Below

{

			if ( isPlayerGrabing == true )
			if ( CheckRayhitID == ObjectID )
				
{

				CorrectID = true ;
				isObjectHeld = true ;
				isObjectHeld = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().ObjectHeld; ;

}

};

//Code to reset isObjectHeld Below
		
{
			
			if ( FindPlayer.GetComponent < ObjectGrabIdAndLock > ().ObjectHeld == false )
				
				isObjectHeld = false ;
			
};

//Code to turn on the Id's while held Below 

{

			if (isObjectHeld == true )

{

				CheckEqualID = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().EqualId ;
				CheckRayhitID = FindPlayer.GetComponent < ObjectGrabIdAndLock > ().ObjectRayId ;

}

			else

{

				CheckEqualID = null ;
				CheckRayhitID = null ;

}

};

//Code to call Input Data from Player when held so u can adjust all options via player script and it will update whatever object its grabbing only :)

{

			if ( isObjectHeld == true )

{

				//Extra bools
				
				ArrowkeysEnabled = FindPlayer.GetComponent<ObjectGrabIdAndLock>().ArrowkeysEnabled ;
				OverideDisableGravity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().OverideDisableGravity ;
				OverideDisableContstraints = FindPlayer.GetComponent<ObjectGrabIdAndLock>().OverideDisableContstraints;
				OverideDisableController = FindPlayer.GetComponent<ObjectGrabIdAndLock>().OverideDisableController ;
				OverideCollidersOn = FindPlayer.GetComponent<ObjectGrabIdAndLock>().OverideCollidersOn ;

				//MouseSpeed
				
				MouseSpeedH = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MouseSpeedH ;
				MouseSpeedV = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MouseSpeedV ;

				//Sensitivty Settings
					
				MoveSensitivity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MoveSensitivity ;
				RotateSensitivity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().RotateSensitivity ;
				MouseMoveSensitivity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MouseMoveSensitivity ;
				MouseRotateSensitivity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MouseRotateSensitivity ;
				MouseScrollSensitivity = FindPlayer.GetComponent<ObjectGrabIdAndLock>().MouseScrollSensitivity ;
			
				//Automove Transitionspeed and overide bool
			
				OverrideAutomove = FindPlayer.GetComponent<ObjectGrabIdAndLock>().OverrideAutomove ;
				UseAutoPosition = FindPlayer.GetComponent<ObjectGrabIdAndLock>().UseAutoPosition ;
							
				AutomoveTransitionSpeed = FindPlayer.GetComponent<ObjectGrabIdAndLock>().AutomoveTransitionSpeed ;
			
				//Automove offsets
			
				AutomoveHeightOffsetY = FindPlayer.GetComponent<ObjectGrabIdAndLock>().AutomoveHeightOffsetY ;
				AutomoveSidewaysOffsetX = FindPlayer.GetComponent<ObjectGrabIdAndLock>().AutomoveSidewaysOffsetX ;
				AutomoveInFrontOffsetZ = FindPlayer.GetComponent<ObjectGrabIdAndLock>().AutomoveInFrontOffsetZ ;

}

			else

{

				//Extra bools
				
				ArrowkeysEnabled = false ;
				OverideDisableGravity = false ;
				OverideDisableContstraints = false ;
				OverideDisableController = false ;
				OverideCollidersOn = false ;

				//MouseSpeed
				
				MouseSpeedH = 3.0f ;
				MouseSpeedV = 3.0f ;

				//Sensitivty Settings

				MoveSensitivity = 5.0f ;
				RotateSensitivity = 4.0f ;
				MouseMoveSensitivity = 6.1111111f ;
				MouseRotateSensitivity = 6.1111111f ;
				MouseScrollSensitivity = 5.0f ;
				
				//Automove Transitionspeed and overide bool
				
				OverrideAutomove = false ;
				UseAutoPosition = false ;
								
				AutomoveTransitionSpeed = 0.00511111f ;
				
				//Automove offsets
				
				AutomoveHeightOffsetY = 1.0f ;
				AutomoveSidewaysOffsetX = -0.6f ;
				AutomoveInFrontOffsetZ = 2.5f ;

}

}

//code to check IDs constantly.


{

			if ( isObjectHeld == true )
			
{

			if ( CheckEqualID != ObjectID )//isnot
			
				CorrectID = false ;

}

			else 
				
				CorrectID = false ;

};

//Code to Check RayhitID constantly.

{

			if ( isObjectHeld == true )
			
{

			if ( CheckRayhitID == ObjectID )

				CorrectID = true ;

			else

				CorrectID = false ;

}

};

//Code to Reset Everything.

{
			
			if ( isObjectHeld == false )
				
				CorrectID = false ;
			
};

//

{
			
			if (CorrectID == false )

{

				ArrowkeysEnabled = false ;
				OverideDisableGravity = false ;
				OverrideAutomove = false ;
				isPlayerGrabing = false ;
				PlayerGrabbed = false ;
				ObjectInPlace = false ;
				ObjectActivated = false ;
				RotatingObject = false ;
				OkX = false ;
				OkY = false ;
				OkZ = false ;

}
						
};

//Controls Inputs below
	

//Objectactivated for MouseMovement. if u dont like rightclick change it here to another Keycode input.

{
			
			if ( CorrectID == true )
				
{
				
			if (Input.GetKey (ObjectActivte))
					
				ObjectActivated = true ;
				
}
			
};
		
//

{
			
			if ( CorrectID == true )
				
{
				
			if (Input.GetKeyUp (ObjectActivte))
					
				ObjectActivated = false ;
				
}
			
};

//RotatingObject Key Input code below. if u dont like R change it here

{
		
			if ( CorrectID == true )


{
			
			if (Input.GetKey (RotateObject))
				
				RotatingObject = true ;

}

};
	
//

{
				
			if ( CorrectID == true )
			
{
			
			if (Input.GetKeyUp (RotateObject))
				
				RotatingObject = false ;
			
}

};

//Default-Key Inputs Multiple codes below
		
{

			if ( isObjectHeld == true )
			if ( CorrectID == true ) 
			
{

//Object Up down Input code Below
				
{
				
				if (Input.GetKey (Up))
					
					MoveUp = 1.0f;
				
				if (Input.GetKeyUp (Up))
					
					MoveUp = 0.0f;
				
				if (Input.GetKey (Dw))
					
					MoveDw = -1.0f;
				
				if (Input.GetKeyUp (Dw))
					
					MoveDw = 0.0f;
				
				MoveUpDown = (MoveUp + MoveDw) * (MoveSensitivity / 100);
				
}
			
//Object Left Right Input code Below
			
{
				
				if (Input.GetKey (RG))
					
					MoveRG = 1.0f;
				
				if (Input.GetKeyUp (RG))
					
					MoveRG = 0.0f;
				
				if (Input.GetKey (LF))
					
					MoveLF = -1.0f;
				
				if (Input.GetKeyUp (LF))
					
					MoveLF = 0.0f;
				
				MoveRightLeft = (MoveRG + MoveLF) * (MoveSensitivity / 100);
				
}
			
//Object Forward and back Input code Below
		
{
				
				if (Input.GetKey (FD))
					
					MoveFD = 1.0f;
				
				if (Input.GetKeyUp (FD))
					
					MoveFD = 0.0f;
				
				if (Input.GetKey (BK))
					
					MoveBK = -1.0f;
				
				if (Input.GetKeyUp (BK))
					
					MoveBK = 0.0f;
				
				MoveFdAndBk = (MoveFD + MoveBK) * (MoveSensitivity / 100);
				
}
			
//Object Rotate L and R Input code Below
			
{
				
				if (Input.GetKey (RotateR))
					
					MoveRotateR = 1.0f;
				
				if (Input.GetKeyUp (RotateR))
					
					MoveRotateR = 0.0f;
				
				if (Input.GetKey (RotateL))
					
					MoveRotateL = -1.0f;
				
				if (Input.GetKeyUp (RotateL))
					
					MoveRotateL = 0.0f;
				
				MoveRotateRandL = (MoveRotateR + MoveRotateL) * RotateSensitivity;
				
}
			
//Object Rotate Sideway L and R Input code Below
			
{
				
				if (Input.GetKey (RotateSidewayR))
					
					MoveRotateSidewayR = 1.0f;
				
				if (Input.GetKeyUp (RotateSidewayR))
					
					MoveRotateSidewayR = 0.0f;
				
				if (Input.GetKey (RotateSidewayL))
					
					MoveRotateSidewayL = -1.0f;
				
				if (Input.GetKeyUp (RotateSidewayL))
					
					MoveRotateSidewayL = 0.0f;
				
				MoveRotateSidewayRandL = (MoveRotateSidewayR + MoveRotateSidewayL) * RotateSensitivity;
				
}
			
//Object Rotate Vertical Up and Down Input code Below
			
{
				
				if (Input.GetKey (RotateVerticalUp))
					
					MoveRotateVerticalUp = 1.0f;
				
				if (Input.GetKeyUp (RotateVerticalUp))
					
					MoveRotateVerticalUp = 0.0f;
				
				if (Input.GetKey (RotateVerticalDw))
					
					MoveRotateVerticalDw = -1.0f;
				
				if (Input.GetKeyUp (RotateVerticalDw))
					
					MoveRotateVerticalDw = 0.0f;
				
				MoveRotateVerticalUpandDw = (MoveRotateVerticalUp + MoveRotateVerticalDw) * RotateSensitivity;
				
}
			
}

}

//Defult input Code ends above

//Code to make object Move and rotate with default Keys and with mouse control. Various embedded code in this one piece.

{

			if ( isObjectHeld == true )
			

{

			if ( CorrectID == true )

{

//Main statements while object is Held.
				
					{

						if ( RotatingObject == false )

							this.transform.parent = FindPlayer.transform ;
					
					}

					{

						if ( RotatingObject == true )

							this.transform.parent = null ;

					}

					ObjectRotation = this.transform.eulerAngles ;

					yaw += MouseSpeedH * Input.GetAxis ("Mouse X");
					pitch -= MouseSpeedV * Input.GetAxis ("Mouse Y");

					EulerX = transform.eulerAngles.x ;
					EulerY = transform.eulerAngles.y ;
					EulerZ = transform.eulerAngles.z ;

					LocEulerX = transform.localEulerAngles.x ;
					LocEulerY = transform.localEulerAngles.y ;
					LocEulerZ = transform.localEulerAngles.z ;

					RotationX = transform.rotation.x ;
					RotationY = transform.rotation.y ;
					RotationZ = transform.rotation.z ;

					LocRotationX = transform.localRotation.x ;
					LocRotationY = transform.localRotation.y ;
					LocRotationZ = transform.localRotation.z ;

//Main Collider Check and turn on.

					//Overide CollidersOn

					{

					if (OverideCollidersOn == true )

						ColliderOn = false ;

					//
						
					{
							
					if ( SphereCol != null )//isnot
								
						SphereCol.enabled = false ;
														
					}
						
					//
						
					{
							
					if ( BoxCol != null )
								
						BoxCol.enabled = false ;

					}
						
					//
						
					{
							
					if ( CapsualCol != null )
								
						CapsualCol.enabled = false ;

					}
						
					//
						
					{
							
					if ( MeshCol != null )
								
						MeshCol.enabled = false ;
														
					}
						
					//
						
					{
							
					if ( WheelCol != null )
								
						WheelCol.enabled = false ;
														
					}

					//

					}

					//Overide ends above

					//Turn collider on unless overiden

					{

					if ( OverideCollidersOn == false )

					{

					//
							
					{
								
					if ( SphereCol != null )//isnot
									
						SphereCol.enabled = true ;
						ColliderOn = true ;
								
					}
							
					//
							
					{
								
					if ( BoxCol != null )
									
						BoxCol.enabled = true ;
						ColliderOn = true ;
								
					}
							
					//
							
					{
								
					if ( CapsualCol != null )
									
						CapsualCol.enabled = true ;
						ColliderOn = true ;
								
					}
							
					//
							
					{
								
					if ( MeshCol != null )
									
						MeshCol.enabled = true ;
						ColliderOn = true ;
								
					}
							
					//
							
					{
								
					if ( WheelCol != null )
									
						WheelCol.enabled = true ;
						ColliderOn = true ;
								
					}

					//

					}

					}

					//Collider Check Ends above

//Rigidboy codes and controller codes below

					//Use Continuous Detection when rigidbody present

					{

					if ( Rig != null )//isnot

						Rig.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic ;

					}

					//AutoDisable Gravity unless Overiden
					
					{
						
					if ( OverideDisableGravity == false )
					if ( Rig != null )//isnot
																														
						Rig.useGravity = false ;
												
					}

					//Add force when held if gravity not disabled..... needs tweaking

					{

					if ( OverideDisableGravity == true )
					if ( Rig != null )//isnot

						Rig.AddForce( new Vector3 (0.0f , 11.625f , 0.0f ), ForceMode.Force);



					}

					//AutoDisable Constraints unless Overiden
					
					{
						
					if ( OverideDisableContstraints == false )
					if ( Rig != null )//isnot

						Rig.constraints = RigidbodyConstraints.FreezeAll ;
																												
					}
					
					//AutoDisable Controller when Collider detected unless Overiden
					
					{
						
					if ( OverideDisableController == false )
					
					{

					if ( ColliderOn == true )
						
					{

					if ( Cont != null )//isnot
																								
						Cont.enabled = false ;

					}

					else//if no collider controller will defualt on.

						Cont.enabled = true ;

					}

					}

					//turn on controller if overide enabled

					{

					if ( OverideDisableController == true )

						Cont.enabled = true ;

					}

					//rig and collider Code ends here above

//AutoCodes begins below
//updated to use locEuler instead to avoid errors

//Use Default Rotation auto code

					{

						if ( OverideDiagnals == true )

							//

						{

							//

							{

								if ( LocEulerY >= 0.0f )
								if ( LocEulerY <= 45.55f )

									AutoDefault = true ;

							}

							//

							{

								if ( LocEulerY >= 45.56f )
								if ( LocEulerY <= 135.44f )

									AutoDefault = false ;

							}

							//

							{

								if ( LocEulerY >= 135.45f )
								if ( LocEulerY <= 215.55f )

									AutoDefault = true ;

							}

							//

							{

								if ( LocEulerY >= 215.56f )
								if ( LocEulerY <= 315.44f )

									AutoDefault = false ;

							}

							//

							{

								if ( LocEulerY >= 315.46f )
								if ( LocEulerY <= 360.0f )

									AutoDefault = true ;

							}

							//

							}

							//AutoSwapAxis Code

							{

							if ( LocEulerY >= 0.0f )
							if ( LocEulerY <= 45.54f )

								AutoSwapAxis= false ;

							}

							//

							{

							if ( LocEulerY >= 45.45f )
							if ( LocEulerY <= 135.55f )

								AutoSwapAxis= true ;

							}

							//

							{

							if ( LocEulerY >= 135.56f )
							if ( LocEulerY <= 215.44f )

								AutoSwapAxis= false ;

							}

							//

							{

							if ( LocEulerY >= 215.45f )
							if ( LocEulerY <= 315.45f )

								AutoSwapAxis= true ;

							}

							//

							{

							if ( LocEulerY >= 315.46f )
							if ( LocEulerY <= 360.0f )

								AutoSwapAxis= false ;

							}
													
					//Autoswap ends

					};

					//Use DefualtRotation Ends above

//AutoDefualt Code Begins

					{

						if ( OverideDiagnals == false )

					{

						//

						{

						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 22.55f )

							AutoDefault = true ;

						}

						//

						{

						if ( LocEulerY >= 22.56f )
						if ( LocEulerY <= 157.44f )

							AutoDefault = false ;

						}

						//

						{

						if ( LocEulerY >= 157.45f )
						if ( LocEulerY <= 202.55f )

							AutoDefault = true ;

						}

						//

						{

						if ( LocEulerY >= 202.56f )
						if ( LocEulerY <= 337.44f )

							AutoDefault = false ;

						}

						//

						{

						if ( LocEulerY >= 337.45f )
						if ( LocEulerY <= 360.0f )

							AutoDefault = true ;

						}

						//

					}

					};

					//

					//AutoDefault Code ends

//AutoDiagnals Code below

					{

						if ( OverideDiagnals == false )

					{

					//

					{

					if ( LocEulerY >= 0.0f )
					if ( LocEulerY <= 112.45f )

							AutoDiagnals = false ;

					}

					//

					{

						if ( LocEulerY >= 112.46f )
						if ( LocEulerY <= 157.54f )

							AutoDiagnals = true ;

					}

					//

					{

						if ( LocEulerY >= 157.55f )
						if ( LocEulerY <= 292.45f )

							AutoDiagnals = false ;

					}

					//

					{

						if ( LocEulerY >= 292.46f )
						if ( LocEulerY <= 337.54f )

							AutoDiagnals = true ;

					}

					//

					{

						if ( LocEulerY >= 337.55f )
						if ( LocEulerY <= 360.0f )

							AutoDiagnals = false ;

					}

					//

					}

					};

					//Ends

//AutoSwapAxis Code

					{

						if ( OverideDiagnals == false )

					{

					//

					{

						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 67.44f )

							AutoSwapAxis= false ;

					}

					{

						if ( LocEulerY >= 67.45f )
						if ( LocEulerY <= 112.55f )

							AutoSwapAxis= true ;
						
					}

					//

					{

						if ( LocEulerY >= 112.56f )
						if ( LocEulerY <= 247.44f )

							AutoSwapAxis= false ;

					}

					//

					{

						if ( LocEulerY >= 247.45f )
						if ( LocEulerY <= 292.55f )

							AutoSwapAxis= true ;

					}

					//

					{

						if ( LocEulerY >= 292.56f )
						if ( LocEulerY <= 360.0f )

							AutoSwapAxis= false ;

					}

					//

					}

					};

					//Autoswap ends

//AutoSwapDiagnals Code Begins

					{

						if ( OverideDiagnals == false )

					{

					//

					{

						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 22.55f )

							AutoSwapDiagnals = false ;

					}

					//

					{

						if ( LocEulerY >= 22.56f )
						if ( LocEulerY <= 67.44f )

							AutoSwapDiagnals = true ;

					}



					//

					{

						if ( LocEulerY >= 67.45f )
						if ( LocEulerY <= 202.55f )

							AutoSwapDiagnals = false ;

					}

					//

					{

						if ( LocEulerY >= 202.56f )
						if ( LocEulerY <= 247.44f )

							AutoSwapDiagnals = true ;

					}

					//

					{

						if ( LocEulerY >= 247.45f )
						if ( LocEulerY <= 360.0f )

							AutoSwapDiagnals = false ;

					}

					//Diagnals End

					}

					};

					//Auto Codes End

//Object Upsidedown trigger to see if object is normal or upsidedown.

					//

					{

						if ( LocEulerZ >= 0.1f )
						if ( LocEulerZ <= 89.9f )

							ObjectUpsideDown = false ;

					}

					//

					{
						
						if ( LocEulerZ >= 90.0f )
						if ( LocEulerZ <= 270.0f )
							
							ObjectUpsideDown = true ;

					}

					//

					{
						
						if ( LocEulerZ >= 270.1f )
						if ( LocEulerZ <= 360.0f )
							
							ObjectUpsideDown = false ;

					}

					//

					//Object upsidedown ends

//Object  Facing Forward code below 

					//Auto Defualt

					{

						if ( AutoDefault == true )
						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 90.0f )
							
							ObjectFacingFD = true ;

					}

					//

					{

						if ( AutoDefault == true )
						if ( LocEulerY >= 270.0f )
						if ( LocEulerY <= 360.0f )

							ObjectFacingFD = true ;

					}

					//

					{

						if ( AutoDefault == true )
						if ( LocEulerY >= 90.1f )
						if ( LocEulerY <= 270.0f )

							ObjectFacingFD = false ;

					}

					//AutoDiagnals axis

					{

						if ( AutoDiagnals == true )
						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 44.9f )

							ObjectFacingFD = true ;

					}

					//

					{

						if ( AutoDiagnals == true )
						if ( LocEulerY >= 45.0f )
						if ( LocEulerY <= 225.0f )

							ObjectFacingFD = false ;

					}

					//

					{

						if ( AutoDiagnals == true )
						if ( LocEulerY >= 225.1f )
						if ( LocEulerY <= 360.0f )

							ObjectFacingFD = true ;

					}

					//AutoSwap axis

					//

					{

						if ( AutoSwapAxis == true )
						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 179.9f )

							ObjectFacingFD = false ;

					}

					//

					{

						if ( AutoSwapAxis == true )
						if ( LocEulerY >= 180.0f )
						if ( LocEulerY <= 360.0f )

							ObjectFacingFD = true ;

					}

					//
																	
					//AutoswapDiagnals

					{

						if ( AutoSwapDiagnals == true )
						if ( LocEulerY >= 0.0f )
						if ( LocEulerY <= 134.9f )

							ObjectFacingFD = false ;

					}

					//

					{

						if ( AutoSwapDiagnals == true )
						if ( LocEulerY >= 135.0f )
						if ( LocEulerY <= 315.0f )

							ObjectFacingFD = true ;

					}

					//

					{

						if ( AutoSwapDiagnals == true )
						if ( LocEulerY >= 315.1f )
						if ( LocEulerY <= 360.0f )

							ObjectFacingFD = false ;

					}

					//Object facing forward ends

//Code to make object AutoMove to set location via The Offsets Vector3 ObjectMOve which are above in main for this section.

					//

					PlayerPosition = FindPlayer.transform.localPosition ;
					ObjectMove = new Vector3 (AutomoveSidewaysOffsetX , AutomoveHeightOffsetY , AutomoveInFrontOffsetZ) ;
					ObjectMove2 = (PlayerPosition + ObjectMove) ;

					//

					{

						float ToffsetX = FindPlayer.transform.localPosition.x ;

						float ToffsetY = FindPlayer.transform.localPosition.y ;

						float ToffsetZ = FindPlayer.transform.localPosition.z ;

						float StartX = transform.localPosition.x ;

						float StartY = transform.localPosition.y ;

						float StartZ = transform.localPosition.z ;

						//

						{

							if ( StartX >= (ToffsetX + AutomoveSidewaysOffsetX) )

								Xtransition = -AutomoveTransitionSpeed ;

							else

								Xtransition = AutomoveTransitionSpeed ;

						}

						//

						{

							if ( StartY >= (ToffsetY + AutomoveHeightOffsetY) )

								Ytransition = -AutomoveTransitionSpeed ;

							else

								Ytransition = AutomoveTransitionSpeed ;

						}

						//

						{

							if ( StartZ >= (ToffsetZ + AutomoveInFrontOffsetZ) )

								Ztransition = -AutomoveTransitionSpeed ;

							else

								Ztransition = AutomoveTransitionSpeed ;

						}

						//Automove if Overide false code Below

						{


							if ( ObjectInPlace == false )
							if ( OverrideAutomove == false )

							{

								ObjectMove3 = new Vector3 ( Xtransition , Ytransition , Ztransition ) ;
								transform.localPosition += ObjectMove3 ;

							}

						}

						//Reset the Automove's Vector

						{

							if ( ObjectInPlace == true )

								ObjectMove3 = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;

						}

						//Overides true Statment below

						{

							if ( OverrideAutomove == true )
							if ( UseAutoPosition == false )

								ObjectInPlace = true ;
							OkX = true ;
							OkY = true ;
							OkZ = true ;

						}

					};

					//UseAutoPosition

					{

						if ( OverrideAutomove == true )
						if ( UseAutoPosition == true )
						if ( ObjectInPlace == false )

							transform.localPosition = ObjectMove2 ;

					}

					//Automove code ends above

					//Code to check if Object is in Position.

					{

						float x = transform.localPosition.x ;
						float y = transform.localPosition.y ;
						float z = transform.localPosition.z ;

						float x1 = ObjectMove2.x ;
						float y1 = ObjectMove2.y ;
						float z1 = ObjectMove2.z ;

						//

						{

							if ( x >= x1-0.5f )

								OkX = true ;

							if ( x >= x1+0.5f )

								OkX = false ;

							if ( x <= x1-0.5f )

								OkX = false ;

						}

						//

						{

							if ( y >= y1-0.5f )

								OkY = true ;

							if ( y >= y1+0.5f )

								OkY = false ;

							if ( y <= y1-0.5f )

								OkY = false ;

						}

						//

						{

							if ( z >= z1-0.5f )

								OkZ = true ;

							if ( z >= z1+0.5f )

								OkZ = false ;

							if ( z <= z1-0.5f )

								OkZ = false ;

						}

						//

						{

							if ( OkX == true )

							if ( OkY == true )

							if ( OkZ == true )

								ObjectInPlace = true ;

						}

					}

					//Code to check position ends above


///this Next entire piece of code below is long and confusing and serves only to have the "overide bools" activate without question or error so long is more stable
// I tried to move it outside this main core but it wouldnt have a bar of it i assume it need most of the resources with it and that overode the point of moving it.



//Default Key Rotate Auto Invserion and Inversion Options Begins Below

					{

						if ( isObjectHeld == true )
						if ( CorrectID == true )

					{

					//Main Statments

//Rotate Axis, and Auto Inversion Code Begins Below

					

//UseDefualt

							{

							if ( UseDefaultRotaions == true )
							if ( OverideRotateToFace == true )	
																

								{
									
									if ( InvertRotate == false )

										InvertRotate1 = -MoveRotateRandL ;

									else

										InvertRotate1 = MoveRotateRandL ;

								}
																
							}

							//Defualt without rotate to face Ends

//UseDefault with rotate to face begins

							{

							if ( UseDefaultRotaions == true )
							if ( OverideRotateToFace == false )	

							{

							//

							{

								if ( ObjectFacingFD == true )

									{

										if ( InvertRotate == false )

											InvertRotate1 = -MoveRotateRandL ;

										else

											InvertRotate1 = MoveRotateRandL ;

									}

								}

								//

								{

									if ( ObjectFacingFD == false )

									{

										if ( InvertRotate == false )

											InvertRotate1 = MoveRotateRandL ;

										else

											InvertRotate1 = -MoveRotateRandL ;

									}

								}

								//

							}

							};

							//UseDefualt with rotate to face Ends

//Rotate Auto Defualt Begins no rotate to face

							{

								if ( UseDefaultRotaions == false )
								if ( AutoDefault == true )
								if ( OverideRotateToFace == true )

								{

									if ( InvertRotate == false )

										InvertRotate1 = MoveRotateRandL ;

									else

										InvertRotate1 = -MoveRotateRandL ;

								}

							}

							//Rotate Auto Default with rotate to face

							{

								if ( UseDefaultRotaions == false )
								if ( AutoDefault == true )
								if ( OverideRotateToFace == false )	

								{

									//

									{

										if ( ObjectFacingFD == true )

										{

											if ( InvertRotate == false )

												InvertRotate1 = MoveRotateRandL ;
											
											else

												InvertRotate1 = -MoveRotateRandL ;
											
										}

									}

									//

									{

										if ( ObjectFacingFD == false )

										{

											if ( InvertRotate == false )

												InvertRotate1 = -MoveRotateRandL ;

											else

												InvertRotate1 = MoveRotateRandL ;

										}

									}

									//

								}

							};

							//Auto Defualt Ends

							//Auto Diagnals



							//Auto Diagnals Ends

							//AutoSwapAxis with rotate to face

							{

								if ( UseDefaultRotaions == false )
								if ( AutoSwapAxis == true)
								if ( OverideRotateToFace == false )

								{

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotate == false )

												InvertRotate1 = MoveRotateRandL ;

											else

												InvertRotate1 = -MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotate == false )

												InvertRotate1 = MoveRotateRandL ;

											else

												InvertRotate1 = -MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotate == false )

												InvertRotate1 = -MoveRotateRandL ;

											else

												InvertRotate1 = MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotate == false )

												InvertRotate1 = -MoveRotateRandL ;

											else

												InvertRotate1 = MoveRotateRandL;

										}

									}

									//

								}

							};

							//Autoswap with rotate to face Ends

							//AutoSwapAxis no rotate to face

							{

								if ( UseDefaultRotaions == false )
								if ( AutoSwapAxis == true)
								if ( OverideRotateToFace == true )

								{

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotate == false )

												InvertRotate1 = MoveRotateRandL ;

											else

												InvertRotate1 = -MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotate == false )

												InvertRotate1 = -MoveRotateRandL ;

											else

												InvertRotate1 = MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotate == false )

												InvertRotate1 = MoveRotateRandL ;

											else

												InvertRotate1 = -MoveRotateRandL ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotate == false )

												InvertRotate1 = -MoveRotateRandL ;

											else

												InvertRotate1 = MoveRotateRandL;

										}

									}

									//

								}

							};


							//AutoSwapAxis with rotate to face Ends

							//AutoSwap Diagnals



							//AutoSwap Diagnals Ends

							//rotate code ends above






							//InvertRotateSideways Axis, Code beginsBelow

							{

								if ( InvertRotateSideway == true )

									InvertRotateSideways1 = MoveRotateSidewayRandL ;

								else 

									InvertRotateSideways1 = -MoveRotateSidewayRandL ;

							}

							//Rotate Sideways Ends






							//InvertRotateVerticalUpAndDown Axis, Code begins Below

//Main Use default Vertical condion no rotate to face

							{

								if ( UseDefaultRotaions == true)
								if ( OverideRotateToFace == true )

								{

									//

									{

										if ( AutoDefault == true)

										{

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

										}

									};

									//Autoswap

									{

										if ( AutoSwapAxis == true)

										{

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

										}

									};


									//

								}

							};

							//Use Default without Rotate to face Ends Above

//Main Use Default Vertical condion With Rotate to face 

							{
								
								if ( UseDefaultRotaions == true)
								if ( OverideRotateToFace == false )

								{

									//autoDefault

									{

										if ( AutoDefault == true)

										{

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

										}

									};

									//Autoswap

									{
										
										if ( AutoSwapAxis == true)

										{

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == true )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == false )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

											{

												if ( ObjectUpsideDown == true )
												if ( ObjectFacingFD == false )

												{

													if ( InvertRotateVertical == false )

														InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

													else

														InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

												}

											}

											//

										}

									};

									//

								}

							};

							//UseDefault Vertical and rotate to face ends 

//Main Autodefault begins without rotate to face

							{

								if ( AutoDefault == true)
								if ( UseDefaultRotaions == false )
								if ( OverideRotateToFace == true )

								{

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

										}

									}

									//

								}

							};

							//Main AutoDefault Ends

//Main Autodefault with Rotate to Face begins

							{

								if ( AutoDefault == true)
								if ( UseDefaultRotaions == false )
								if ( OverideRotateToFace == false )

								{

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == true )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == false )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectUpsideDown == true )
										if ( ObjectFacingFD == false )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

										}

									}

									//

								}

							};

							//Auto Default ends



//Auto Diagnals begins



							//Auto Diagnals Ends



							//Auto Swap Axis begins//fixed an error here where forgot to add axis swap in with rotate to face

							{

								if ( AutoSwapAxis == true )
								if ( UseDefaultRotaions == false )
								if ( OverideRotateToFace == true )

								{

									if ( InvertRotateVertical == false )

										InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

									else

										InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

								}

							};

							//AutoSwap axis With rotate to face

							{

								if ( AutoSwapAxis == true )
								if ( OverideRotateToFace == false )	

								{

									//

									{

										if ( ObjectFacingFD == true )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

										}

									}

									//

									{

										if ( ObjectFacingFD == false )

										{

											if ( InvertRotateVertical == false )

												InvertRotateVertical1 = MoveRotateVerticalUpandDw ;

											else

												InvertRotateVertical1 = -MoveRotateVerticalUpandDw ;

										}

									}

									//

								}

							};

					//AutoSwap Ends



//Autoswap Diagnals Begins



					//Autoswap Diagnals Ends

					}

					};

					//Vertical Ends Here above



					//Default Key Rotation Inverson and Auto Inversion Ends Here Above

//Main Default Movment Code Below
					
					UpAndDown = new Vector3 ( 0.0f , MoveUpDown , 0.0f ) ;
					RightAndLeft = new Vector3 ( MoveRightLeft , 0.0f , 0.0f ) ;
					ForwardAndBack = new Vector3 ( 0.0f , 0.0f , MoveFdAndBk ) ;
					
					
					transform.localPosition += UpAndDown ;
					transform.localPosition += RightAndLeft ;
					transform.localPosition += ForwardAndBack ;
					
					//Main Movement code ends above

//Main Default Rotate Code Begins Below
										
//Main Rotation Movement statement

//Default code

					{
						
						if ( UseDefaultRotaions == true )

						{
							
							ObjectRotation += new Vector3 ( InvertRotateVertical1 , InvertRotateSideways1, InvertRotate1 ) ;

							transform.rotation = Quaternion.Euler ( ObjectRotation ) ;
												
						}
											
					}

//Rotation Axis Code AutoDefault

					{
						
						if ( UseDefaultRotaions == false )
						if ( AutoSwapAxis == false )
						if ( AutoDiagnals == false )
						if ( AutoSwapDiagnals == false )

						if ( AutoDefault == true )
							
							ObjectRotation += new Vector3 (InvertRotateVertical1 , InvertRotateSideways1, InvertRotate1 ) ;

							transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

					}

//Swap axis Code

					{

						if ( UseDefaultRotaions == false )
						if ( AutoDefault == false )
						if ( AutoDiagnals == false )
						if ( AutoSwapDiagnals == false )

						if ( AutoSwapAxis == true )

							ObjectRotation += new Vector3 (InvertRotate1 , InvertRotateSideways1, InvertRotateVertical1  ) ;

							transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

					}

//Diagnal axis Code

					{

						if ( UseDefaultRotaions == false )
						if ( OverideDiagnals == false )
						if ( AutoDefault == false )
						if ( AutoSwapAxis == false )
						if ( AutoSwapDiagnals == false )
													
						if ( AutoDiagnals == true )
							
							ObjectRotation += new Vector3 (InvertRotate1 + -InvertRotateVertical1  , InvertRotateSideways1, -InvertRotateVertical1 + InvertRotate1 ) ;

						transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

					}

//DiagnalsSwap axis Code

					{

						if ( UseDefaultRotaions == false )
						if ( OverideDiagnals == false )
						if ( AutoDefault == false )
						if ( AutoSwapAxis == false )
						if ( AutoDiagnals == false )
							
						if ( AutoSwapDiagnals == true )
							
							ObjectRotation += new Vector3 (-InvertRotate1 + -InvertRotateVertical1  , InvertRotateSideways1, -InvertRotateVertical1 + -InvertRotate1 ) ;

							transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

					}

					//main rotation code ends here above

//Defualt Arrowkey Movement Otions Below, wouldnt recomend using unless u make character stop moving. which i havent on mine.
//havent added invert options for arrowrotate as im not going to use it this is here if u want to implement arrow keys in.


					{

					if ( ArrowkeysEnabled == true )

					{
													;							
						Haxis = Input.GetAxis ("Horizontal");
						Vaxis = Input.GetAxis ("Vertical");

						transform.localPosition += new Vector3 (Haxis/100 ,Vaxis/100 , 0.0f ) ;//arrow keys.	
						
					//Default RotateArrowKey Inputs Below (broken need to update)

					{

					if ( ObjectActivated == true )
																
						transform.localEulerAngles += new Vector3 ( -Vaxis  , - Haxis , 0.0f ) * RotateSensitivity ;

					}

					//

					{

					if ( RotatingObject == true )

						transform.localEulerAngles += new Vector3 ( -Vaxis  , 0.0f , Haxis ) ;
					}

					}

					}

					//Arrowkey ends here above

					//Default movement and Rotate ends above

//Code For Drag Movement with Mouse and rotate, multiple code embedded for mouse Below

					{
					
					if ( ObjectActivated == true )
					
					//Main Stament area if Object activated is true

					{

					//Timer code to find Mouse angle change over time.

					{

					if ( TimerDone == false )

					Timer += Time.deltaTime ;

					}

					//
						
					{

					if ( Timer >= Timetowait )
										
					{
											
						pitchFlash = pitch ;
						yawFlash = yaw ;
						TimerDone = true ;
						TimerDoneTriggered = true ;
						Timer = 0.0f ;
											
					}
					
					
					}

					//TimerDone reset 
						
					{

					if ( Timer <= Timetowait )

						TimerDone = false ;

					}

					//Code not to Add MouseInput data untill first trigger.
					
					{

					if ( TimerDoneTriggered == true )

						pitchInc = pitchFlash - pitch ;
						yawInc = yawFlash - yaw ;
						
					}
					
					//Timer code ends here above

//Main MouseMovement Input code Below 
										
					{

					if ( RotatingObject == false )

					{
			
					MouseMoveUpDw = new Vector3 (0.0f , pitchInc * ( MouseMoveSensitivity/100 ) , 0.0f ) ;
					MouseMoveSideways = new Vector3 (-yawInc * ( MouseMoveSensitivity/100 ) , 0.0f , 0.0f ) ;
					MouseScrollFB = new Vector3 (0.0f , 0.0f , Input.GetAxis ( "Mouse ScrollWheel" )* ( MouseMoveSensitivity / 2 ) ) ;
													
					transform.localPosition += MouseMoveUpDw ;
					transform.localPosition += MouseMoveSideways ;
					transform.localPosition += MouseScrollFB ;
					
					}

					}

					//All Main Mouse movement code ends here above
												
//Mouse Rotation code With inversion code begins Below

					{

					if ( RotatingObject == true )

					{

//Main Mouse Rotate Code Below

//Main Statements below

//AutoAXisSwap Code below 
										

									//Default code

									{

										if ( UseDefaultRotaions == true )

										{

											ObjectRotation += new Vector3 ( InvertMouseRVertical1 , InvertMouseRSideways1 , InvertMouseRotate1 ) ;

											transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

										}

									}

									//Rotation Axis Code AutoDefault

									{

										if ( UseDefaultRotaions == false )
										if ( AutoSwapAxis == false )
										if ( AutoDiagnals == false )
										if ( AutoSwapDiagnals == false )

										if ( AutoDefault == true )


											ObjectRotation += new Vector3 (InvertMouseRVertical1 , InvertMouseRSideways1, InvertMouseRotate1 ) ;

										transform.rotation = Quaternion.Euler ( ObjectRotation ) ;



									}

									//Swap axis Code

									{

										if ( UseDefaultRotaions == false )
										if ( AutoDefault == false )
										if ( AutoDiagnals == false )
										if ( AutoSwapDiagnals == false )

										if ( AutoSwapAxis == true )

											ObjectRotation += new Vector3 (InvertMouseRotate1 , InvertMouseRSideways1, InvertMouseRVertical1 ) ;

										transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

									}

									//Diagnals axis Code

									{

										if ( UseDefaultRotaions == false )
										if ( AutoDefault == false )
										if ( AutoSwapAxis == false )
										if ( AutoSwapDiagnals == false )

										if ( AutoDiagnals == true )

											ObjectRotation += new Vector3 (InvertMouseRotate1 + -InvertMouseRVertical1  , InvertMouseRSideways1, -InvertMouseRVertical1 + InvertMouseRotate1 ) ;

										transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

									}

									//Diagnals axis Code

									{

										if ( UseDefaultRotaions == false )
										if ( AutoDefault == false )
										if ( AutoSwapAxis == false )
										if ( AutoDiagnals == false )

										if ( AutoSwapDiagnals == true )

											ObjectRotation += new Vector3 (-InvertMouseRotate1 + -InvertMouseRVertical1  , InvertMouseRSideways1, -InvertMouseRVertical1 + -InvertMouseRotate1 ) ;

										transform.rotation = Quaternion.Euler ( ObjectRotation ) ;

									}

									//main rotation code ends here above
					
					}
					
					};

					//all Rotation Code ends Here above

					}

					};

					//All Object activated code ends here above

//Resets if not Right clicked//krsna

					{

					if ( ObjectActivated == false )
					
					{
						
						TimerDoneTriggered = false ;
						MouseMoveUpDw = new Vector3 (0.0f , 0.0f , 0.0f ) ;
						MouseMoveSideways = new Vector3 (0.0f , 0.0f , 0.0f ) ;
						MouseScrollFB = new Vector3 (0.0f , 0.0f , 0.0f ) ;

						yaw = 0.0f ;
						yawFlash = 0.0f ;
						yawInc = 0.0f ;
							
						pitch = 0.0f ;
						pitchFlash = 0.0f ;
						pitchInc = 0.0f ;

					}

					}

			//resets ends above

			}

			//Code for ALL Mouse and default Movement ends Above

			//corectID's else statmentmet

			else

			// code to reset Involved Vectors on Objectdrop or loss.

			{
								
			PlayerPosition = new Vector3 (0.0f , 0.0f , 0.0f ) ;

			ObjectMove3 = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;
			ObjectMove2 = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;
			ObjectMove = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;

			UpAndDown = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			RightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			ForwardAndBack = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			RRightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			RSRightAndLeft = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			RVUpAndDown = new Vector3 (0.0f , 0.0f , 0.0f ) ;

			transform.localPosition += new Vector3 ( 0.0f , 0.0f , 0.0f ) ;

			}

}

//isObjectsHeld's else statement

			else

//Area to undo anything that may not have triggered off when item dropped or deselected.

{

			
			//Restore Gravity 
			
			{

					if ( OverideDisableGravity == false )
					if ( Rig != null )//isnot
						
						Rig.useGravity = true ;
			
			}

			//Restore Constraints 

			{

					if ( OverideDisableContstraints == false )
					if ( Rig != null )//isnot
					
						Rig.constraints = RigidbodyConstraints.None ; 
			
			}

			//Restore Controller if no rigidbody

			{

					if ( Rig == null )
					if ( Cont != null )//isnot
					
						Cont.enabled = true ;
			
			}

			//Dont Restore Controller if RigidBody present
				
			{

					if ( Rig != null )//isnot
					if ( Cont != null )//isnot
								
						Cont.enabled = false ;
					
			}
				
			//

			this.transform.parent = null ;

			PlayerPosition = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			
			ObjectMove = new Vector3 (0.0f , 0.0f , 0.0f ) ;
			ObjectMove2 = new Vector3 (0.0f , 0.0f , 0.0f ) ;

}

};

//Full Movement and Rotate code Ends Here.







//Script Complete Enjoy

//By Ryan Kappes. 2017








}
}
