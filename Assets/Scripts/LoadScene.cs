using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    private int previousIndex = 0;
    private int currentIndex = 0;
    public CharacterControllerMovement character;

    public void LoadSceneByIndex(int sceneIndex)
    {
        if(sceneIndex == 3)
        {
            //Start button pressed
            GameObject music = GameObject.FindGameObjectWithTag("MenuMusic");
            if(music)
            {
                music.GetComponent<MenuMusic>().StopMusic();
            }
            if(GameData.charRotation != null)
            {
                character = FindObjectOfType<CharacterControllerMovement>();
                if(character)
                {
                    character.transform.position = GameData.charPosition;
                    character.transform.rotation = GameData.charRotation;
                }
            }
            //GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MenuMusic>().StopMusic();
        }
        else if(sceneIndex == 4)
        {
            SceneManager.LoadScene(sceneIndex);
            previousIndex = currentIndex;
            currentIndex = sceneIndex;
            GameData.charPosition = character.transform.position;
            GameData.charRotation = character.transform.rotation;
            return;
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
