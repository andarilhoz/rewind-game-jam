using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button Play;
    public Button Credits;
    public Button Options;
    public Button Quit;

    public ZUIElementBase MainMenu;
    public void Start()
    {
        Play.onClick.AddListener(delegate { PlayButton(); });
        Credits.onClick.AddListener(delegate { CreditsButton(); });
        Options.onClick.AddListener(delegate { OptionsButton(); });
        Quit.onClick.AddListener(delegate { LeaveButton(); });
        MainMenu.OnShowComplete.AddListener(delegate
        {
            MainMenu.UseSimpleActivation = true;
        });
    }
    
    void PlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    void CreditsButton()
    {
        ZUIManager.Instance.OpenMenu("Creditos");
    }

    void OptionsButton()
    {
        ZUIManager.Instance.OpenMenu("Options");
    }

    void LeaveButton()
    {
        Application.Quit();
    }

    void BackButton()
    {
        ZUIManager.Instance.Back();
    }
}
