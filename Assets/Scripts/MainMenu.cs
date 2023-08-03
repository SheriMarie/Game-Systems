using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Variables and Data
    public enum MenuState
    {
        MainMenu,
        PlayPanel,
        OptionsPanel,
        AreYouSurePanel

    }
    [Header("Menu States")]

    public MenuState menuState = MenuState.MainMenu;
    #endregion

    #region GUI Panels
    private void OnGUI()
    {
        switch (menuState)
        {
            case MenuState.MainMenu:
                {
                    MenuPanel();
                }
                break;
            case MenuState.PlayPanel:
                {
                    PlayPanel();
                }
                break;
            case MenuState.OptionsPanel:
                {
                    OptionsPanel();
                }
                break;
            case MenuState.AreYouSurePanel:
                {
                    AreyouSurePanel();
                }
                break;
            default:
                menuState = MenuState.MainMenu;
                break;
        }

    }
    void MenuPanel()
    {
        GUI.Box(new Rect(Grid.ScreenPlacement(0, 0, 16, 9)), "Main Menu");
        GUI.Box(new Rect(Grid.ScreenPlacement(4, 0.25f, 8, 2)), "Mush & Rush");
        GUI.Box(new Rect(Grid.ScreenPlacement(5, 2.5f, 6, 6.25f)), "Button Box");

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 3.25f, 4, 0.75f)), "Play"))
        {
            menuState = MenuState.PlayPanel;
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 5.25f, 4, 0.75f)), "Options"))
        {
            menuState = MenuState.OptionsPanel;
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Exit"))
        {
            menuState = MenuState.AreYouSurePanel;
        }
    }
    void PlayPanel()
    {

        GUI.Box(new Rect(Grid.ScreenPlacement(0, 0, 16, 9)), "PlayPanel");
        GUI.Box(new Rect(Grid.ScreenPlacement(4, 0.5f, 8, 8)), "Button Box");
        GUI.Box(new Rect(Grid.ScreenPlacement(5, 1.2f, 6, 1.5f)), "PlayPanel");

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 3.5f, 4, 0.75f)), "Continue"))
        {
            Debug.Log("In future we will load our lasted played saved game");
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 4.75f, 4, 0.75f)), "New Game"))
        {
            ChangeSceneByIndexValue(1);
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 6, 4, 0.75f)), "Load"))
        {
            Debug.Log("In future we will load from a lst of saved games");
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Back"))
        {
            menuState = MenuState.MainMenu;
        }
    }

    void OptionsPanel()
    {
        GUI.Box(new Rect(Grid.ScreenPlacement(0, 0, 16, 9)), "OptionsPanel");

        if (GUI.Button(new Rect(Grid.ScreenPlacement(6, 7.25f, 4, 0.75f)), "Back"))
        {
            menuState = MenuState.MainMenu;
        }
    }
    void AreyouSurePanel()
    {
        GUI.Box(new Rect(Grid.ScreenPlacement(0, 0, 16, 9)), "AreYouSurePanel");
        GUI.Box(new Rect(Grid.ScreenPlacement(5, 2.5f, 6, 5f)), "AreYouSurePanel");

        if (GUI.Button(new Rect(Grid.ScreenPlacement(5, 4.75f, 2.75f, 0.75f)), "Yes"))
        {
            ExitToDeskTop();
        }

        if (GUI.Button(new Rect(Grid.ScreenPlacement(8.25f, 4.75f, 2.75f, 0.75f)), "No"))
        {
            menuState = MenuState.MainMenu;
        }
    }
    #endregion

    #region Scene Management

    void ChangeSceneByName(string nameOfScene)
    {
        SceneManager.LoadScene(nameOfScene);
    }


    void ChangeSceneByIndexValue(int indexValueofScene)
    {
        SceneManager.LoadScene(indexValueofScene);
    }

    void ExitToDeskTop()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    #endregion
}
