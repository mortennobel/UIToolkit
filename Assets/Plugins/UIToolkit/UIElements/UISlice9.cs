/// <summary>
/// Touchable Slice-9 Implementation for UIToolkit
/// Created by David O'Donoghue (ODD Games)
/// </summary>
using UnityEngine;
using System;

public class UISlice9 : UISprite
{
	UISprite[] spriteSlices = new UISprite[9];

	// override hidden so we can set the touch frame to dirty when being shown
	public override bool hidden
    {
        get { return ___hidden; }
        set
        {
            base.hidden = value;

			foreach( UISprite sprite in spriteSlices )
				sprite.hidden = value;
        }
    }

	
	#region Constructors/Destructor

	/// <summary>
	/// Create a Slice-9 touchable sprite
	/// </summary>
	/// <param name='filename'>
	/// Filename
	/// </param>
	/// <param name='xPos'>
	/// X position
	/// </param>
	/// <param name='yPos'>
	/// Y position
	/// </param>
	/// <param name='width'>
	/// Width
	/// </param>
	/// <param name='height'>
	/// Height
	/// </param>
	/// <param name='sTP'>
	/// Top Margin
	/// </param>
	/// <param name='sRT'>
	/// Right Margin
	/// </param>
	/// <param name='sBT'>
	/// Bottom Margin
	/// </param>
	/// <param name='sLT'>
	/// Left Margin
	/// </param>
	public static UISlice9 create( string filename, int xPos, int yPos, int width, int height, int sTP, int sRT, int sBT, int sLT )
	{
		return UISlice9.create( UI.firstToolkit, filename, xPos, yPos, width, height, sTP, sRT, sBT, sLT );
	}
	
	/// <summary>
	/// Create a Slice-9 touchable sprite
	/// </summary>
	/// <param name='manager'>
	/// Manager.
	/// </param>
	/// <param name='filename'>
	/// Filename.
	/// </param>
	/// <param name='xPos'>
	/// X position.
	/// </param>
	/// <param name='yPos'>
	/// Y position.
	/// </param>
	/// <param name='width'>
	/// Width.
	/// </param>
	/// <param name='height'>
	/// Height.
	/// </param>
	/// <param name='sTP'>
	/// Top Margin
	/// </param>
	/// <param name='sRT'>
	/// Right Margin
	/// </param>
	/// <param name='sBT'>
	/// Bottom Margin
	/// </param>
	/// <param name='sLT'>
	/// Left Margin
	/// </param>
	public static UISlice9 create( UIToolkit manager, string filename, int xPos, int yPos, int width, int height, int sTP, int sRT, int sBT, int sLT )
	{
		return UISlice9.create( manager, filename, xPos, yPos, width, height, sTP, sRT, sBT, sLT, 1 );
	}
	
