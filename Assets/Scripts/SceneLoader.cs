using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : Singleton<SceneLoader>
{

    [Range(0.0f, 5.0f)]
    public float addedWaitTime = 2f;

    public UnityEvent onLoadStart = new UnityEvent();
    public UnityEvent onLoadFinish = new UnityEvent();

    bool m_isloading = false;

    Scene m_pesistentScene;

    public bool fadeOnStart = true;
    public float fadeDuration = 2f;
    public Color fadeColor;
    public GameObject fadeScreen;
    private Renderer m_renderer;
    Coroutine m_fadeCoroutine = null;

    void Start()
    {
        m_renderer = fadeScreen.GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }


    protected override void Awake()
    {
        SceneManager.sceneLoaded += SetActiveScene;

        m_pesistentScene = SceneManager.GetActiveScene();

        if (!Application.isEditor)
            SceneManager.LoadSceneAsync(SceneUtils.Names.LobbyAwake, LoadSceneMode.Additive);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }


    public void LoadScene(string name)
    {
        if (!m_isloading)
        {
            StartCoroutine(Load(name));
        }
    }

    void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);

        SceneUtils.AlignXROrigin(m_pesistentScene, scene);
    }

    IEnumerator Load(string name)
    {
        m_isloading = true;
        onLoadStart?.Invoke();
        yield return FadeOut();
        yield return StartCoroutine(UnloadCurrentScene(name));

        yield return new WaitForSeconds(addedWaitTime);

        yield return StartCoroutine(LoadNewScene(name));
        yield return FadeIn();
        onLoadFinish?.Invoke();
        m_isloading = false;
    }

    IEnumerator UnloadCurrentScene(string name)
    {
        AsyncOperation unload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unload.isDone)
            yield return null;
    }

    IEnumerator LoadNewScene(string name)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        while (!load.isDone)
            yield return null;
    }

    IEnumerator FadeIn()
    {
        if (m_fadeCoroutine != null)
        {
            StopCoroutine(m_fadeCoroutine);
        }
        m_fadeCoroutine = StartCoroutine(Fade(1, 0));
        yield return m_fadeCoroutine;
    }

    IEnumerator FadeOut()
    {
        if (m_fadeCoroutine != null)
        {
            StopCoroutine(m_fadeCoroutine);
        }
        m_fadeCoroutine = StartCoroutine(Fade(0, 1));
        yield return m_fadeCoroutine;
    }

    IEnumerator Fade(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            m_renderer.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;

        m_renderer.material.SetColor("_Color", newColor2);
    }

}
