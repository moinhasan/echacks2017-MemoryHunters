using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UploadMemory : MonoBehaviour {

	public TMP_InputField input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Upload () {
		string s = input.text;
        MemoryProperties newMemory = new MemoryProperties(ProgramManager.currentUser, s);
        ProgramManager.memories.Add(newMemory);
        input.text = "";
        //Temp load the AR scene
        SceneManager.LoadScene(2);
	}
}
