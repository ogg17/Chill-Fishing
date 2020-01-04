using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> slides = new List<Sprite>();

    [SerializeField] private UnityEvent endSlide;

    private Image image;
    private int slideCounter;
    void Start()
    {
        image = GetComponent<Image>();
    }


    public void NextSlide()
    {
        slideCounter++;
        image.sprite = slides[slideCounter];
        if (slideCounter >= slides.Count - 1) endSlide.Invoke();
    }
    
}
