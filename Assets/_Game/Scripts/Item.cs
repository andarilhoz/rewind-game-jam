using _Game.Scripts.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public GameObject outline;
    public UnityEvent onPlayerInteraction;
    public bool onTimeOnly = true;

    KeyboardInput input;
    bool executed = false;

    void Start()
    {
        input = KeyboardInput.Instance;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!executed && collision.CompareTag("Player"))
        {
            outline.SetActive(true);

            input.ActionButtonPressed += ExecuteEvent;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!executed && collision.CompareTag("Player"))
        {
            outline.SetActive(false);

            input.ActionButtonPressed -= ExecuteEvent;
        }
    }

    void ExecuteEvent()
    {
        onPlayerInteraction?.Invoke();

        if (onTimeOnly)
        {
            input.ActionButtonPressed -= ExecuteEvent;
            executed = true;
            outline.SetActive(false);
        }
    }
}
