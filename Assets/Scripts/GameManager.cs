using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private VRInputManager vrInputManagerPrefab;
    [SerializeField]
    private KeyboardMouseInputManager keyboardMouseInputManager;
    [SerializeField]
    private bool useKeyboardMouse = false;
    [SerializeField]
    private ParticleSystem leftHandParticleSystem;
    [SerializeField]
    private ParticleSystem rightHandParticleSystem;

    private IInputProvider inputProvider;
    private ColorSwatch colorSwatch = new ColorSwatch();
    private Random random = new Random();

    void Start()
    {
#if !UNITY_EDITOR
        useKeyboardMouse = false;
#endif
        if (useKeyboardMouse)
        {
            inputProvider = Instantiate(keyboardMouseInputManager);
        }
        else
        {
            inputProvider = Instantiate(vrInputManagerPrefab);
        }

        if (!inputProvider.TryInitialize())
        {
            Debug.LogError("Failed to initialize input provider");
            gameObject.SetActive(false);
            return;
        }

        // Set particle systems to follow controllers
        var leftController = inputProvider.GetLeftController();
        leftHandParticleSystem.transform.SetParent(leftController.GetTransform());
        leftHandParticleSystem.transform.localPosition = Vector3.zero;
        leftHandParticleSystem.transform.localRotation = Quaternion.Euler(0, 0, 0);
        var rightController = inputProvider.GetRightController();
        rightHandParticleSystem.transform.SetParent(rightController.GetTransform());
        rightHandParticleSystem.transform.localPosition = Vector3.zero;
        rightHandParticleSystem.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        if (inputProvider.GetLeftController().IsTriggerPressed())
        {
            leftHandParticleSystem.Emit(1);
        }

        if (inputProvider.GetRightController().IsTriggerPressed())
        {
            rightHandParticleSystem.Emit(1);
        }

        if (inputProvider.GetLeftController().IsColorChangePressed())
        {
            var main = leftHandParticleSystem.main;
            main.startColor = colorSwatch.HexToColor(colorSwatch.colors[random.Next(colorSwatch.colors.Count)]);
        }
        
        if (inputProvider.GetRightController().IsColorChangePressed())
        {
            var main = rightHandParticleSystem.main;
            main.startColor = colorSwatch.HexToColor(colorSwatch.colors[random.Next(colorSwatch.colors.Count)]);
        }
    }
    
}
