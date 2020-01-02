Shader "Zero/Test"{
    Properties{
        _MainTex("Texture", 2D) = "white"{}
    }
    
    SubShader{
        Pass { // some shaders require multiple passes
            GLSLPROGRAM // here begins the part in Unity's GLSL
    
                #ifdef VERTEX // here begins the vertex shader
        
                    #version 110
            
                    attribute vec2 vertex;
                    attribute vec2 texCoord;
                    
                    varying vec2 vTexCoord;
                    
                    void main() {
                        gl_Position = vec4(vertex, 0.0, 1.0);
                        vTexCoord = texCoord;
                    }

                #endif // here ends the definition of the vertex shader
        
        
                #ifdef FRAGMENT // here begins the fragment shader
        
                #version 110

                    const int MAX_KOEFF_SIZE = 32; //максимальный размер ядра (массива коэффициентов)
                    
                    uniform sampler2D _MainTex; //размываемая текстура
                    uniform int kSize; //размер ядра
                    uniform float koeff[MAX_KOEFF_SIZE]; //коэффициенты
                    uniform vec2 direction; //направление размытия с учетом радиуса размытия и aspect ratio, например (0.003, 0.0) - горизонтальное и (0.0, 0.002) - вертикальное
                    
                    varying vec2 vTexCoord; //текстурные координаты текущего фрагмента
                    
                    void main() {
                        vec4 sum = vec4(0.0); //результирующий цвет
                    
                        vec2 startDir = -0.5*direction*float(kSize-1); //вычисляем начальную точку размытия
                        for (int i=0; i<kSize; i++) //проходимся по всем коэффициентам
                            sum += texture2D(_MainTex, vTexCoord + startDir + direction*float(i)) * koeff[i]; //суммируем выборки 
                    
                        gl_FragColor = sum;
                    }
        
                #endif // here ends the definition of the fragment shader
    
             ENDGLSL // here ends the part in GLSL 
        }
    }
    
    Fallback Off
}