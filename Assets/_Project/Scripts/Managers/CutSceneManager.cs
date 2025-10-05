using Ludum.Quest;
using UnityEngine;

namespace Ludum.Manager
{
    public class CutSceneManager : MonoBehaviour
    {
        public static bool isLastScene = false;
        public static void StartBichTalkQuest()
        {
            isLastScene = false;
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.cutsceneState);
        }
        public static void EndQuest()
        {
            GameStateManager.Instance.ChangeState(GameStateManager.Instance.freeMovementState);
        }
        public static void NextScene()
        {
            isLastScene = !BichTalkingQuest.Instance.NextScene();
        }
    }
}
