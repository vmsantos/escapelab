using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingIndicator;

    void Start()
    {
        loadingIndicator.SetActive(true);

        // Carrega a cena "MinhaNovaCena" assincronamente
        SceneManager.LoadSceneAsync("MinhaNovaCena");
    }

    void Update()
    {
        // Se a cena "MinhaNovaCena" estiver completamente carregada, oculta o indicador de loading
        if (SceneManager.GetSceneByName("MinhaNovaCena").isLoaded)
        {
            loadingIndicator.SetActive(false);
        }
    }
}
