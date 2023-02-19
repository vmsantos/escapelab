using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageController : MonoBehaviour {

    public Image[] images; // Array que armazena as imagens
    public float duration = 5.0f; // Duração de cada imagem na tela
    private int index = 0; // Índice da imagem atual

    IEnumerator Start() {
        while (true) {
            // Define a imagem atual e espera pela duração
            images[index].gameObject.SetActive(true);
            yield return new WaitForSeconds(duration);
            images[index].gameObject.SetActive(false);

            // Move para a próxima imagem
            index++;

            // Verifica se chegou na sétima imagem e carrega a cena "LAB"
            if (index >= images.Length) {
                SceneManager.LoadScene("Lab");
                yield break; // Encerra a rotina para interromper a exibição das imagens
            }

            // Verifica se o índice é válido e move para a próxima imagem
            if (index < images.Length) {
                continue;
            } else {
                index = 0;
            }
        }
    }
}
