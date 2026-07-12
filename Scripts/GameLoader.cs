using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("DifficultyDecider");
    }
    public void Options()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Options");
    }
    public void Awakening()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("AwakeningDiff");
    }
    public void Guardian()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("GuardianDiff");
    }
    public void Legend()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("LegendDiff");
    }
    public void LevelA1()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Awakening1");
    }
    public void LevelA2()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Awakening2");
    }
    public void LevelA3()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Awakening3");
    }
    public void LevelA4()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Awakening4");
    }
    public void LevelG1()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Guardian1");
    }
    public void LevelG2()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Guardian2");
    }
    public void LevelG3()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Guardian3");
    }
    public void LevelG4()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Guardian4");
    }
    public void LevelL1()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Legend1");
    }
    public void LevelL2()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Legend2");
    }
    public void LevelL3()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Legend3");
    }
    public void LevelL4()
    {
        Debug.Log("BUTTON CLICKED");
        SceneManager.LoadScene("Legend4");
    }
}
