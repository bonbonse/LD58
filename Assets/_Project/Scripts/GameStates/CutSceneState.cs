using UnityEngine;
using Ludum.Manager;
using Ludum.Character;

namespace Ludum.GameState
{
    public class CutsceneState : IGameState
    {
        private Player player;
        //private CutsceneManager cutsceneManager;

        public void Enter()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            CutSceneManager.NextScene();
        }

        public void LogicUpdate()
        {
            // ��������� ����������� �������� ��������
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (CutSceneManager.isLastScene)
                {
                    OnCutsceneEnded();
                } else
                {
                    CutSceneManager.NextScene();
                }
            }
        }

        public void PhysicalUpdate()
        {
            player.PhysicalUpdate();
        }

        public void Exit()
        {
            //// ��������������� ���������� �����
            //Time.timeScale = 1f;
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
