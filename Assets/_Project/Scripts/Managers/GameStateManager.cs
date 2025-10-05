using Ludum.GameState;
using UnityEngine;

namespace Ludum.Manager
{
    public class GameStateManager : MonoBehaviour
    {
        private static GameStateManager _instance;
        public static GameStateManager Instance => _instance;

        private IGameState currentState;
        private IGameState previousState;

        [Header("State References")]
        public CutsceneState cutsceneState;
        public FreeMovementState freeMovementState;
        public ArrowMovementState arrowMovementState;

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeStates();
        }

        void InitializeStates()
        {
            cutsceneState = new CutsceneState();
            freeMovementState = new FreeMovementState();
            arrowMovementState = new ArrowMovementState();

            // Начальное состояние
            ChangeState(freeMovementState);
        }

        void Update()
        {
            currentState?.LogicUpdate();
        }
        private void FixedUpdate()
        {
            currentState?.PhysicalUpdate();
        }

        public void ChangeState(IGameState newState)
        {
            if (currentState != null)
            {
                previousState = currentState;
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();

            Debug.Log($"Changed state to: {currentState.GetType().Name}");
        }

        public void ReturnToPreviousState()
        {
            if (previousState != null)
            {
                ChangeState(previousState);
            }
        }

        public T GetState<T>() where T : class, IGameState
        {
            if (typeof(T) == typeof(CutsceneState)) return cutsceneState as T;
            if (typeof(T) == typeof(FreeMovementState)) return freeMovementState as T;
            if (typeof(T) == typeof(ArrowMovementState)) return arrowMovementState as T;
            return null;
        }
    }
}
