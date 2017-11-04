using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        MemoryProperties newMemory = new MemoryProperties("person's name", s);
        ProgramManager.memories.Add(newMemory);
        input.text = "";
        print(ProgramManager.memories[0].Message);
	}
}
