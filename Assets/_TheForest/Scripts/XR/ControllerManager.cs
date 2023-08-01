
using UnityEngine;
using UnityEngine.Events;

public class ControllerManager : MonoBehaviour
{

  private GameInput gameInput;

  public UnityEvent onMenuButtonPressed;
  public UnityEvent onLeftPrimaryButtonPressed;
  public UnityEvent onLeftSecondaryButtonPressed;

  public UnityEvent onRightPrimaryButtonPressed;
  public UnityEvent onRightSecondaryButtonPressed;

  void Awake()
  {
    gameInput = new GameInput();
    gameInput.Controller.MenuButton.performed += ctx => onMenuButtonPressed?.Invoke();
    gameInput.Controller.LeftPrimaryButton.performed += ctx => onLeftPrimaryButtonPressed?.Invoke();
    gameInput.Controller.LeftSecondaryButton.performed += ctx => onLeftSecondaryButtonPressed?.Invoke();
    gameInput.Controller.RightPrimaryButton.performed += ctx => onRightPrimaryButtonPressed?.Invoke();
    gameInput.Controller.RightSecondaryButton.performed += ctx => onRightSecondaryButtonPressed?.Invoke();
  }

  void OnEnable()
  {
    gameInput.Controller.Enable();
  }

  void OnDisable()
  {
    gameInput.Controller.Disable();
  }
}
