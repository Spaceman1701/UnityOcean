using System;
using UnityEngine;
using System.Collections;
using System.IO;

namespace Ceto
{
    [Serializable]
    public class ShaderGradient
    {
        [SerializeField]
        public Gradient gradient;

        [SerializeField]
        [Range(2, 16)]
        public int resolution = 4;

        private Texture2D texture;

        private Gradient previousGradient;
        private int previousResolution;

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
        }

        public void UpdateDataIfChanged()
        {
            if (resolution != previousResolution || gradient.Equals(previousGradient))
            {
                previousResolution = resolution;
                previousGradient = gradient;
                UpdateBuffer();
            }
        }

        /// <summary>
        /// Update the GPU texture for this gradient. If the texture has not been created
        /// calling this method will create it.
        /// </summary>
        private void UpdateBuffer()
        {
            if (texture == null)
            {
                texture = new Texture2D(1, resolution);
            }
            else if (texture.height != resolution)
            {
                texture.Resize(1, resolution);
            }

            texture.anisoLevel = 0;
            texture.filterMode = FilterMode.Bilinear;

            for (int i = 0; i < resolution; i++)
            {
                texture.SetPixel(0, i, gradient.Evaluate(i / (float)resolution));
            }
            texture.Apply();
        }
    }
}

