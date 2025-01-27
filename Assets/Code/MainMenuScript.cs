using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject popUpPanel;
    public GameObject darkPopUpPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        MusikGame.Instance.Play("bgm", 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void BTNStart()
    {
        MusikGame.Instance.Play("ButtonSFX", 1);
        SceneManager.LoadScene(2);
    }

    public void BTNCredit()
    {
        MusikGame.Instance.Play("ButtonSFX", 1);
        MusikGame.Instance.Play("bgm", 0);
        SceneManager.LoadScene(3);
    }

    public void BTNQuit()
    {
        MusikGame.Instance.Play("ButtonSFX", 1);
        Application.Quit();
    }

    public void BTNPopup()
    {
        MusikGame.Instance.Play("ButtonSFX", 1);
        popUpPanel.GetComponent<Animator>().SetBool("IsClosed", true);
        darkPopUpPanel.SetActive(false);
   

    }

}
