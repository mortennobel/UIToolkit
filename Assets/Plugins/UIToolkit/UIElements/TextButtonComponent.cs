using UnityEngine;
using System.Collections;

// Should only be used indirectly through TextButton
public class TextButtonComponent : MonoBehaviour {
	public TextButton textButton;
	
	void OnGUI(){
		if (textButton.GuiStyle == null){
			textButton.GuiStyle = new GUIStyle(GUI.skin.label);
			textButton.GuiStyle.alignment = TextAnchor.MiddleCenter;
		}
		Vector3 pos = textButton.position;
		Rect rect = new Rect(pos.x, -pos.y, textButton.width, textButton.height);
		GUI.Label(rect, textButton.Text, textButton.GuiStyle);
	}
}
