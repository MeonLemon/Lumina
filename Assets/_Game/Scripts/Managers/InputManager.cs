public class InputManager : Singleton<InputManager>
{
    public Controls PlayerControls;

    protected override void Awake()
    {
        base.Awake();
        PlayerControls = new Controls();
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }
}