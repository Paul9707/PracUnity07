Shader "Custom/TestSurfaceShader"
{
    Properties // 이 셰이더에서 사용할 변수 선언 
    {
        // 관례처럼 _자료형을 붙인다. ("인스펙터에서 보이는 이름", 자료형) = {초기값 할당} -> 마지막에 ;대신 줄바꿈을 해줘야 에러가 안남
    
        _MainTex ("Main Textur", 2D) = "white" {} 
       OverlabTex("Overlab Texture", 2D) = "gray" {}
       _colorAmount("Color Amount", Range(0,1)) = 1
       
    }
    SubShader
    {

        Tags { "RenderType"="Opaque" }
        // Opaque : 불투명한 물체를 그릴 때 사용
        // Transparent : 투명한 물체를 그릴 때 사용
        //  Cutout : 일정 값 이상의 투명도를 가진 물체를 그릴 때 사용
        //  Fade : 투명도를 가진 물체를 그릴 때 사용
       
       
        LOD 200 // LOD : Level of Detail, 렌더링의 세부 수준을 설정하는 명령어 -> Diffuse Level 

        CGPROGRAM
        // c for graphics 문법이 사용된 영역
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert
        //#pragma vertex vert // 정점 셰이더 라이브러리 함수를 사용하겠다.
        //#pragma fragment frag // 픽셀 셰이딩 라이브러리 함수를 사용하겠다.
        // Use shader model 3.0 target, to get nicer looking lighting


        sampler2D _MainTex; // 아래에서 선언하는 변수명은 위에랑 동일하게 선언해야 한다.
        sampler2D OverlabTex;
        float _colorAmount;

        struct Input
        {
            float2 uv_MainTex; // uv 매핑을 적용한 _MainTex의 색 정보
            float2 uvOverlabTex;
            float4 screenPos; // 화면상의 위치
        };

        //_Time : float4, 즉 4차원의 값으로 제공이 되는데
        // x값은: t/20 . y값은: y, z값은: t * 2 , W값은: t *3   // x가 가장 느리게 나머지는 시간값에 숫자를 곱한 값으로 이동
     
        void surf (Input IN, inout SurfaceOutput o)
        {
            //표면 셰이더에 텍스처 색을 적용
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;
            //o.Albedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;

            float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10,5);
            o.Albedo *= tex2D(OverlabTex, screenUV + _Time.w).rgb;
        }
        ENDCG
    }


    FallBack "Standard"
}
