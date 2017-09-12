using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void loadLevel(int levelindex)
    {
        StartCoroutine(LoadAsync(levelindex));
    }

    IEnumerator LoadAsync(int levelindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelindex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + " %";
            yield return null;
        }
    }
}
