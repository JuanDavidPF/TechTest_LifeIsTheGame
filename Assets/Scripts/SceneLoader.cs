using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace JuanPayan.CodeSnippets
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private StringRefence sceneToLoad;
        [SerializeField] private LoadSceneMode loadMode = LoadSceneMode.Single;

        public void LoadScene()
        {
            if (!sceneToLoad) return;
            SceneManager.LoadScene(sceneToLoad.Value, loadMode);
        }//Closes LoadScene method

    }//Closes SceneLoader class

}//Closes Namespace declaration