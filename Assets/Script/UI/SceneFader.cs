using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{

	public Image img;
	public AnimationCurve curve;
	private AsyncOperation loading;
	private GameObject tempScreen;
	private Scene currentScene;


	void Start()
	{
		StartCoroutine(FadeIn());
	}

	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn()
	{
		float t = 1f;

		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene)
	{
		float t = 0f;

		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}

		SceneManager.LoadScene(scene);
	}



	public void LoadScene(string scene)
	{
		tempScreen.SetActive(true);
		loading = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
		loading.completed += OnSceneLoaded;
	}

	private void OnSceneLoaded(AsyncOperation obj)
	{
		loading.completed -= OnSceneLoaded;
		tempScreen.SetActive(false);
		SceneManager.UnloadSceneAsync(currentScene);
	}




}