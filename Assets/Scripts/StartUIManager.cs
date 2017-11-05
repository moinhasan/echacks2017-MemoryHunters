using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour {

	public Transform signUpPanel;
	public Transform logInPanel;

	public TMP_InputField signUpUsername;
	public TMP_InputField signUpPassword;
	public TMP_InputField logInUsername;
	public TMP_InputField logInPassword;
	public TextMeshProUGUI signUpErrorField;
	public TextMeshProUGUI logInErrorField;

	public Transform passwordFIeld;

	void Start(){
		logInPanel.gameObject.SetActive (false);
		signUpPanel.gameObject.SetActive (true);
	}

	public void showSignUp(){
		print ("signup");
		logInPanel.gameObject.SetActive (false);
		signUpPanel.gameObject.SetActive (true);
	}

	public void showLogIn(){
		logInPanel.gameObject.SetActive (true);
		signUpPanel.gameObject.SetActive (false);
	}

    public void signUp()
    {
		string username = signUpUsername.text;
		string password = signUpPassword.text;

		if (username == "" || password == "") {
			signUpErrorField.text = "Please enter all information.";
		} else {
			User u = new User (username, password);
			UserList.users.Add (u);
			UserList.curUser = u;
            ProgramManager.currentUser = UserList.curUser;
			//switch scenes
			SceneManager.LoadScene (1);
		}
    }
	public void logIn()
	{
		string username = logInUsername.text;
		string password = logInPassword.text;

		if (username == "" || password == "") {
			logInErrorField.text = "Please enter all information.";
		} else {

			string error = "The entered username does not exist.";

			foreach (User u in UserList.users) {
				if (u.Name == username) {
					if (u.Password == password) {
						error = "nil";
					} else {
						error = "You have entered the wrong password";
					}
				}
			}

			if (error != "nil") {
				logInErrorField.text = error;
			} else {
				User u = new User (username, password);
				UserList.curUser = u;
                ProgramManager.currentUser = UserList.curUser;
				//switch scenes
				SceneManager.LoadScene(1);
			}
		}
	}
}
