using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private int previousIndex = 0;
    private int currentIndex = 0;

	public void LoadSceneByIndex(int sceneIndex)
    {
        if(sceneIndex == 3)
        {
            //Start button pressed
            GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().StopMusic();
        }
        SceneManager.LoadScene(sceneIndex);
        previousIndex = currentIndex;
        currentIndex = sceneIndex;
    }
    public void Back()
    {
        SceneManager.LoadScene(previousIndex);
        currentIndex = previousIndex;
        previousIndex = 0;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
