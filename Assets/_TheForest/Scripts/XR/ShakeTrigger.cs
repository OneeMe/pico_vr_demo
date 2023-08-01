using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ShakeTrigger : MonoBehaviour
{
  public Material inititalMaterial;

  public Material triggerdlMaterial;

  public float speedThreshold = 10f;

  public Renderer targetRenderer;

  public UnityEvent onHammerTriggered;

  public float durationThreshold = 1.5f;

  private Rigidbody rigidBody;

  private float duration = 0.0f;

  private bool isTriggered = false;

  // Start is called before the first frame update
  void Start()
  {
    rigidBody = GetComponent<Rigidbody>();
    targetRenderer.material = inititalMaterial;
  }

  // Update is called once per frame
  void Update()
  {
    CheckVelocity();
  }

  private void CheckVelocity()
  {
    if (isTriggered)
    {
      return;
    }

    float speed = rigidBody.velocity.magnitude;
    float elapsed = Time.deltaTime;
    if (speed < speedThreshold)
    {
      return;
    }
    if (duration < durationThreshold)
    {
      duration += elapsed;
      float ratio = (float)duration / durationThreshold;
      Debug.Log($"ratio is {ratio}");
      targetRenderer.material.Lerp(inititalMaterial, triggerdlMaterial, ratio);
    }
    else
    {
      Debug.Log($"tirggered, duration is {duration}");
      targetRenderer.material = triggerdlMaterial;
      onHammerTriggered?.Invoke();
      duration = 0.0f;
      isTriggered = true;
    }
  }

  public void ResetMaterial()
  {
    isTriggered = false;
    targetRenderer.material = inititalMaterial;
  }
}
