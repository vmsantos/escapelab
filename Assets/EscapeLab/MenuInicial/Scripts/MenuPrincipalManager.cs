using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoesLogin;
	[SerializeField] private GameObject painelOpcoesRegras;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirOpcoesLogin()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoesLogin.SetActive(true);
    }

    public void FecharOpcoesLogin()
    {
        painelOpcoesLogin.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

	public void AbrirOpcoesRegras()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoesRegras.SetActive(true);
    }

    public void FecharOpcoesRegras()
    {
        painelOpcoesRegras.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}