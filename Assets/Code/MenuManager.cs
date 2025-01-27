using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;
    public Button btnMix;
    public bool isMix;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            PlayerGrab.Instance.buttonPourPressed = true;
        }
        else
        {
            PlayerGrab.Instance.buttonPourPressed = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        if (isMix)
        {
            MusikGame.Instance.Play("MixSFX", 1);
        }
        else
        {
            MusikGame.Instance.Play("PourSFX", 1);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        if (isMix)
        {
            MusikGame.Instance.FadeOut("MixSFX", 0.1f);
        }
        else
        {
            MusikGame.Instance.FadeOut("PourSFX", 0.1f);
        }
    }
}
