using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement {
    public static List<Achievement> achievments = new List<Achievement>();

	public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Reward { get; set; }

    public Achievement(string description, int reward)
    {
        Description = description;
        Reward = reward;
        IsCompleted = false;
    }


}
