using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExtendedTextManager : MonoBehaviour
{
	private UITextInstance text1;
	private UITextInstance text2;


	void Start()
	{
		// setup our text instance which will parse our .fnt file and allow us to
		var text = new UIText( "prototype", "prototype.png" );
		text.alignMode = UITextAlignMode.Center;
		
		
		// add a text instance that we will animate later
		text1 = text.addTextInstance( "hello man.  I have a line\nbreak.", Screen.width / 2, 0 );

		StartCoroutine( modifyTextInstances() );
	}
	

	IEnumerator modifyTextInstances()
	{
		while( true )
		{
			yield return new WaitForSeconds( 0.5f );
			
			var x = Screen.width / 2;
			var y = -Screen.height / 2;
			text1.positionTo( 2.0f, new Vector3( x, y, 0 ), Easing.Quartic.easeIn );
			
			yield return new WaitForSeconds( 2.5f );
			
			text1.positionTo( 1.0f, new Vector3( x, 0, 0 ), Easing.Quintic.easeIn );
			
			yield return new WaitForSeconds( 1.5f );
		}
	}

}
