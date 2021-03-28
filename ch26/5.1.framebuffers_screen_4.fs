#version 330 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0;

void main()
{
    vec2 offsets[9] = vec2[](
        vec2(-offset,  offset), // top-left
        vec2( 0.0f,    offset), // top-center
        vec2( offset,  offset), // top-right
        vec2(-offset,  0.0f),   // center-left
        vec2( 0.0f,    0.0f),   // center-center
        vec2( offset,  0.0f),   // center-right
        vec2(-offset, -offset), // bottom-left
        vec2( 0.0f,   -offset), // bottom-center
        vec2( offset, -offset)  // bottom-right    
    );

    float kernel[9] = float[](
        -1, -1, -1,
        -1,  9, -1,
        -1, -1, -1
    );

    vec3 sampleTex[9];
    for(int i = 0; i < 9; i++)
    {
        sampleTex[i] = vec3(texture(screenTexture, TexCoords.st + offsets[i]));
    }
    // FIXME: 一度何れかの要素に直接代入しないと正しく描画されない
    vec2 st = TexCoords.st;
    sampleTex[0] = vec3(texture(screenTexture, st + offsets[0]));
    // sampleTex[1] = vec3(texture(screenTexture, st + offsets[1]));
    // sampleTex[2] = vec3(texture(screenTexture, st + offsets[2]));
    // sampleTex[3] = vec3(texture(screenTexture, st + offsets[3]));
    // sampleTex[4] = vec3(texture(screenTexture, st + offsets[4]));
    // sampleTex[5] = vec3(texture(screenTexture, st + offsets[5]));
    // sampleTex[6] = vec3(texture(screenTexture, st + offsets[6]));
    // sampleTex[7] = vec3(texture(screenTexture, st + offsets[7]));
    // sampleTex[8] = vec3(texture(screenTexture, st + offsets[8]));

    vec3 col = vec3(0.0);
    for(int i = 0; i < 9; i++)
        col += sampleTex[i] * kernel[i];

    FragColor = vec4(col, 1.0);
}
