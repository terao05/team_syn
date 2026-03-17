using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image targetImage;
    public string[] imageNames = { "image1", "image2", "image3" };
    private int currentIndex = 0;

    void Start()
    {
        UpdateImage();
    }

    public void SwitchImage()
    {
        currentIndex = (currentIndex + 1) % imageNames.Length;
        UpdateImage();
    }

    void UpdateImage()
    {
        Sprite newSprite = Resources.Load<Sprite>(imageNames[currentIndex]);
        if (newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
        else
        {
            Debug.LogError("‰æ‘œ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ: " + imageNames[currentIndex]);
        }
    }
}
