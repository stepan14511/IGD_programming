using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Button level1_button;
    public Button level2_button;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(CloseGame);
        level1_button.onClick.AddListener(delegate { changeState(1); });
        level2_button.onClick.AddListener(delegate { changeState(2); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CloseGame()
    {
        Application.Quit();
    }

    public static void changeState(int level_number)
    {
        string[] level_names = { "Level 1", "Level 2" };
        if(level_number > level_names.Length)
        {
            Debug.LogError("Ha, this is impossible.");
            return;
        }

        SceneManager.LoadScene(level_names[level_number - 1], LoadSceneMode.Single);
    }
}
