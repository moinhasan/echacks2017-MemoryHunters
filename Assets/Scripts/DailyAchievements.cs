using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DailyAchievements : MonoBehaviour {

	public Transform AchievementsPanel;

	public TextMeshProUGUI timeLeft;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void back(){
		AchievementsPanel.gameObject.SetActive (false);
	}
}
