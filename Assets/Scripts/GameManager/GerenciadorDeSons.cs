
using UnityEngine;

public class GerenciadorDeSons : MonoBehaviour
{
    //Arquivo usado como base para os audio clips
    public AudioSource arquivoAudio; 
    // Audioclip: os arquivos de som.
    public AudioClip  somDano,somPontos,somCliqueBotao;
    //variável estática: usada para acessarmos esse script em vários códigos sem precisar referenciá-lo.
    public static GerenciadorDeSons instancia;
    
  
    void Start()
    {
        //se não estiver uma instância do objeto Gerenciador de sons
        if (instancia == null)
        {
            //crie uma instância do Gerenciador de sons novo
            instancia = this;
        }
        else
        {
            //destrua este objeto e mantenha o Gerenciador que já tinha sido criado
            Destroy(instancia);
        }
        //Não destrua este objeto quando carregar a próxima cena.
        DontDestroyOnLoad(this);
    }

    public void TocarSomDano()
    {//Toque uma vez este audioclip(somDano) através do arquivo de áudio (audio source)
        arquivoAudio.PlayOneShot(somDano);
    }
    public void TocarSomBotao()
    {
        arquivoAudio.PlayOneShot(somCliqueBotao);
    }
    
    public void TocarSomPontos()
    {
        arquivoAudio.PlayOneShot(somPontos);
    }



}
