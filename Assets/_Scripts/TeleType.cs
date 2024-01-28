using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class TeleType : MonoBehaviour
{
    public TextMeshProUGUI tmText;
    [SerializeField] float charSpeedDelay = 0.05f;
    [SerializeField] bool isStartOnAwake = false;
    private bool isTextWriting=false;

    public bool IsTextWriting { get => isTextWriting; set => isTextWriting = value; }

    void Awake()
    {
        tmText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if (isStartOnAwake) StartCoroutine(SimulateWrite(tmText.text));
    }
    public void StartWrite(string textToWrite="")
    {
        StartCoroutine(SimulateWrite(textToWrite));
    }
    public IEnumerator SimulateWrite(string textToWrite)
    {
        isTextWriting=true;
        tmText.maxVisibleCharacters=0;
        tmText.text=textToWrite;
        tmText.ForceMeshUpdate();
        int totalVisibleCharacters = tmText.textInfo.characterCount;
        int counter = 0;
        int visibleCount = 0;
        while (visibleCount < totalVisibleCharacters && isTextWriting)
        {
            visibleCount = counter % (totalVisibleCharacters + 1);
            tmText.maxVisibleCharacters = visibleCount;
            counter += 1;
            yield return new WaitForSeconds(charSpeedDelay);
        }
        tmText.maxVisibleCharacters=tmText.textInfo.characterCount;
        isTextWriting=false;
    }
    public void SkipWriting() {
        isTextWriting=false;
        tmText.maxVisibleCharacters=tmText.textInfo.characterCount;
    }
}
