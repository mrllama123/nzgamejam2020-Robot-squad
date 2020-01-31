using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public enum Levels 
    {
        level1,
        level2,
        level3,
        level4
    }

    public Levels nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        goToNextLevel();
    }

    void goToNextLevel() 
    {
        if (nextLevel.Equals(Levels.level1))
        {
            Debug.Log("sceneName to load:  level 1");
            SceneManager.LoadScene("Level 1");
        }
        else if (nextLevel.Equals(Levels.level2)) 
        {
            Debug.Log("sceneName to load:  level 2");
            SceneManager.LoadScene("Level 2");
        }
        else if (nextLevel.Equals(Levels.level3))
        {
            Debug.Log("sceneName to load:  level 3");
            SceneManager.LoadScene("Level 3");
        }
        else if (nextLevel.Equals(Levels.level4))
        {
            Debug.Log("sceneName to load:  level 4");
            SceneManager.LoadScene("Level 4");
        }
    }
}
