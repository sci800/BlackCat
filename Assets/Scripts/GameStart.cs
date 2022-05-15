using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    public GameObject buttonObject;
    public GameObject[] cutScenes;
    public GameObject backScene;
    public float cutSpeed;
    public GameObject StartButton;

    public void CutSceneStart()
    {
        StartCoroutine(StartingCutScene());
        buttonObject.SetActive(false);
    }
    IEnumerator StartingCutScene()
    {
        backScene.SetActive(true);
        for(int i = 0; i < cutScenes.Length; i++)
        {
            cutScenes[i].SetActive(true);
            yield return new WaitForSeconds(cutSpeed);
        }
        StartButton.SetActive(true);
    }

    public void NextScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
