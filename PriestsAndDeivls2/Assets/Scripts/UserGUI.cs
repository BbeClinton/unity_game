using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

	private IUserAction action;
	public string gameMessage;

	void Start () {
		action = SSDirector.getInstance ().currentSceneController as IUserAction;
	}

	void OnGUI() {  
		float width = Screen.width / 6;  
		float height = Screen.height / 12;

		action.Check();
		GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 50;
		GUI.Label(new Rect(325,120,50,200),gameMessage,style);

		if (GUI.Button(new Rect(0, 0, width, height), "Restart")) {  
			action.Restart();  
		} 

		string paused_title = SSDirector.getInstance ().Paused ? "Resume" : "Pause!"; 
		if (GUI.Button(new Rect(width, 0, width, height), paused_title)) { 
			SSDirector.getInstance ().Paused = !SSDirector.getInstance ().Paused;
		} 
	}


}
