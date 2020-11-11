using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction {

	private bool isRuning;

	public UFOFactory ufoFactory;
	private int[] roundUFOs;
	private int score;
	private int round;
	private float sendTime;
	private bool model;
	int sendCnt;
	private IActionManager actionManager;
	// the first scripts
	void Awake () {
		SSDirector director = SSDirector.getInstance ();
		director.currentSceneController = this;
		director.currentSceneController.LoadResources ();
		this.gameObject.AddComponent<UserGUI>();
        this.gameObject.AddComponent<CCActionManager>();
		this.gameObject.AddComponent<PhysisActionManager>();
		ufoFactory=UFOFactory.getInstance();
		roundUFOs=new int[]{3,5,9,11,15};
		score=round=sendCnt=0;
		sendTime=0;
		sendCnt =0;
		model = true;
		actionManager=this.gameObject.GetComponent<CCActionManager>();
	}
	 
	// loading resources for the first scence
	public void LoadResources () {
		isRuning=true;
	}

	public void SendUFO(){
        GameObject ufo=ufoFactory.GetUFO(round);
        ufo.transform.position=new Vector3(-ufo.GetComponent<UFOData>().direction.x * 7, UnityEngine.Random.Range(0f, 8f), 0);
        ufo.SetActive(true);
        actionManager.Fly(ufo,ufo.GetComponent<UFOData>().speed,ufo.GetComponent<UFOData>().direction);
    }

	public bool GetIsRuning(){
		return isRuning;
	}

	public void JudgeCallback(bool isRuning,int score){
		this.score+=score;
        this.gameObject.GetComponent<UserGUI>().score=this.score;
        this.isRuning=isRuning;
    }
	public void ChangeMode(){
		model=!model;
		if(model){
			actionManager=this.gameObject.GetComponent<CCActionManager>();
		}
		else{
			actionManager=this.gameObject.GetComponent<PhysisActionManager>();
		}
	}
	public void Pause ()
	{
		throw new System.NotImplementedException ();
	}

	public void Resume ()
	{
		throw new System.NotImplementedException ();
	}

	#region IUserAction implementation
	public void Restart ()
	{
		isRuning=true;
		this.gameObject.GetComponent<UserGUI>().gameMessage="";
		this.gameObject.GetComponent<UserGUI>().score=0;
		score=round=sendCnt=0;
		sendTime=0;
		ufoFactory.FreeALL();
	}
	#endregion


	void Start () {

	}
	
	void Update () {

		
			sendTime+=Time.deltaTime;
			if(sendTime>2){
				sendTime=0;
				
				for(int i = 0; i < 5 && sendCnt < roundUFOs[round]; i++){
				  	sendCnt++;	
					SendUFO();
				}
				if(sendCnt == roundUFOs[round]&&round==roundUFOs.Length-1){
					isRuning=false;
					gameObject.GetComponent<UserGUI>().gameMessage = "Time Out!";
				}
				if(sendCnt == roundUFOs[round] && round < roundUFOs.Length - 1){
					sendCnt = 0;
                	round++;
				}
				
			
			}
			
	}

}
