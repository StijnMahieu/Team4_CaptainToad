Shader "Custom/ShaderGhost"
{
  
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType"      = "Transparent"
        }
 
        LOD 200
 
        // extra pass that renders to depth buffer only
        Pass
        {
            ZWrite On
            ColorMask 0
        }
 
        UsePass "Transparent/Diffuse/FORWARD"

    }
    FallBack "Diffuse"
}
