using UnityEngine;
using System.Collections;
using Ludum.GameState;
using Ludum.Manager;

namespace Ludum.GameState
{
    public class CutsceneState : IGameState
    {
        //private CutsceneManager cutsceneManager;

        public void Enter()
        {
            //cutsceneManager = CutsceneManager.Instance;

            //// ��������� ���������� �������
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;

            //// ������������� ����� ���� ���� �����
            //// Time.timeScale = 0f;

            //// ��������� ��������
            //if (cutsceneManager != null)
            //{
            //    cutsceneManager.StartCutscene();
            //    cutsceneManager.OnCutsceneEnded += OnCutsceneEnded;
            //}

            Debug.Log("Entered Cutscene State");
        }

        public void LogicUpdate()
        {
            // ��������� ����������� �������� ��������
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            {
                SkipCutscene();
            }
        }

        public void PhysicalUpdate()
        {
            // � �������� ������������ ������ ����������� inputs
        }

        public void Exit()
        {
            //if (cutsceneManager != null)
            //{
            //    cutsceneManager.OnCutsceneEnded -= OnCutsceneEnded;
            //}

            // ��������������� ���������� �����
            Time.timeScale = 1f;

            Debug.Log("Exited Cutscene State");
        }

        private void SkipCutscene()
        {
            //cutsceneManager?.SkipCutscene();
        }

        private void OnCutsceneEnded()
        {
            // ��������� � ��������� ������������ ����� ��������
            GameStateManager.Instance.ChangeState(
                GameStateManager.Instance.freeMovementState
            );
        }
    }
}
