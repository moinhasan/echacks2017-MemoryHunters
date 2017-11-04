using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryProperties  {

    public string Uploader { get; set; }
    public string Message { get; set; }
    public List<Comment> Comments { get; set; }
    public int NumberOfLikes { get; protected set; }


    public MemoryProperties(string uploader, string message)
    {
        Uploader = uploader;
        Message = message;
        Comments = new List<Comment>();

    }

    public void IncrementLike()
    {
        NumberOfLikes++;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    
}
