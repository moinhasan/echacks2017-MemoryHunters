using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

    public string Uploader { get; set; }
    public string Message { get; set; }
    public List<Comment> Comments { get; set; }
    public int NumberOfLikes { get; protected set; }

    public void IncrementLike()
    {
        NumberOfLikes++;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    
}
