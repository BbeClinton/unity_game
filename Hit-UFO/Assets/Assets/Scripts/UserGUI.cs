using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

	private IUserAction action;
	public string gameMessage;
	public int score;

	void Start () {
		action = SSDirector.getInstance ().currentSceneController as IUserAction;
		score=0;
	}

	void OnGUI() {  
		float width = Screen.width / 8;  
		float height = Screen.height / 13;

		//action.Check();
		GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 30;
		GUIStyle style2 = new GUIStyle();
		style2.normal.textColor = Color.red;
		style2.fontSize = 50;
		GUI.Label(new Rect(340,200,50,200),gameMessage,style2);
		GUI.Label(new Rect(width*5, 0, width, height),"Your Score: ",style);
		GUI.Label(new Rect(width*7, 0, width, height),score.ToString(),style);
		if (GUI.Button(new Rect(0, 0, width, height), "Restart")) {  
			action.Restart();  
		} 

		string paused_title = SSDirector.getInstance ().Paused ? "Resume" : "Pause"; 
		if (GUI.Button(new Rect(width, 0, width, height), paused_title)) { 
			SSDirector.getInstance ().Paused = !SSDirector.getInstance ().Paused;
		} 
	}


}
