using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] TeleType dialogueTeleTyper;
    [SerializeField] Image image;
    [SerializeField] CanvasGroup storyCanvasGroup;
    private int storyIdx = 0;
    private int cutsceneIdx = 0;
    private Story currentStory;
    bool isAlreadyPressed=false;
    public void Initialize(Story story)
    {
        storyIdx = 0;
        cutsceneIdx = 0;
        currentStory = story;
        image.sprite = currentStory.cutscenes[cutsceneIdx];
        Utility.EnableMenu(storyCanvasGroup);
        dialogueTeleTyper.StartWrite(currentStory.dialogues[storyIdx]);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (dialogueTeleTyper.IsTextWriting)
        {
            dialogueTeleTyper.SkipWriting();
        }
        else if (currentStory.dialogues.Count - 1 == storyIdx)
        {
            Utility.FadeDisableCanvasGroup(storyCanvasGroup, 0.5f, 2);
            levelManager.StartGameplay();
        }
        else
        {
            storyIdx++;
            if (currentStory.isNextDialogueImage[storyIdx])
            {
                cutsceneIdx++;
                image.sprite = currentStory.cutscenes[cutsceneIdx];
            }
            dialogueTeleTyper.StartWrite(currentStory.dialogues[storyIdx]);
        }
    }
    void HandleDialogue() {
        if (dialogueTeleTyper.IsTextWriting)
        {
            dialogueTeleTyper.SkipWriting();
        }
        else if (currentStory.dialogues.Count - 1 == storyIdx)
        {
            Utility.FadeDisableCanvasGroup(storyCanvasGroup, 0.5f, 2);
            levelManager.StartGameplay();
        }
        else
        {
            storyIdx++;
            if (currentStory.isNextDialogueImage[storyIdx])
            {
                cutsceneIdx++;
                image.sprite = currentStory.cutscenes[cutsceneIdx];
            }
            dialogueTeleTyper.StartWrite(currentStory.dialogues[storyIdx]);
        }
    }
    public void OnPointerUp()
    {
        //throw new notimplemented
    }
}
