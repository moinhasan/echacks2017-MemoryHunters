using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocateMemoryUIController : MonoBehaviour {

    MemoryObject obj;
    public Button viewButton;

    private void Start()
    {
        obj = GameObject.FindObjectOfType<MemoryObject>();
    }

    private void Update()
    {
        viewButton.interactable = obj.isFocused;
       
    }

    public void OnViewMemory()
    {
        print("viewing memory");
        ViewMemory.memoryToView = GoogleARCore.HelloAR.HelloARController.memObj.Properties;
        SceneManager.LoadScene(3);
    }
    
}
