using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int currentLevel = 1;

    private Enemy[] enemies;
    
    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy tmp in enemies)
        {
            if(tmp) return;
        }

        Debug.Log("This level is complete! All monsters were slaughtered, move on.");

        // now that the level is done lets increment its index so we can load the next level 
        // scene 
        currentLevel++;

        SceneManager.LoadScene("Level" + currentLevel);
    }
}
