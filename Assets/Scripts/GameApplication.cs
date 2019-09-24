using System;
using System.Collections;
using System.Collections.Generic;
using DataBases;
using States;
using States.Main;
using UnityEngine;
using ViewControllers;

public enum GameApplicationStateType
{
    None,
    Transition,
    Menu,
    Main,
    GameOver
}

public class GameApplication : MonoBehaviour
{
    [Header("DataBases")] [SerializeField] private BlocksDataBase _blocksDataBase;
    [SerializeField] private BoostersDataBase _boostersDataBase;
    [SerializeField] private LevelsDataBase _levelsDataBase;

    [Header("ViewControllers")] [SerializeField]
    private MenuViewController _menuViewController;

    [SerializeField] private MainViewController _mainViewController;
    [SerializeField] private GameOverViewController _gameOverViewController;
    [SerializeField] private TransitionViewController _transitionViewController;


    private Dictionary<GameApplicationStateType, BaseState> _states;

    private BaseState _currentState;

    public BlocksDataBase BlocksDataBase => _blocksDataBase;
    public BoostersDataBase BoostersDataBase => _boostersDataBase;
    public LevelsDataBase LevelsDataBase => _levelsDataBase;

    // Start is called before the first frame update
    void Start()
    {
        _states = new Dictionary<GameApplicationStateType, BaseState>()
        {
            {GameApplicationStateType.Menu, new MenuState(this, _menuViewController)},
            {GameApplicationStateType.Main, new MainState(this, _mainViewController)},
            {GameApplicationStateType.GameOver, new GameOverState(this, _gameOverViewController)},
            {GameApplicationStateType.Transition, new TransitionState(this, _transitionViewController)},
        };
        SetState(GameApplicationStateType.Transition, GameApplicationStateType.Menu);
    }

    public void SetState(GameApplicationStateType stateType, params object[] enterArgs)
    {
        _currentState?.ExitState();
        if (_states.TryGetValue(stateType, out _currentState))
        {
            _currentState.EnterState(enterArgs);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _currentState?.Update();
    }
}