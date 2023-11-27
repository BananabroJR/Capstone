using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public RectTransform box;

    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;
    public static bool isActive = false;


    private void Start()
    {
        box.transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isActive)
        {
            NewMessage();
        }
    }

    public void OpenDialouge(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
      

        DisplayMessage();

        box.LeanScale(Vector3.one, 0.5f);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
    }

    public void NewMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
           
            isActive= false;
            box.LeanScale(Vector3.zero, 0.5f);

        }
    }
}

