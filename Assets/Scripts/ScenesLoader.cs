using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace AtomicCore.Utilities
{
    public class ScenesLoader : MonoBehaviour
    {
        [SerializeField] private string m_sceneName = string.Empty;
        [SerializeField] private LoadSceneMode m_loadingMode = LoadSceneMode.Single;

        [SerializeField] private UnityEvent m_onLoadingBegin;
        [SerializeField] private UnityEvent<float> m_onLoadingUpdate;
        [SerializeField] private UnityEvent m_onLoadingComplete;

        public string SceneName
        {
            get => m_sceneName;
            set => m_sceneName = value;
        }

        public LoadSceneMode LoadingMode
        {
            get => m_loadingMode;
            set => m_loadingMode = value;
        }

        public UnityEvent OnLoadingBegin  => m_onLoadingBegin;
        public UnityEvent OnLoadingComplete => m_onLoadingComplete;
        public UnityEvent<float> OnLoadingUpdate => m_onLoadingUpdate;

        public void LoadScene()
        {
            LoadSceneByName(m_sceneName);
        }

        public void LoadSceneByName(string name)
        {
            m_onLoadingBegin?.Invoke();
            SceneManager.LoadScene(name, m_loadingMode);
            m_onLoadingComplete?.Invoke();
        }

        public void LoadSceneAsync()
        {
            LoadSceneByNameAsync(m_sceneName);
        }

        public void LoadSceneByNameAsync(string name)
        {
            StartCoroutine(LoadSceneAsync(name));
        }

        public IEnumerator LoadSceneAsync(string name)
        {
            m_onLoadingBegin?.Invoke();

            var operation = SceneManager.LoadSceneAsync(name, m_loadingMode);
            do
            {
                m_onLoadingUpdate?.Invoke(operation.progress);
                yield return new WaitForEndOfFrame();
            } while (!operation.isDone);
            
            m_onLoadingUpdate?.Invoke(1f);
            m_onLoadingComplete?.Invoke();
        }

        public static IEnumerator LoadSceneAsync(string name, LoadSceneMode mode, Action beginCallback, Action endCallback, Action<float> progressChangeCallback)
        {
            beginCallback?.Invoke();

            var operation = SceneManager.LoadSceneAsync(name, mode);
            do
            {
                progressChangeCallback?.Invoke(operation.progress);
                yield return new WaitForEndOfFrame();
            } while (!operation.isDone);
            
            progressChangeCallback?.Invoke(1f);
            endCallback?.Invoke();
        }
    }
}