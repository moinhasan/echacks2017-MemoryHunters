using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewMemory : MonoBehaviour {

    public static MemoryProperties memoryToView;

    public Image heart;

	public TextMeshProUGUI message;
	public TextMeshProUGUI user;
	public int index = 0;
	public Transform commentPanel;
	public TMP_InputField commentInput;
	public Button submitCommentButton;
	public TextMeshProUGUI commentsScrollViewText;
	public TextMeshProUGUI likesDisplay;

	public Transform popup;

	public string commentsForPost;


	// Use this for initialization
	void Start () {
        //ProgramManager.memories.Add (new MemoryProperties ("Person", "Message"));
        //MemoryProperties selectedMemory = ProgramManager.memories[index];

		//set all the data for the achievement
		if (Achievements.AchievementsList [0].IsCompleted == false) {
			popup.gameObject.SetActive (true);
			Achievements.AchievementsList [0].IsCompleted = true;
		}

        message.text =  memoryToView.Message;
		user.text = memoryToView.User.Name + " " + memoryToView.User.Level;
		commentPanel.gameObject.SetActive(false);
		foreach( Comment c in memoryToView.Comments ){
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
        if(heart.color != Color.red)
        {
            memoryToView.IncrementLike();
            heart.color = Color.red;
            likesDisplay.text = "Likes: " + memoryToView.NumberOfLikes;
        }


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
        commentInput.text = "";
		commentPanel.gameObject.SetActive (false);
	}

	public void updateComment(Comment c){
		commentsForPost+=(c.Uploader+": "+c.Message+"\n");
		commentsScrollViewText.text = commentsForPost;
	}

	public void exitPopup(){
		popup.gameObject.SetActive (false);
	}
}
