using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {
    
    public string Name { get; set; }
    public int CurrentExperience { get; set; }
    public int ExperienceUntillNextLevel { get; set; }
    public int Level { get; set; }
	public string Password { get; set; }

	public User(string name, string password)
    {
        Name = name;
        CurrentExperience = 0;
        ExperienceUntillNextLevel = 100;
        Level = 0;
		Password = password;
    }

    public void LevelUp()
    {
        Level++;
        CurrentExperience = 0;
        ExperienceUntillNextLevel = 100 * Level * 2;
    }

}
