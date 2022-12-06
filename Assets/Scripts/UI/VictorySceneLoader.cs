using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictorySceneLoader : MonoBehaviour
{
    Scene scene;
    [SerializeField] int nextLevel;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        //scene = SceneManager.GetSceneByBuildIndex(n);
        GameObject.FindGameObjectWithTag("Joystick").SetActive(false);
        GameObject.FindGameObjectWithTag("Pausa").SetActive(false);
    }
    public void SceneLoader()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SameLevel()
    {
        SceneManager.LoadScene(scene.name);
        //SceneManager.LoadScene(n);

    }

    public void NextLevel()
    {
        // SceneManager.LoadScene()
        SceneManager.LoadScene(nextLevel);
    }
}
