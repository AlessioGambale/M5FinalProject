using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Events")]
    
    [SerializeField] private UnityEvent _onLivesEnded;
    [SerializeField] private PlayerController _playerController;

    [Header("Lives Settings")]
    [SerializeField] private int _maxLives;
    [SerializeField] private CheckPointManager _checkPointManager;

    public event Action<int> OnLifeLost;

    private LifeController _lifeController;
    private int _currentLives;

    public void SetLives(int lives)
    {
        _currentLives = Mathf.Clamp(lives, 0, _maxLives);
    }

    public void AddLife(int amount)
    {
        SetLives(_currentLives + amount);
    }

    private void OnEnable()
    {
        _lifeController.OnPlayerDeath += handleDeath;
    }

    private void Start()
    {
        _currentLives = _maxLives;
    }
    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
    }
    public void Respawn()
    {
        if(!_checkPointManager.HasCheckPoint()) return;
       
        transform.position = _checkPointManager.GetCheckPoint();
        _lifeController.RestoreFullHp();
        _playerController.Agent.ResetPath();
    }

    private void LoseALive()
    {
        _currentLives--;
        OnLifeLost?.Invoke(_currentLives);

    }

    private void handleDeath()
    {
        LoseALive();

        if (_currentLives <= 0)
        {
            _onLivesEnded.Invoke();
            return;
        }
        Respawn();
    }

    private void OnDisable()
    {
        _lifeController.OnPlayerDeath -= handleDeath;
    }
}
