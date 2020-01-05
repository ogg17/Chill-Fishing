using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuideScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> slides = new List<Sprite>();
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject backButton;

    private Image image;
    private int slideCounter;
    void Start()
    {
        image = GetComponent<Image>();
    }


    public void NextSlide()
    {
        if (slideCounter < slides.Count - 1)
        {
            slideCounter++;
            image.sprite = slides[slideCounter];
            if (slideCounter > 0) backButton.SetActive(true);
            if (slideCounter == slides.Count - 1) nextButton.SetActive(false);
        }
    }

    public void BackSlide()
    {
        if (slideCounter > 0)
        {
            slideCounter--;
            image.sprite = slides[slideCounter];
            if (slideCounter < slides.Count - 1) nextButton.SetActive(true);
            if (slideCounter == 0) backButton.SetActive(false);
        }
    }
    
}
