using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryProperties  {

    public User User { get; set; }
    public string Message { get; set; }
    public List<Comment> Comments { get; set; }
    public int NumberOfLikes { get; protected set; }


    public MemoryProperties(User user, string message)
    {
        User = user;
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
