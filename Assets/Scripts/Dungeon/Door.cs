using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[DisallowMultipleComponent] 
public class Door : MonoBehaviour
{
    #region Header Object References
    [Space(10)]
    [Header("Object References")]
    #endregion

    #region Tooltip
    [Tooltip("Populate this with the BoxCollider2D component on the DoorCollider gameobject")]
    #endregion
    [SerializeField] private BoxCollider2D doorCollider;

    [HideInInspector] public bool isBossRoomDoor = false;
    private BoxCollider2D doorTrigger;
    private bool isOpen = false;
    private bool previouslyOpened = false;
    private Animator animator;

    private void Awake()
    {
        // Disable door collider by default
        doorCollider.enabled = false;

        // Load components
        animator = GetComponent<Animator>();
        doorTrigger = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Settings.playerTag || collision.tag == Settings.playerWeapon)
        {
            OpenDoor();
        }
    }

    private void OnEnable()
    {
        // When the parent gameobject is disable (when the player moves far enough away from the room)
        // the animator state gets reset. Therefore we need to restore the animaotr state.
        animator.SetBool(Settings.open, isOpen);
    }

    private void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            previouslyOpened = true;
            doorCollider.enabled = false;
            doorTrigger.enabled = false;

            // Set open parameter in animator
            animator.SetBool(Settings.open, true);

            // Play sound effect
            SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.doorOpenCloseSoundEffect);
        }
    }

    public void LockDoor()
    {
        isOpen = false;
        doorCollider.enabled = true;
        doorTrigger.enabled = false;

        // Set open to false to close door
        animator.SetBool(Settings.open, false);
    }

    public void UnlockDoor()
    {
        doorCollider.enabled = false;
        doorTrigger.enabled = true; 

        if (previouslyOpened == true)
        {
            isOpen = false;
            OpenDoor();
        }
    }

    #region Validator
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(doorCollider), doorCollider);
    }
#endif
    #endregion
}
