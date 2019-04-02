using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ceto
{
    public class PMSpecturm : ISpectrum
    {


        private readonly float GRAVITY = SpectrumTask.GRAVITY;
        private readonly float ALPHA = 8.1f / (10 * 10 * 10);
        private readonly float BETA = 0.74f;

        private Vector2 windDir;
        private float windSpeed;

        public PMSpecturm(float windSpeed, float windDir)
        {
            float theta = windDir * Mathf.PI / 180.0f;
            this.windDir = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
            this.windSpeed = windSpeed;
        }

        public bool MultiThreadTask => throw new System.NotImplementedException();

        public WaveSpectrumConditionKey CreateKey(int size, float windDir, SPECTRUM_TYPE spectrumType, int numGrids)
        {
            throw new System.NotImplementedException();
        }

        public ISpectrum CreateSpectrum(WaveSpectrumConditionKey key)
        {
            throw new System.NotImplementedException();
        }

        public Vector4 GetChoppyness(int numGrids)
        {
            throw new System.NotImplementedException();
        }

        public Vector4 GetGridSizes(int numGrids)
        {
            throw new System.NotImplementedException();
        }

        public Vector4 GetWaveAmps(int numGrids)
        {
            throw new System.NotImplementedException();
        }

        public float Spectrum(float kx, float ky)
        {
            float f = Mathf.Sqrt(kx * kx + ky * ky);
            float omega = 2 * Mathf.PI * f;
            float omega0 = GRAVITY / windSpeed;
            float omega5 = Mathf.Pow(omega, 5);

            float omegaDiff = Mathf.Pow((omega0 / omega), 4);

            float exp = Mathf.Exp(-BETA * omegaDiff);

            float scaler = (ALPHA * GRAVITY * GRAVITY) / omega5;

            float tweak = Mathf.Sqrt(Mathf.Max(kx / f, 0.0f));

            return scaler * exp * tweak;
        }
    }
}

