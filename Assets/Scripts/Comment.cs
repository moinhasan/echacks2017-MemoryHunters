using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comment  {
    public string Uploader { get; private set; }
    public string Message { get; private set; }

    public Comment(string uploader, string message)
    {
        Uploader = uploader;
        Message = message;
    }
    
}
