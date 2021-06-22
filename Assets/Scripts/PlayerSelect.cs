using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player { Frog, MaskDude};
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersController;
    public Sprite[] playerRenderer;

    void Start()
    {
        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playersController[0];
                    break;

                case Player.MaskDude:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playersController[1];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playersController[0];
                break;

            case "MaskDude":
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playersController[1];
                break;
            default:
                break;
        }
    }
}
