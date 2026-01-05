using UnityEngine;

public class PerlinCompute : MonoBehaviour
{
    public ComputeShader shader;
    public RenderTexture target;
    public int width = 1024;
    public int height = 1024;

    [Header("Noise Settings")]
    public float scale = 5f;
    public float timeScale = 0.1f;
    public int octaves = 5;
    public float persistence = 0.5f;

    public Material displayMat;

    void Start()
    {
        target = new RenderTexture(width, height, 0);
        target.enableRandomWrite = true;
        target.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_SFloat;
        target.Create();
    }

    void Update()
    {
        int kernel = shader.FindKernel("CSMain");
        shader.SetTexture(kernel, "Result", target);
        shader.SetFloat("_Time", Time.time);
        shader.SetFloat("_Scale", scale);
        shader.SetFloat("_TimeScale", timeScale);
        shader.SetInt("_Octaves", octaves);
        shader.SetFloat("_Persistence", persistence);

        int threadGroupsX = Mathf.CeilToInt(width / 8f);
        int threadGroupsY = Mathf.CeilToInt(height / 8f);

        shader.Dispatch(kernel, threadGroupsX, threadGroupsY, 1);

        // ← Assign the RenderTexture to your material
        if (displayMat != null)
            displayMat.mainTexture = target;
    }
}
