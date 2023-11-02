using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenSpaceOutlines : ScriptableRendererFeature
{
    [System.Serializable]
    private class ViewSpaceNormalsTextureSettings { }
    private class ViewSpaceNormalsTexturePass : ScriptableRenderPass
    {
        private ViewSpaceNormalsTextureSettings normalsTextureSettings;

        private readonly RenderTargetHandle normals;
        public ViewSpaceNormalsTexturePass(RenderPassEvent renderPassEvent)
        {
            this.renderPassEvent = renderPassEvent;
            normals.Init("_SceneViewSpaceNormals");
        }

        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            RenderTextureDescriptor normalsTextureDescriptor = cameraTextureDescriptor;
            normalsTextureDescriptor.colorFormat = normalsTextureSettings.colorFormat;
            normalsTextureDescriptor.depthBufferBits = normals;
            cmd.GetTemporaryRT(normals.id, cameraTextureDescriptor, FilterMode.Point);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {

        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {

        }
    }

    private class ScreenSpaceOutlinePass : ScriptableRenderPass
    {

    };

    [SerializeField]
    private ViewSpaceNormalsTextureSettings viewSpaceNormalsTextureSettings;

    [SerializeField]
    private RenderPassEvent renderPassEvent;

    private ViewSpaceNormalsTexturePass viewSpaceNormalsTexturePass;
    private ScreenSpaceOutlinePass screenSpaceOutlinePass;
    public override void Create()
    {
        viewSpaceNormalsTexturePass = new ViewSpaceNormalsTexturePass(renderPassEvent);
        screenSpaceOutlinePass = new ScreenSpaceOutlinePass(renderPassEvent);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(viewSpaceNormalsTexturePass);
        renderer.EnqueuePass(screenSpaceOutlinePass);
    }
}
