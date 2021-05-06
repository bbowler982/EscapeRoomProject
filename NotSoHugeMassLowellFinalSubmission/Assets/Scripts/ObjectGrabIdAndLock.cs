using UnityEngine;
using System.Collections;

public class ObjectGrabIdAndLock : MonoBehaviour // This Scrip Needs ObjectReplyIdAndMove Script on all "moveable Objects".

{

//

	private Camera RaycastOrigin ;
	private RaycastHit ObjectHit;
	private int Layermask = (1<<9)+(1<<0)+(1<<8)+(1<<10) ;
	private int LayervalueInt1 ;
	private int LayervalueInt2 ;
	private int LayervalueInt3 ;
	private int LayervalueInt4 ;

//Change layers to hit below new ones can be add using same format.

	public string ChangeRayHitLayer1 = "MoveableObjects";
	public string ChangeRayHitLayer2 = "Default";
	public string ChangeRayHitLayer3 = "MainPlayer";
	public string ChangeRayHitLayer4 = "Enemy";

//Change Find the player tag refference below

	public GameObject FindPlayer ;
	public string ChangeFindPlayerSearchTag = "MainPlayer";

// change raycast origin headcam tag below

	public GameObject HeadCam ;
	public string ChangeHeadCamSearchTag = "HeadCam";

// control system for MoveObject Below

	private float Timer1 = 0.0f ;
	private float Timer2 = 0.0f ;

//

	public GameObject Targetfloat ;
	public string ObjectType = "" ;
	public string ObjectClass = "" ;
	public string ObjectUse = "" ;

	public string ObjectReplyId = "" ;
	public string ObjectRayId = "" ;
	public string EqualId = "" ;
	public float ObjectDistance = 0.0f ;

	public bool CorrectReply = false ;
	public bool CorrectConstantId = false ;

//

	private bool Timer1Done = false ;
	private bool Timer2Done = false ;

//

	public bool Rayhit = false ;
	public bool Grab = false ;
	public bool isGrabbed = false;
	public bool GrabToggle = false ;
	public bool ObjectHeld = false ;
	public bool inCameraView = false ;
	public bool inCameraViewOveride = false ;
	public bool WithinRange = false;
	public bool WithinRangeOveride = false ;

	//Objects Extra bools
	
	public bool ArrowkeysEnabled = false ;
	public bool OverideDisableGravity = false ;
	public bool OverideDisableContstraints = false ;
	public bool OverideDisableController = false ;
	public bool OverideCollidersOn = false ;

	//ObjectsSensitivty Settings
	
	public float MoveSensitivity = 5.0f ;
	public float RotateSensitivity = 4.0f ;

	//MouseSpeed
	
	public float MouseSpeedH = 3.0f ;
	public float MouseSpeedV = 3.0f ;

	public float MouseMoveSensitivity = 6.1111111f ;
	public float MouseRotateSensitivity = 6.1111111f ;
	public float MouseScrollSensitivity = 5.0f ;

	//ObjectsAutomove Transitionspeed and overide options
	
	public bool OverrideAutomove = true ;
	public bool UseAutoPosition = false ;
			
	public float AutomoveTransitionSpeed = 0.00511111f ;
	
	//ObjectsAutomove offsets
	
	public float AutomoveHeightOffsetY = 1.0f ;
	public float AutomoveSidewaysOffsetX = -0.6f ;
	public float AutomoveInFrontOffsetZ = 2.5f ;

//

	public float Raylength = 500.0f;
	public float MaxGrabDistance = 5.0f ;
	public float TimeToWait = 0.05f ;

	public Vector3 ScreenPoint = new Vector3 (0.0f, 0.0f, 0.0f);
	private Vector3 LinecastOrigin = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;
	private Vector3 LinecastTarget = new Vector3 ( 0.0f , 0.0f , 0.0f ) ;

// Change Controls Below at = keycode.Newkey;

	public KeyCode BindGrabToggle = KeyCode.F;


