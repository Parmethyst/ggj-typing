using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleType : MonoBehaviour
{
    public TextMeshProUGUI tmText;
    [SerializeField] float charSpeedDelay = 0.05f;
    [SerializeField] bool isStartOnAwake = false;
    void Awake()
    {
        tmText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        if (isStartOnAwake) StartCoroutine(SimulateWrite());
    }
    public void StartWrite()
    {
        StartCoroutine(SimulateWrite());
    }
    public IEnumerator SimulateWrite()
    {
        tmText.ForceMeshUpdate();
        int totalVisibleCharacters = tmText.textInfo.characterCount;
        int counter = 0;
        int visibleCount = 0;
        while (visibleCount < totalVisibleCharacters)
        {
            visibleCount = counter % (totalVisibleCharacters + 1);
            tmText.maxVisibleCharacters = visibleCount;
            counter += 1;
            yield return new WaitForSeconds(charSpeedDelay);
        }
    }
}
