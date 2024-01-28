using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public static class Utility
{
    public static void DisableMenu(CanvasGroup cg)
    {
        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public static void EnableMenu(CanvasGroup cg)
    {
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public static void FadeDisableCanvasGroup(CanvasGroup cg, float duration, float delay)
    {
        Tween.Custom(1f, 0f, duration, onValueChange: newVal => cg.alpha = newVal);
        //LeanTween.alphaCanvas(cg, 0.0f, duration).setDelay(delay);
        cg.interactable = false;
        cg.blocksRaycasts = false;
        //DisableMenu(cg);
    }
    public static void FadeEnableCanvasGroup(CanvasGroup cg, float duration, float delay)
    {
        Tween.Custom(0f, 1f, duration, onValueChange: newVal => cg.alpha = newVal);
        //LeanTween.alphaCanvas(cg, 1.0f, duration).setDelay(delay);
        cg.interactable = true;
        cg.blocksRaycasts = true;
        //DisableMenu(cg);
    }
    public static void ToggleGameObjects(List<GameObject> gameObjectList, bool isActive)
    {
        //Debug.Log(gameObjectList.Count);
        for (int i = 0; i < gameObjectList.Count; i++)
        {
            gameObjectList[i].SetActive(isActive);
        }
    }
}
