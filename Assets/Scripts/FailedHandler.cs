using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FailedHandler : MonoBehaviour
{
   [SerializeField] private Canvas gameOverCanvas;
   [SerializeField] private TextMeshProUGUI menuText;
   [SerializeField] private Button _button;
   [SerializeField] private PlayerMovement _playerMovement;
   private void Start()
   {
      gameOverCanvas.enabled = false;
   }

   public void GameOverCanvas()
   {
      gameOverCanvas.enabled = true;
      menuText.text = "Level Failed";
      _button.enabled = true;
     // _playerMovement.SetCanPickerMove(false);
   }

   public void FinishCanvas()
   {
      gameOverCanvas.enabled = true;
      menuText.text = "Level Passed";
   }
}
