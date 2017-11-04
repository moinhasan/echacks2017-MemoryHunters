using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {
    
    public string Name { get; set; }
    public int CurrentExperience { get; set; }
    public int ExperienceUntillNextLevel { get; set; }
    public int Level { get; set; }

    public User(string name)
    {
        Name = name;
        CurrentExperience = 0;
        ExperienceUntillNextLevel = 100;
        Level = 0;
    }

    public void LevelUp()
    {
        Level++;
        CurrentExperience = 0;
        ExperienceUntillNextLevel = 100 * Level * 2;
    }

}
