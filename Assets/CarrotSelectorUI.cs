using UnityEngine;
using UnityEngine.UI;

public class CarrotSelectorUI : MonoBehaviour
{
    [SerializeField] private Image carrot1;
    [SerializeField] private Image carrot2;
    [SerializeField] private Image carrot3;

    [SerializeField] private Sprite collectedSprite;
    [SerializeField] private Sprite notCollectedSprite;

    private void Start()
    {
       
        UpdateCarrotImages();
    }

    private void UpdateCarrotImages()
    {
        carrot1.sprite = PlayerPrefs.GetInt("Carrot_1", 0) == 1 ? collectedSprite : notCollectedSprite;
        carrot2.sprite = PlayerPrefs.GetInt("Carrot_2", 0) == 1 ? collectedSprite : notCollectedSprite;
        carrot3.sprite = PlayerPrefs.GetInt("Carrot_3", 0) == 1 ? collectedSprite : notCollectedSprite;
    }
}