	// Use this for initialization
	void Start () 
	
{
	
//Find the Player Code Below

		FindPlayer = GameObject.FindGameObjectWithTag (ChangeFindPlayerSearchTag) ;

		this.transform.parent = FindPlayer.transform;

// Layers you can add more here

		LayervalueInt1 = LayerMask.NameToLayer  (ChangeRayHitLayer1);
		
		LayervalueInt2 = LayerMask.NameToLayer  (ChangeRayHitLayer2);
		
		LayervalueInt3 = LayerMask.NameToLayer  (ChangeRayHitLayer3);
		
		LayervalueInt4 = LayerMask.NameToLayer  (ChangeRayHitLayer4);

// Binary adding of layers. just add another + sign and ( same format )

		Layermask = (1 << LayervalueInt1) + (1<<LayervalueInt2)+ (1<<LayervalueInt3)+ (1<<LayervalueInt4) ;

//Headcam Location

		HeadCam = GameObject.FindGameObjectWithTag (ChangeHeadCamSearchTag) ;

		RaycastOrigin = HeadCam.GetComponent <Camera>();

}
	
	// Update is called once per frame
	void Update () 
	
{

//AdjView input code below
		
{
			
		if (Input.GetKey (BindGrabToggle))
				
				Grab = true ;
			
};
		
//
		
{
			
			if (Input.GetKeyUp (BindGrabToggle))
				
				Grab = false ;
			
};
		
//isGrabbed Input code Below for object to call to from objectreplyscript
		
{
			
			if ( Grab == true )
			if ( Rayhit == true )		
					
				isGrabbed = true ;
			
};
		
//
		
{
			
			if (Grab == false )
				
				isGrabbed = false ;
			
};

//Code to log Ray ID to EqualID and set to Targetfloat
		
{
			
			if ( isGrabbed == true )
			
{
				EqualId = ObjectRayId ;
				Targetfloat = GameObject.Find (EqualId);

}

};

//Code to get Object Type class and use.

{

			if ( ObjectHeld == true )

			{

			ObjectType = Targetfloat.GetComponent <ObjectReplyIdAndMove> ().ObjectType ;
			ObjectClass = Targetfloat.GetComponent <ObjectReplyIdAndMove> ().ObjectClass ;
			ObjectUse = Targetfloat.GetComponent <ObjectReplyIdAndMove> ().ObjectUse ;

			}

			else

			{

				ObjectType = null ;
				ObjectClass = null ;
				ObjectUse = null ;


			}

}

//Code to Trigger Object

{
		if ( isGrabbed == true )	
		
{

		if ( Targetfloat != null )//isnot
				
			Targetfloat.GetComponent <ObjectReplyIdAndMove> ().PlayerGrabbed = true ;	

}

};

//Code for Correct Reply Check
		
{
		
			if ( EqualId == ObjectReplyId )
					
				CorrectReply = true ;
				
			else 
				
				if ( Grab == false )
				if ( GrabToggle ==  false )

				CorrectReply = false ;

};

//Code for Correct Constant ID Check
		
{

			if ( ObjectRayId == ObjectReplyId )
					
				CorrectConstantId = true ;
				
			else 
					
				CorrectConstantId = false ;
							
};



//Code to call the Object ID below 
		
{
			
			if ( isGrabbed == true )
													
				ObjectReplyId = Targetfloat.GetComponent < ObjectReplyIdAndMove > ().ObjectID;
		
}
		
//
		
{
			
			if ( GrabToggle == false )
			if ( Grab == false )
				
				ObjectReplyId = null ;
			
};

//Code to know if Object is Held

{

			if ( Targetfloat == null )

				ObjectHeld = false ;

			else 

{
							
			if ( GrabToggle == true )
			
				ObjectHeld = true ;

}

};

//Raycast and Rayhit Code Below
		
{
			if ( Grab == true ) 
			
{

				RaycastOrigin = HeadCam.GetComponent <Camera> ();

				Debug.DrawRay (RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.green, 0.5f);

			if (Physics.Raycast (RaycastOrigin.transform.position, RaycastOrigin.transform.forward, out ObjectHit, Raylength, Layermask)) 
				
{
				
				Rayhit = true;
				
				ObjectRayId = (ObjectHit.collider.name);

				ObjectDistance = (ObjectHit.distance);
				
				Debug.DrawRay (RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.red, 0.5f);


}

			else

{

			if ( GrabToggle == false )
			if ( Grab == false )

				Rayhit = false ;

}

}
};

//

{

			if ( Rayhit == false )

				ObjectDistance = 0.0f ;

}

//Linecast and Rayhit Code Below
		
{
			if ( ObjectHeld == true) 
				
{
				
				LinecastOrigin = HeadCam.transform.position ;
				
				//remember Target must be within collider otherwise pick something else or create an offset vector to add to it.
				
				LinecastTarget = Targetfloat.transform.position ;
				
				
				
				
				
				
				if (Physics.Linecast( LinecastOrigin, LinecastTarget, out ObjectHit , Layermask )) 
					
{
					
					Rayhit = true;
					
					ObjectRayId = (ObjectHit.collider.name);
					
					ObjectDistance = (ObjectHit.distance);
					
					Debug.DrawLine (LinecastOrigin, LinecastTarget , Color.red , 0.5f);
					
					
}
				
				else
					
{

					if ( Grab == false )

{

					Debug.DrawLine ( LinecastOrigin , LinecastTarget , Color.green, 0.5f);	
					
					Rayhit = false ;
					
					ObjectRayId = null ;
					
					ObjectDistance = 0.0f ;
					
}

}
				
}

};
		
//Linecast Distance check code ends above

//Within Range Flash Input Codes below hapens only on raycast at begining to check if iten it close enough to grab
		
{

			if ( ObjectDistance <= MaxGrabDistance )
								
				WithinRange = true ;
			
};
		
//
		
{

			if ( ObjectDistance >= MaxGrabDistance )
				
				WithinRange = false ;
			
};

//
		
{
			
			if ( ObjectDistance <= 0.0f )
				
				WithinRange = false ;
			
};
	
//Code to Check if Object in camera View Below
					
{

			if ( Targetfloat != null )//isnot
			if ( GrabToggle == true ) 
			
{

			if ( ObjectHeld == true ) 
				
{

				ScreenPoint = Camera.current.WorldToViewportPoint (Targetfloat.gameObject.transform.position);			
										
			if (ScreenPoint.z > 0 && ScreenPoint.x > 0 && ScreenPoint.x < 1 && ScreenPoint.y > 0 && ScreenPoint.y < 1)

				inCameraView = true;

			else 
									
				inCameraView = false;

} 

			else 

				ScreenPoint = new Vector3 (0.0f, 0.0f, 0.0f);

}

			else 
				
				ScreenPoint = new Vector3 (0.0f , 0.0f , 0.0f );

};

//GrabToggle On Input code Below

{

			if (GrabToggle == false) 
			if (Grab == true) 
			if (Timer2Done == false) 		
			
				Timer1 += Time.deltaTime;
				
};

//

{

			if ( Timer1 >= TimeToWait )
			if ( Rayhit == true )

{
						
				GrabToggle = true;
						
				Timer1Done = true;
						
}
				
};
		
//GrabToggle Off code Below
		
{	

			if ( Grab == true )		
			if ( GrabToggle == true )
			if ( Timer1Done == false )
						
				Timer2 += Time.deltaTime;

};

//

{

			if ( Timer2 >= TimeToWait ) 
							
{
							
				GrabToggle = false;
							
				Timer2Done = true ;
							
}
							
};

//GrabToggle Reset Timer's Code Below
		
{
			
			if ( Grab == false )
				
{
				
				Timer1Done = false ;
				
				Timer2Done = false ;
				
				Timer1 = 0.0f ;
				
				Timer2 = 0.0f ;
				
}								
			
};

//Main Code to Reset ID's below

{

			if ( GrabToggle == false )
			
{

				if ( Grab == false )
{

				EqualId = null ;
				ObjectRayId = null ;
				ObjectReplyId = null ;
				Targetfloat = null ;
				WithinRange = false ;
				ObjectHeld = false ;
				CorrectReply = false ;
				CorrectConstantId = false ;
				Rayhit = false ;
				inCameraView = false ;
				ObjectDistance = 0.0f ;


}

}

};

// Object Id Checks resets if not correct.

{

			if ( Targetfloat != null )//isnot
			if ( CorrectReply == false )

					GrabToggle = false ;

}

//

{

			if ( CorrectConstantId == false )

					GrabToggle = false ;

}

//CorrectID Check to reset when Another object is in way of object.

{

			if ( Grab == false )
			if ( GrabToggle == true )
			if ( Targetfloat.GetComponent <ObjectReplyIdAndMove> ().CorrectID == false )

				 GrabToggle = false ;

}

//Code to Reset Grabtoggle if leaves CameraView unless its overidden

{

			if ( inCameraViewOveride == false )
			if ( ObjectHeld == true )
			if ( inCameraView == false )

					GrabToggle = false;
						
};

//Code to reset Grabtoggle if it is in view but leaves maxdistance unless its overiden

{

			if ( WithinRangeOveride == false )
			if ( ObjectHeld == true )
			if ( WithinRange == false )

				GrabToggle = false ;

};



//Script Complete .Hare Krsna enjoy.

//Made by Ryan Kappes. 2017.


}
}
