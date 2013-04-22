using UnityEngine;
using System.Collections;
using System;

// Simple extension to UIButton, which uses the native font to render text on top of button
public class TextButton : UIButton {
	
	TextButtonComponent textButtonComponent;
	
	public static TextButton create(UIToolkit manager, string filename, string highlightedFilename, int xPos, int yPos, int depth){
		if (manager == null){
			manager = UIToolkit.instance;
		}
		
		// grab the texture details for the normal state
		var normalTI = manager.textureInfoForFilename( filename );
		var frame = new Rect( xPos, yPos, normalTI.frame.width, normalTI.frame.height );
		
		// get the highlighted state
		var highlightedTI = manager.textureInfoForFilename( highlightedFilename );
			
		return new TextButton( manager, frame, depth, normalTI.uvRect, highlightedTI.uvRect );
	}
	
	public TextButton( UIToolkit manager, Rect frame, int depth, UIUVRect uvFrame, UIUVRect highlightedUVframe):base(manager, frame, depth, uvFrame, highlightedUVframe){
		textButtonComponent = client.AddComponent<TextButtonComponent>();
		textButtonComponent.textButton = this;
	}
	
	string text;
	public string Text{
		get {
			return text;		
		}
		set {
			text = value;
		}
	}
	
	public GUIStyle GuiStyle;
}
