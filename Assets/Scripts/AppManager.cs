using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public string MenuUtamaScene;
    public string MulaiScene;
    public string LibraryScene;

    public void MenuUtama()
    {
        SceneManager.LoadScene(MenuUtamaScene);
    }

    public void MulaiGame()
    {
        SceneManager.LoadScene(MulaiScene);
    }

    public void Library()
    {
        SceneManager.LoadScene(LibraryScene);
    }

    public void KeluarAplikasi()
    {
        Application.Quit();
    }
}