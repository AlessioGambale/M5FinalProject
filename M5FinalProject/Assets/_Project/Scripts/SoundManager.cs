using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _doorSound;
    [SerializeField] private AudioClip _enemyChaseSound;
    [SerializeField] private AudioClip _leverSound;
    [SerializeField] private AudioClip _vendingMachineSound;
    [SerializeField] private AudioClip[] _playerFootStepsSound;
    
    [SerializeField] private AudioSource _sfxSource;

    public static SoundManager Instance { get; private set; }
    private void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayButton()
    {
         _sfxSource.PlayOneShot(_buttonSound);
    }
    
    public void PlayDoor()
    {
        _sfxSource.PlayOneShot(_doorSound);
    }

    public void PlayLever()
    {
        _sfxSource.PlayOneShot(_leverSound);
    }

    public void PlayChase()
    {
        _sfxSource.PlayOneShot(_enemyChaseSound);
    }

    public void PlayPlayerSteps()
    {
        int randomIndex = Random.Range(0, _playerFootStepsSound.Length);
        _sfxSource.PlayOneShot(_playerFootStepsSound[randomIndex]);
    }
   
}

