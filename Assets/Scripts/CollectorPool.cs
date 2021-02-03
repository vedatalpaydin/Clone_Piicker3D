using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectorPool : MonoBehaviour
{
    [SerializeField] private ElevatorUp elevatorUp;
    [SerializeField] private DoorController _doorController;
    [SerializeField] private TextMeshProUGUI ballText;
    [SerializeField] private FailedHandler _failedHandler;
    [SerializeField] private PushInsidePicker _pushInsidePicker;
    [SerializeField] private Transform playerMovement;
    [SerializeField] private AudioClip sectionPassedSFX;
    [SerializeField] private Image progressImage;
    
    [SerializeField] private int forNextLevelBallCount;


    private List<GameObject> ballInPool = new List<GameObject>();

    private AudioSource _audioSource;
    
    private bool sectionPassed;
    private bool ballCountimg;

    private float sayac;
    private float failCounter;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        sayac = 0;
        failCounter = 0;
        ballText.text = "0/" + forNextLevelBallCount;
    }
    private void Update()
    {
        if (ballCountimg)
        {
            failCounter += Time.deltaTime;
        }
        if (sectionPassed)
        {
            ProcessNextLevel();
        }
        else
        {
            if (failCounter>3f)
            {
                _failedHandler.GameOverCanvas();
            }
        }
    }
    private void ProcessNextLevel()
    {
        sayac += Time.deltaTime;
        if (sayac>1f)
        {
            elevatorUp.ProcessElevatorUp();
        }
        if (sayac>3f)
        {
            _doorController.OpenTheLeftDoor();
            _doorController.OpenTheRightDoor();
            ProcessScale();
            _audioSource.PlayOneShot(sectionPassedSFX);
            progressImage.enabled = true;
            ballInPool.Clear();
            failCounter = 0;
            ballCountimg = false;
            sectionPassed = false;
        }
        if (sayac>4f)
        {
            _pushInsidePicker.GetPickerList().Clear();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Ball")
        {
            ballCountimg = true;
            if (ballInPool.Contains(other.gameObject)) return;
            ballInPool.Add (other.gameObject);
            ballText.text = ballInPool.Count+"/"+forNextLevelBallCount;
            other.gameObject.GetComponent<ballParticles>().BallParticlePlay();
            if (ballInPool.Count>=forNextLevelBallCount)
            {
                sectionPassed = true;
            }
            else
            {
                sectionPassed = false;
            }
        }
    }

    private void ProcessScale()
    {
        if (playerMovement.localScale.x<1.4f)
        {
            playerMovement.localScale = new Vector3(playerMovement.localScale.x + .2f, playerMovement.localScale.y,playerMovement.localScale.z+.2f);
        }
    }

    public void CollectorPoolForNextLevel()
    {
        sectionPassed = false;
        ballCountimg = false;
        sayac = 0;
        ballText.text = "0/" + forNextLevelBallCount;
    }
}
