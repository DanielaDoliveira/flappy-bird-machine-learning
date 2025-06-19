using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public TextMeshProUGUI recorde;
  public float timer = 0.5f;
    void Start()
    {
        recorde.text = PlayerPrefs.GetInt("POINTS").ToString();
    }

   public void VoltarAoJogo()
   {
       StartCoroutine("Timer");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  
    }

    public IEnumerator Timer()
    {
        GerenciadorDeSons.instancia.TocarSomBotao();
        yield return new WaitForSeconds(timer);
        
    }

    public void Sair()
    {
        StartCoroutine("Timer");
       
            Application.Quit(); // fechará o aplicativo
    
        
    }
}
