using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drink : MonoBehaviour
{
    [SerializeField] Button btnMix;
    [SerializeField] Button btnDrink;
   
    [SerializeField] private MenuManager manager;
    [SerializeField] private Animator animator;
    bool mixPressed;
    float subMixScore;
    float speed;
    private void Awake()
    {
    
        speed = 5;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mixPressed)
        {
            btnDrink.interactable = true;
            btnMix.interactable = false;
            
        }
  
       
        if(manager.isPressed == true)
        {
            MixScore();
            
        }

        if (manager.isPressed == false)
        {
            
            MixScore();
            

        }

        animator.SetBool("IsPressed", manager.isPressed);
    }

    public void MixPress()
    {
        mixPressed = true;
        
        subMixScore = Math.Clamp(subMixScore, -1, 10);
        StaticScore.Instance.score += Mathf.FloorToInt(subMixScore);
        
        Debug.Log(StaticScore.Instance.score);
    }

    public void MixScore()
    {
        subMixScore += 1 * speed * Time.deltaTime;
        //Debug.Log(subMixScore);
    }

    public void LoadScene()
    {
        MusikGame.Instance.Play("DrinkSFX", 1);
        SceneManager.LoadScene(4);
    }
}
