using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string LevelName;

	void Start ()
    {
        LevelName = PlayerPrefs.GetString("current_level");
        FindObjectOfType<LevelGenerator>().GenerateLevel(LevelName);
        StartCoroutine(LevelEndCoroutine());
	}

    IEnumerator LevelEndCoroutine()
    {
        while(true)
        {
            if (CheckIfLevelEnd())
                ChangeScene();

            yield return new WaitForSeconds(1f);
        }
    }

    bool CheckIfLevelEnd()
    {
        return FindObjectsOfType<Block>().Length == 0;
    }

    void ChangeScene()
    {
        PlayerPrefs.SetInt(LevelName + "_finished", 1);
        SceneManager.LoadScene("menu");
    }
}
