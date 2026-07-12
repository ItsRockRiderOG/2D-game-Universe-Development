using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionLoader : MonoBehaviour
{   
    [SerializeField] Animator transitionAnim; // Reference to the transition animator
    
    public void NextScene()
    {
        StartCoroutine(LoadLevel());
    }

  IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End"); // Trigger the transition animation
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start"); // Trigger the transition animation
    }


}
