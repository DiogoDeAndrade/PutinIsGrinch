using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SequenceText : MonoBehaviour
{
    [System.Serializable]
    struct StoryElement
    {
        [TextArea]
        public string   text;
        public Sprite   image;
    };

    [SerializeField]
    private StoryElement[]  text;
    [SerializeField]
    private RectTransform   targetElement;
    [SerializeField]
    private Image           targetImage;
    [SerializeField]
    private float           textDelay;
    [SerializeField]
    private string          skipButton;
    [SerializeField]
    private string          nextScene;

    TextMeshProUGUI textElement;
    int             textIndex = 0;

    void Start()
    {
        targetElement.gameObject.SetActive(false);
        textElement = targetElement.GetComponentInChildren<TextMeshProUGUI>();

        textIndex = 0;

        Invoke("NextText", textDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (textIndex > 0)
        {
            if (skipButton != "")
            {
                if (Input.GetButtonDown(skipButton))
                {
                    NextText();
                    if (textIndex > (text.Length + 1))
                    {
                        if (nextScene != "")
                        {
                            SceneManager.LoadScene(nextScene);
                        }
                    }
                }
            }
        }
    }

    void NextText()
    {
        targetElement.gameObject.SetActive(true);

        if (textIndex < text.Length) 
        { 
            textElement.text = text[textIndex].text;

            if ((targetImage) && (text[textIndex].image))
            {
                targetImage.sprite = text[textIndex].image;
            }
        }
        else
        {
            targetElement.gameObject.SetActive(false);
        }

        textIndex++;
    }
}
