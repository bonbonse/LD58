using UnityEngine;

namespace Ludum.GameState
{
    public interface IGameState
    {
        void Enter();
        void LogicUpdate();
        void PhysicalUpdate();
        void Exit();
    }
}
