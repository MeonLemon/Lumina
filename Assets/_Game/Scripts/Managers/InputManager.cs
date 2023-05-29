public class InputManager : Singleton<InputManager>
{
    public Controls PlayerControls;

    protected override void Awake()
    {
        base.Awake();
        PlayerControls = new Controls();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    public void ToggleControls(bool toggle)
    {
        if(toggle)
        {
            PlayerControls.Enable();
        }
        else
        {
            PlayerControls.Disable();
        }
    }
}