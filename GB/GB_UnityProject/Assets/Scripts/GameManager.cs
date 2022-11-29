using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject grabEvent;

    [SerializeField]
    GameObject pickUp;

    [SerializeField]
    GameObject mouseEvent;

    [SerializeField]
    MouseAnimationCaller mouse;

    [SerializeField]
    GameObject mouseEndEvent;

    [SerializeField]
    GameObject leanHandsEvent;

    [SerializeField]
    GameObject endScneneEvent;


    [SerializeField]
    RigController playerRigController;

    bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabEvent)
        {
            if(grabEvent.GetComponent<TriggerEvent>().trigger)
            {
                playerRigController.TriggerGrabEvent(grabEvent.GetComponent<TriggerEvent>().target);
                Destroy(grabEvent);
            }
        }
        if(pickUp)
        {
            if(pickUp.GetComponent<TriggerEvent>().trigger)
            {
                playerRigController.SetAsChild(pickUp.GetComponent<TriggerEvent>().target);
                pickUp.GetComponent<TriggerEvent>().target.GetComponent<Animator>().SetTrigger("TPickUp");
                Destroy(pickUp);
            }
        }
        if(mouseEvent)
        {
            if(mouseEvent.GetComponent<TriggerEvent>().trigger)
            {
                playerRigController.SetWalk(false);
                playerRigController.SetOberveTarget(mouseEvent.GetComponent<TriggerEvent>().target);
                mouse.Run();
                Destroy(mouseEvent);
            }
        }
        if(mouseEndEvent)
        {
            if(mouseEndEvent.GetComponent<TriggerEvent>().trigger)
            {
                playerRigController.StopObserveTarget();
                Destroy(mouseEndEvent);
            }
        }
        if(leanHandsEvent)
        {
            if(leanHandsEvent.GetComponent<TriggerEvent>().trigger)
            {

                playerRigController.SetLeanLeftHand(true, leanHandsEvent.GetComponent<TriggerEvent>().target);
            }
            else
            {
                playerRigController.SetLeanLeftHand(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if(endScneneEvent)
        {
            if(endScneneEvent.GetComponent<TriggerEvent>().trigger)
            {
                playerRigController.SetWalk(false);
            }
        }

        Time.timeScale = pause ? 0f : 1f;
    }

    public void TogglePause()
    {
        pause = !pause;
    }

    public void ResetScnene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
