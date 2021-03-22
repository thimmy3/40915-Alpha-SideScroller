using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace JacksCode
{
    /* public class GameOver : MonoBehaviour
     {
         Animator m_Animator;

         bool gameEnded = false;

        public SceneFader sceneFader;

         public string menuSceneName = "Menu";

         void Start()
         {
             m_Animator = gameObject.GetComponent<Animator>();
         }


         void Update()
         {
             if (gameEnded)
                 return;

             if (PlayerStats.Lives <= 0)
             {
                 EndGame();
             }
         }

         void EndGame()
         {
             gameEnded = true;

             m_Animator.SetTrigger("Game Over");
             Debug.Log("Game Over");
         }

         public void Retry()
         {
             sceneFader.FadeTo(SceneManager.GetActiveScene().name);
         }

         public void Menu()
         {
             sceneFader.FadeTo(menuSceneName);
         }
     }

     */
}

