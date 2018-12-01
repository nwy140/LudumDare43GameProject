using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    public Animator animator;
    private int LevelToLoad;
    
    
    // Use this for initialization
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }

    
    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetBool("TimerRight", true);
    }
		
	    public void FadeLevelComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
