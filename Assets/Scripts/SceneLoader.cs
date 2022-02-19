using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// MonoBehavior that controls loading between scenes
// Thank you Brackeys for the awesome tutorial on how to do this!

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public Slider slider;
    public Text progressText;
    public Button button;

    // The public method that calls the coroutine
    public void LoadScene (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }


    // Called by LoadScene as a coroutine
    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        // Begin to load the specified Scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Disable scene activation until we give permission
        operation.allowSceneActivation = false;

        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            Debug.Log("Loading progress: " + (operation.progress * 100) + "%");
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressText.text = progress * 100f + "%";
            slider.value = progress;

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Use this for initialization
    void Awake()
    {
        loadingScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
