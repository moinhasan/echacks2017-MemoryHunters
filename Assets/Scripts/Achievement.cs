using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievment {
    public static List<Achievment> achievments = new List<Achievment>();

	public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int Reward { get; set; }

    public Achievment(string description, int reward)
    {
        Description = description;
        Reward = reward;
        IsCompleted = false;
    }


}
