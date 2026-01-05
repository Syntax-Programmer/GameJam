using UnityEngine;

public class PerlinCompute : MonoBehaviour
{
    [Header("Compute Shader Settings")]
    [SerializeField] private ComputeShader shader;
    [SerializeField] private RenderTexture target;

    [Header("Noise Settings")]
    public float scale = 5f;
    public float timeScale = 0.1f;
    public int octaves = 5;
    public float persistence = 0.5f;

    [Header("Biome Colors")]
    public Color oceanColor = new(0f, 0.3f, 0.7f);
    public Color beachColor = new(0.9f, 0.85f, 0.6f);
    public Color grassColor = new(0.1f, 0.8f, 0.2f);
    public Color forestColor = new(0f, 0.5f, 0.1f);
    public Color mountainColor = new(0.5f, 0.5f, 0.5f);
    public Color snowColor = new(1f, 1f, 1f);


    private readonly int width = Screen.width;
    private readonly int height = Screen.height;

    [Header("Display Material")]
    [SerializeField] private Material displayMat;

    void Start()
    {
        // Create the RenderTexture
        target = new RenderTexture(width, height, 0)
        {
            enableRandomWrite = true,
            graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_SFloat
        };
        target.Create();

        // Assign texture to material if exists
        if (displayMat != null)
            displayMat.mainTexture = target;
    }

    void Update()
    {
        if (shader == null) return;

        int kernel = shader.FindKernel("CSMain");

        // Set the RenderTexture
        shader.SetTexture(kernel, "Result", target);

        // Set noise parameters
        shader.SetFloat("_Time", Time.time);
        shader.SetFloat("_Scale", scale);
        shader.SetFloat("_TimeScale", timeScale);
        shader.SetInt("_Octaves", octaves);
        shader.SetFloat("_Persistence", persistence);

        // Set biome colors
        shader.SetVector("_OceanColor", oceanColor);
        shader.SetVector("_BeachColor", beachColor);
        shader.SetVector("_GrassColor", grassColor);
        shader.SetVector("_ForestColor", forestColor);
        shader.SetVector("_MountainColor", mountainColor);
        shader.SetVector("_SnowColor", snowColor);

        // Calculate thread groups (match numthreads in shader)
        int threadGroupsX = Mathf.CeilToInt(width / 8f);
        int threadGroupsY = Mathf.CeilToInt(height / 8f);

        shader.Dispatch(kernel, threadGroupsX, threadGroupsY, 1);
    }
}
