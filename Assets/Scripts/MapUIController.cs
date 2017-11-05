using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MapUIController : MonoBehaviour {

    float secondsRemaining = 86400;

	public Transform AchievementsPanel;
    public Button MemoryNearbyButton;
    bool pressed = false;

	public TextMeshProUGUI task1;
	public TextMeshProUGUI reward1;
	public TextMeshProUGUI status1;
	public TextMeshProUGUI task2;
	public TextMeshProUGUI reward2;
	public TextMeshProUGUI status2;

	public TextMeshProUGUI exp;
    public TextMeshProUGUI timeText;

    public Transform specialOrb;

    // Use this for initialization
    void Start()
    {

        exp.text = "Exp: " + ProgramManager.currentUser.CurrentExperience
            + "/" + ProgramManager.currentUser.ExperienceUntillNextLevel + "           Level: "
            + ProgramManager.currentUser.Level;

        AchievementsPanel.gameObject.SetActive(false);
        Achievements.AchievementsList.Add(new Achievement("Find 1 orb", 10));
        Achievements.AchievementsList.Add(new Achievement("Find 5 orbs", 100));
    }
	
	// Update is called once per frame
	void Update () {
        if(ProgramManager.memories.Count > 0 && !ProgramManager.pressed)
        {
            specialOrb.gameObject.SetActive(true);
        }

		if(!ProgramManager.pressed && ProgramManager.memories.Count > 0 && ProgramManager.memories[0].User != ProgramManager.currentUser)
        {
            //display button
            MemoryNearbyButton.gameObject.SetActive(true);
        }
        else
        {
            MemoryNearbyButton.gameObject.SetActive(false);
        }
        secondsRemaining -= Time.deltaTime;
        timeText.text = changeTime(secondsRemaining);
	}

	public void seeAchievements(){

		Achievement a1 = Achievements.AchievementsList [0];
		task1.text = a1.Description;
		reward1.text = "Reward: "+a1.Reward;
		if (a1.IsCompleted) {
			status1.text = "Status: Completed";
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

    public string changeTime(float remainingSec)
    {
        
        //int remainingSec = secPerDay - sec;
        float hour, min, second;
        hour = remainingSec / 3600;
        remainingSec = remainingSec % 3600;
        min = remainingSec / 60;
        remainingSec = remainingSec % 60;
        second = remainingSec;
        return (int)hour + "h " + (int)min + "m " + (int)second + "s ";
    }

    public void OnUploadPressed()
    {
        SceneManager.LoadScene(2);
    }
    public void OnLogOut()
    {
        SceneManager.LoadScene(0);
    }
    public void OnMemmoryNearbyClicked()
    {
        ViewMemory.memoryToView = ProgramManager.memories[0];
        ProgramManager.pressed = true;
        specialOrb.gameObject.SetActive(false);
        MemoryNearbyButton.gameObject.SetActive(false);
        SceneManager.LoadScene(3);
    }
}
