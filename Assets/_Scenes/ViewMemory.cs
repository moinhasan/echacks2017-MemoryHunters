using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewMemory : MonoBehaviour {

	public TextMeshProUGUI message;
	public TextMeshProUGUI user;
	public int index = 0;
	public Transform commentPanel;
	public TMP_InputField commentInput;
	public Transform mainPanel;
	public Button submitCommentButton;
	public TextMeshProUGUI commentsScrollViewText;
	public TextMeshProUGUI likesDisplay;

	public string commentsForPost;


	// Use this for initialization
	void Start () {
		ProgramManager.memories.Add (new MemoryProperties ("Person", "Message"));
        message.text =  ProgramManager.memories[index].Message;
		user.text = ProgramManager.memories [index].Uploader;
		commentPanel.gameObject.SetActive(false);
		foreach( Comment c in ProgramManager.memories[index].Comments ){
			updateComment (c);
		}
		commentsScrollViewText.text = commentsForPost;
		likesDisplay.text = "Likes: " + ProgramManager.memories [index].NumberOfLikes;
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
		Comment c = new Comment("commenter",commentInput.text);
		updateComment (c);
        ProgramManager.memories [index].Comments.Add(c);
		commentInput.text = "";
		commentPanel.gameObject.SetActive (false);
	}

	public void updateComment(Comment c){
		commentsForPost+=(c.Uploader+": "+c.Message+"\n");
		commentsScrollViewText.text = commentsForPost;
	}
}
