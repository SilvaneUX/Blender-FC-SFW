using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public GameObject[] bubbleParticle;
    public GameObject pupParticle;
    public Transform swimmer;
    public bool isModel;
    public Animator animator;
    [SerializeField] GameObject[] panel;
    [SerializeField] TextMeshProUGUI[] scorePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartEnding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BubblePanel()
    {
        MusikGame.Instance.Play("bgm", 0);
        yield return new WaitForSeconds(5);
        panel[0].SetActive(true);
        scorePanel[0].text = StaticScore.Instance.score.ToString();
        MusikGame.Instance.Play("ResultSFX", 1);
    }
    IEnumerator AmpasPanel()
    {
        MusikGame.Instance.Play("bgm", 0);
        yield return new WaitForSeconds(5);
        panel[1].SetActive(true);
        scorePanel[1].text = StaticScore.Instance.score.ToString();
        MusikGame.Instance.Play("ResultSFX", 1);
    }
    IEnumerator CepiritPanel()
    {
        MusikGame.Instance.Play("bgm", 0);
        yield return new WaitForSeconds(5);
        panel[2].SetActive(true);
        scorePanel[2].text = StaticScore.Instance.score.ToString();
        MusikGame.Instance.Play("cepiritpopup", 1);
    }

    void StartEnding()
    {
        animator.SetBool("IsModel", isModel);

        GameObject particle;
        GameObject particle2;
        if (StaticScore.Instance.score > 80)
        {
            MusikGame.Instance.Play("bgm", 0);
            MusikGame.Instance.Play("BubbleSFX", 1);
            particle = Instantiate(bubbleParticle[0], swimmer.transform.position, Quaternion.identity, swimmer);
            particle.transform.eulerAngles = new Vector3(0, 90, 0);
            particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, -2);
            StartCoroutine(BubblePanel());
        }
        else if (StaticScore.Instance.score < 81 && StaticScore.Instance.score >= 65)
        {
            MusikGame.Instance.Play("bgm", 0);
            MusikGame.Instance.Play("BerampasSFX", 1);
            particle = Instantiate(bubbleParticle[1], swimmer.transform.position, Quaternion.identity, swimmer);
            particle.transform.eulerAngles = new Vector3(0, 90, 0);
            particle.transform.position = new Vector3(particle.transform.position.x, particle.transform.position.y, -2);
            StartCoroutine(AmpasPanel());
        }
        else
        {
            MusikGame.Instance.Play("bgm", 0);
            MusikGame.Instance.Play("CepiritSFX", 1);
            particle2 = Instantiate(pupParticle, swimmer.transform.position, Quaternion.identity, swimmer);
            particle2.transform.eulerAngles = new Vector3(0, 90, 0);
            particle2.transform.position = new Vector3(particle2.transform.position.x, particle2.transform.position.y, -2);
            StartCoroutine(CepiritPanel());
        }

        

        
        
    }

    public void RestartLoad()
    {
        MusikGame.Instance.Play("ButtonSFX", 1);
        MusikGame.Instance.Play("BubbleSFX", 0);
        MusikGame.Instance.Play("BerampasSFX", 0);
        MusikGame.Instance.Play("CepiritSFX", 0);
        
        SceneManager.LoadScene(1);
    }
}
