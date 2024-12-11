/************************************************************
■参考
	Github
		https://github.com/SJ-magic-study-unity/study__UnityFixFramerate
		
	UnityでFPSを設定する方法
		http://unityleaning.blog.fc2.com/blog-entry-2.html
************************************************************/
using UnityEngine;
using System.Collections;

/************************************************************
************************************************************/
public class setFrameRate : MonoBehaviour {
	[SerializeField] int app_fps_ = 30;
	[SerializeField] float lpf_ = 0.02f;
	float current_fps_ = 0;
	
	private string label_ = "";
	KeyCode key_disp_ = KeyCode.P;
	bool b_disp_ = false;
	
	void Awake() { 
		QualitySettings.vSyncCount = 0; // 0:Don't Sync, 1:Every V Blank, 2:Every Second V Blank
		Application.targetFrameRate = app_fps_;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key_disp_)) b_disp_ = !b_disp_;
		
		float fps = 1.0f / Time.deltaTime;
		current_fps_ = lpf_ * fps + (1 - lpf_) * current_fps_;
		label_ = string.Format("{0:000.0}", (int)(current_fps_));
	}
	
	/****************************************
	****************************************/
	void OnGUI()
	{
		/********************
		********************/
		if(b_disp_){
			GUI.skin.label.fontSize = 20;
			GUI.color = Color.white;
			
			GUI.Label(new Rect(15, 100, 500, 40), label_);
		}
	}
}
