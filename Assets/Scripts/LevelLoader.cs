using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public static LevelLoader instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
