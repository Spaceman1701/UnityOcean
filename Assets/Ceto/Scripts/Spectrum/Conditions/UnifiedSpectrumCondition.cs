using UnityEngine;
using System;

namespace Ceto
{

    public class UnifiedSpectrumCondition : WaveSpectrumCondition
    {

        public UnifiedSpectrumCondition(int size, float windSpeed, float windDir, float waveAge, int numGrids)
            : base(size, numGrids)
        {

            if (numGrids < 1 || numGrids > 4)
                throw new ArgumentException("UnifiedSpectrumCondition must have 1 to 4 grids not " + numGrids);

            Key = new UnifiedSpectrumConditionKey(windSpeed, waveAge, size, windDir, SPECTRUM_TYPE.UNIFIED, numGrids);

            if (numGrids == 1)
            {
                GridSizes = new Vector4(772, 1, 1, 1);
                Choppyness = new Vector4(2.3f, 1.0f, 1.0f, 1.0f);
                WaveAmps = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else if (numGrids == 2)
            {
                GridSizes = new Vector4(772, 57, 1, 1);
                Choppyness = new Vector4(2.3f, 2.1f, 1.0f, 1.0f);
                WaveAmps = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else if (numGrids == 3)
            {
                GridSizes = new Vector4(1372, 392, 28, 1);
                Choppyness = new Vector4(2.3f, 2.1f, 1.6f, 1.0f);
                WaveAmps = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else if (numGrids == 4)
            {
                GridSizes = new Vector4(1372, 392, 28, 4);
                Choppyness = new Vector4(2.3f, 2.1f, 1.6f, 0.9f);
                WaveAmps = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            }


        }

        private Vector4 AutoGridSize(float largest)
        {
            float ratio = 0.381966f; //the golden ratio;
            Vector4 gridSizes = new Vector4();
            gridSizes.x = largest;
            for (int i = 1; i < 4; i++)
            {
                gridSizes[i] = gridSizes[i - 1] * ratio;
            }
            return gridSizes;
        }

        public override SpectrumTask GetCreateSpectrumConditionTask()
        {

            UnifiedSpectrumConditionKey key = Key as UnifiedSpectrumConditionKey;

            UnifiedSpectrum uspectrum = new UnifiedSpectrum(key.WindSpeed, key.WindDir, key.WaveAge);

            return new SpectrumTask(this, true, new ISpectrum[] { uspectrum, uspectrum, uspectrum, uspectrum });
        }

    }

}