	/// <summary>
	/// Create a Slice-9 touchable sprite
	/// </summary>
	/// <param name='manager'>
	/// Manager.
	/// </param>
	/// <param name='filename'>
	/// Filename.
	/// </param>
	/// <param name='xPos'>
	/// X position.
	/// </param>
	/// <param name='yPos'>
	/// Y position.
	/// </param>
	/// <param name='width'>
	/// Width.
	/// </param>
	/// <param name='height'>
	/// Height.
	/// </param>
	/// <param name='sTP'>
	/// Top Margin
	/// </param>
	/// <param name='sRT'>
	/// Right Margin
	/// </param>
	/// <param name='sBT'>
	/// Bottom Margin
	/// </param>
	/// <param name='sLT'>
	/// Left Margin
	/// </param>
	public static UISlice9 create( UIToolkit manager, string filename, int xPos, int yPos, int width, int height, int sTP, int sRT, int sBT, int sLT, int depth )
	{
		// grab the texture details for the normal state
		var normalTI = manager.textureInfoForFilename( filename );
		var frame = new Rect( xPos, yPos, normalTI.frame.width, normalTI.frame.height );
		
		// create the button
		return new UISlice9( manager, frame, depth, normalTI.uvRect, width, height, sTP, sRT, sBT, sLT );
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="UISlice9"/> class.
	/// </summary>
	/// <param name='manager'>
	/// Manager.
	/// </param>
	/// <param name='frame'>
	/// Frame.
	/// </param>
	/// <param name='depth'>
	/// Depth.
	/// </param>
	/// <param name='uvFrame'>
	/// Uv frame.
	/// </param>
	/// <param name='width'>
	/// Final width
	/// </param>
	/// <param name='height'>
	/// Final height
	/// </param>
	/// <param name='sTP'>
	/// Top Margin
	/// </param>
	/// <param name='sRT'>
	/// Right Margin
	/// </param>
	/// <param name='sBT'>
	/// Bottom Margin
	/// </param>
	/// <param name='sLT'>
	/// Left Margin
	/// </param>
	public UISlice9( UIToolkit manager, Rect frame, int depth, UIUVRect uvFrame, int width, int height, int sTP, int sRT, int sBT, int sLT ):base( frame, depth, uvFrame )
	{
		int stretchedWidth = width - ( sLT + sRT );
		int stretchedHeight = height - ( sTP + sBT );
		this.manager = manager;
		manager.addSprite( this );
		
		// Top Left
		spriteSlices[0] = new UISprite( new Rect( frame.x, frame.y, sLT, sTP ), depth, new UIUVRect( uvFrame.frame.x, uvFrame.frame.y, sLT, sTP, manager.textureSize ) );
		manager.addSprite( spriteSlices[0] );
		spriteSlices[0].parentUIObject = this;
		
		// Top Middle
		spriteSlices[1] = new UISprite( new Rect( frame.x + sLT, frame.y, stretchedWidth, sTP ), depth, new UIUVRect( uvFrame.frame.x + sLT, uvFrame.frame.y, uvFrame.frame.width - ( sRT + sLT ), sTP, manager.textureSize ) );
		manager.addSprite( spriteSlices[1] );
		spriteSlices[1].parentUIObject = this;
		
		// Top Right
		spriteSlices[2] = new UISprite( new Rect( frame.x + sLT + stretchedWidth, frame.y, sRT, sTP ), depth, new UIUVRect( uvFrame.frame.x + sLT + ( uvFrame.frame.width - ( sRT + sLT ) ), uvFrame.frame.y, sRT, sTP, manager.textureSize ) );
		manager.addSprite( spriteSlices[2] );
		spriteSlices[2].parentUIObject = this;
		
		// Middle Left
		spriteSlices[3] = new UISprite( new Rect( frame.x, frame.y + sTP, sLT, stretchedHeight ), depth, new UIUVRect( uvFrame.frame.x, uvFrame.frame.y + sTP, sLT, uvFrame.frame.height - ( sTP + sBT ), manager.textureSize ) );
		manager.addSprite( spriteSlices[3] );		
		spriteSlices[3].parentUIObject = this;
		
		// Middle Middle
		spriteSlices[4] = new UISprite( new Rect( frame.x + sLT, frame.y + sTP, stretchedWidth, stretchedHeight ), depth, new UIUVRect( uvFrame.frame.x + sLT, uvFrame.frame.y + sTP, uvFrame.frame.width - ( sLT + sRT ), uvFrame.frame.height - ( sBT + sTP ), manager.textureSize ) );
		manager.addSprite( spriteSlices[4] );		
		spriteSlices[4].parentUIObject = this;
		
		// Middle Right
		spriteSlices[5] = new UISprite( new Rect( frame.x + sLT + stretchedWidth, frame.y + sTP, sRT, stretchedHeight ), depth, new UIUVRect( uvFrame.frame.x + ( uvFrame.frame.width - sRT ), uvFrame.frame.y + sTP, sRT, uvFrame.frame.height - ( sBT + sTP ), manager.textureSize ) );
		manager.addSprite( spriteSlices[5] );		
		spriteSlices[5].parentUIObject = this;
		
		// Bottom Left
		spriteSlices[6] = new UISprite( new Rect( frame.x, frame.y + sTP + stretchedHeight, sLT, sBT ), depth, new UIUVRect( uvFrame.frame.x, uvFrame.frame.y + ( uvFrame.frame.height - sBT ), sLT, sBT, manager.textureSize ) );
		manager.addSprite( spriteSlices[6] );		
		spriteSlices[6].parentUIObject = this;
		
		// Bottom Middle
		spriteSlices[7] = new UISprite( new Rect( frame.x + sLT, frame.y + sTP + stretchedHeight, stretchedWidth, sBT ), depth, new UIUVRect( uvFrame.frame.x + sLT, uvFrame.frame.y + ( uvFrame.frame.height - sBT ), uvFrame.frame.width - ( sLT + sRT ), sBT, manager.textureSize ) );
		manager.addSprite( spriteSlices[7] );
		spriteSlices[7].parentUIObject = this;
		
		
		// Bottom Right
		spriteSlices[8] = new UISprite( new Rect( frame.x + sLT + stretchedWidth, frame.y + sTP + stretchedHeight, sRT, sBT ), depth, new UIUVRect( uvFrame.frame.x + sLT + ( uvFrame.frame.width - ( sRT + sLT ) ), uvFrame.frame.y + ( uvFrame.frame.height - sBT ), sRT, sBT, manager.textureSize ) );
		manager.addSprite( spriteSlices[8] );
		spriteSlices[8].parentUIObject = this;
		
		this.setSize( width, height );
	}

	#endregion;

	public override void destroy()
	{
		
		foreach( UISprite sprite in spriteSlices )
		{
			sprite.destroy();
		}
		
		base.destroy();
	}
}