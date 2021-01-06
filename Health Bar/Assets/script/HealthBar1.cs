using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float viewBlood = 10f;
    private float targetBlood = 10f;
    private Rect bloodBar;
    private Rect addButton;
    private Rect minusButton;
 
    void Start () {
        bloodBar = new Rect(Screen.width - 250, 20, 200, 50);
        addButton = new Rect(Screen.width - 250, 50, 40, 20);
        minusButton = new Rect(Screen.width - 90, 50, 40, 20);
	}

    public void addBlood() {
        targetBlood = targetBlood + 3 > 10f? 10f : targetBlood + 3;
    }
 
    public void minusBlood() {
        targetBlood = targetBlood - 3 < 0f? 0f : targetBlood - 3;
    }
 
    private void OnGUI() {
        if (GUI.Button(addButton, " + "))  addBlood();
        if (GUI.Button(minusButton, " - ")) minusBlood();
        viewBlood = Mathf.Lerp(viewBlood, targetBlood, 0.1f);
        //viewBlood  = targetBlood;
        GUI.HorizontalScrollbar(bloodBar, 0f, viewBlood, 0f, 10f);
    }
}
