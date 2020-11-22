using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour
{
    [SerializeField]
    string LevelName = "menu";

	void Update ()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        if (string.IsNullOrEmpty(LevelName))
            Application.Quit();

        else
            SceneManager.LoadScene(LevelName);
	}
}
