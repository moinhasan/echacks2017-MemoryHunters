using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MapUIController : MonoBehaviour {

	public Transform AchievementsPanel;

	public TextMeshProUGUI task1;
	public TextMeshProUGUI reward1;
	public TextMeshProUGUI status1;
	public TextMeshProUGUI task2;
	public TextMeshProUGUI reward2;
	public TextMeshProUGUI status2;

	public TextMeshProUGUI exp;

	// Use this for initialization
	void Start () {

		exp.text = "Exp: " + ProgramManager.currentUser.CurrentExperience 
			+ "/"+ ProgramManager.currentUser.ExperienceUntillNextLevel + "           Level: "
			+ProgramManager.currentUser.Level;

		AchievementsPanel.gameObject.SetActive (false);
		Achievements.AchievementsList.Add(new Achievement("Find 1 orb",10));
		Achievements.AchievementsList.Add(new Achievement("Find 5 orbs",100));

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void seeAchievements(){

		Achievement a1 = Achievements.AchievementsList [0];
		task1.text = a1.Description;
		reward1.text = "Reward: "+a1.Reward;
		if (a1.IsCompleted) {
			status1.text = "Status: Completed";
			ProgramManager.currentUser.CurrentExperience = 10;
		} else {
			status1.text = "Status: Incompleted";
		}
		Achievement a2 = Achievements.AchievementsList [1];
		task2.text = a2.Description;
		reward2.text = "Reward: "+a2.Reward;
		if (a2.IsCompleted) {
			status2.text = "Status: Completed";
		} else {
			status2.text = "Status: Incompleted";
		}

		exp.text = "Exp: " + ProgramManager.currentUser.CurrentExperience 
			+ "/"+ ProgramManager.currentUser.ExperienceUntillNextLevel + "           Level: "
			+ProgramManager.currentUser.Level;
		AchievementsPanel.gameObject.SetActive (true);

	}

    public void OnUploadPressed()
    {
        SceneManager.LoadScene(2);
    }
    public void OnLogOut()
    {
        SceneManager.LoadScene(0);
    }
}
