using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        //animacion play()

        while (!operation.isDone)// || !X)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //Debug.Log(progress);
            
            /*
            if (cuando termine la animacion)
                X = true;    
            */
            yield return null;
        }
    }
}
