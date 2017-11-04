using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewMemory : MonoBehaviour {

    public static MemoryProperties memoryToView;

	public TextMeshProUGUI message;
	public TextMeshProUGUI user;
	public int index = 0;
	public Transform commentPanel;
	public TMP_InputField commentInput;
	public Button submitCommentButton;
	public TextMeshProUGUI commentsScrollViewText;
	public TextMeshProUGUI likesDisplay;

	public string commentsForPost;


	// Use this for initialization
	void Start () {
        //ProgramManager.memories.Add (new MemoryProperties ("Person", "Message"));
        //MemoryProperties selectedMemory = ProgramManager.memories[index];
        message.text =  memoryToView.Message;
		user.text = memoryToView.User.Name + " " + memoryToView.User.Level;
		commentPanel.gameObject.SetActive(false);
		foreach( Comment c in ProgramManager.memories[index].Comments ){
			updateComment (c);
		}
		commentsScrollViewText.text = commentsForPost;
		likesDisplay.text = "Likes: " + memoryToView.NumberOfLikes;
	}

	void Update(){
		string str = commentInput.text;
		str = str.Replace(" ", string.Empty);
		if (str.Length == 0) {
			submitCommentButton.enabled = false;
		} else {
			submitCommentButton.enabled = true;
		}

	}

	public void like(){
        ProgramManager.memories [index].IncrementLike();
		likesDisplay.text = "Likes: " + ProgramManager.memories [index].NumberOfLikes;
	}

	public void startComment(){
		commentPanel.gameObject.SetActive (true);
	}

	public void cancelComment(){
		commentPanel.gameObject.SetActive (false);
	}

	public void submitComment(){
		Comment c = new Comment(ProgramManager.currentUser.Name,commentInput.text);
		updateComment (c);
        memoryToView.Comments.Add(c);
		commentPanel.gameObject.SetActive (false);
	}

	public void updateComment(Comment c){
		commentsForPost+=(c.Uploader+": "+c.Message+"\n");
		commentsScrollViewText.text = commentsForPost;
	}
}
