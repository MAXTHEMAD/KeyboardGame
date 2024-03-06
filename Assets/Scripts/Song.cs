using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class Song
{
    note[] songOne = { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5) };
    song singSong = new song("hat",new note[]{ new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4)});
    static song[] songs = {
        new song( 
            "TestSong", 
            new note[] { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5)}),
        new song(
            "allKeys",
            new note[] { new note(0, 1, 0), new note(1, 2, 1), new note(2, 3, 2), new note(3, 4, 3), new note(4, 5, 4), new note(5, 6, 5), new note(6, 7, 6), new note(7, 8, 7), new note(8, 9, 8), new note(9, 10, 9), new note(10, 11, 10), new note(11, 12, 11), new note(12, 13, 12),
                new note(13, 14, 13), new note(14, 15, 14), new note(15, 16, 15), new note(16, 17, 16), new note(17, 18, 17), new note(18, 19, 18), new note(19, 20, 19), new note(20, 21, 20), new note(21, 22, 21), new note(22, 23, 22), new note(23, 24, 23), new note(24, 25, 24)}),
        new song(
            "Funk",
            new note[]{new note(10.676f, 11.944f, 3),    new note(12f, 13.352f, 0), new note(13.328f, 14.704f, 2), new note(16.008f, 17.284f, 3),    new note(17.333f, 18.666f, 0),    new note(18.677f, 20.006f, 2),
                       new note(21.350f, 22.602f, 3),    new note(22.667f, 24.020f, 0),    new note(24f, 25.364f, 2), new note(25.336f, 25.937f, 7),    new note(25.988f, 26.639f, 5),    new note(26.639f, 28.095f, 3),    new note(28.054f, 29.367f, 0), new note(29.367f, 30.568f, 2), new note(30.640f, 31.138f, 7),  new note(31.322f, 31.759f, 10),  new note(32.014f, 32.594f, 12),
                       new note(34.029f, 34.701f, 15), new note(34.701f, 36.544f, 12), new note(36.696f, 37.287f, 15), new note(37.368f, 39.323f, 12), new note(39.373f, 40.035f, 10), new note(40.076f, 42.132f, 7),
                       new note(42.661f, 44.219f, 12),  new note(44.005f, 45.288f, 10), new note(45.359f, 46.560f, 14), new note(46.662f, 47.710f, 12),
                       new note(48.677f, 49.186f, 15), new note(49.186f, 51.232f, 12), new note(51.365f, 51.894f, 15), new note(51.853f, 52.953f, 12), new note(53.339f, 54.785f, 12), new note(54.703f, 55.996f, 10), new note(56.017f, 57.309f, 14), new note(57.309f, 58.225f, 12), new note(59.345f, 59.875f, 15), new note(59.875f, 61.890f, 12), new note(62.022f, 62.480f, 15), new note(62.531f, 63.071f, 12), new note(63.010f, 63.498f, 10), new note(63.498f, 63.977f, 7),
                       new note(64.038f, 65.585f, 7), new note(64.038f, 65.585f, 3), new note(66.053f, 66.654f, 10), new note(66.705f, 68.405f, 7), new note(69.351f, 70.848f, 7), new note(69.351f, 70.848f, 3), new note(71.367f, 72.018f, 10), new note(72.018f, 73.423f, 7),
                       new note(74.716f, 76.243f, 7), new note(74.716f, 76.243f, 3), new note(76.721f, 77.332f, 10), new note(77.373f, 79.073f, 7), new note(80.029f, 81.516f, 7), new note(80.029f, 81.516f, 3), new note(82.014f, 82.696f, 10), new note(82.696f, 84.091f, 7),
                       new note(85.353f, 87.369f, 12), new note(87.328f, 88.041f, 19), new note(88.041f, 90.718f, 17), new note(90.677f, 92.601f, 12), new note(92.682f, 93.385f, 19), new note(93.385f,95.339f, 17),
                       new note(96.021f, 96.306f, 17), new note(96.550f, 97.009f, 17), new note(97.009f, 97.273f, 15), new note(97.334f, 97.741f, 17), new note(97.884f, 98.342f, 17), new note(98.342f, 98.607f, 15), new note(98.678f, 99.034f, 17),new note(99.217f, 99.655f, 17), new note(99.655f, 99.920f, 15), new note(97.991f, 100.286f, 17),new note(100.531f, 101.070f, 17), new note(101.009f, 101.213f, 15), new note(101.325f, 101.640f, 17),
                       new note(101.874f, 102.414f, 17), new note(102.333f, 102.566f, 15), new note(102.668f, 102.923f, 17),new note(103.208f, 103.666f, 17), new note(103.666f, 104.032f, 15), new note(104.000f, 104.338f, 17),new note(104.531f, 104.969f, 17), new note(105.000f, 105.335f, 15), new note(105.335f, 105.661f, 17),new note(105.895f, 106.312f, 17), new note(106.394f, 106.811f, 15),
                       new note(117.377f, 117.540f, 7), new note(118.721f, 118.925f, 7), new note(119.199f, 119.301f, 7), new note(119.535f, 119.617f, 5),
                       new note(120.879f, 121.021f, 7), new note(121.378f, 121.490f, 7), new note(121.836f, 121.938f, 7), new note(122.192f, 122.263f, 5),
                       new note(123.546f, 123.668f, 9), new note(124.055f, 124.167f, 9), new note(124.513f, 124.615f, 9), new note(124.879f, 124.961f, 7),
                       new note(126.193f, 126.325f, 12), new note(126.701f, 126.773f, 12), new note(127.149f, 127.221f, 12), new note(127.557f, 127.638f, 10),
                       new note(128.870f, 128.961f, 7), new note(129.389f, 129.500f, 7), new note(129.847f, 129.939f, 7), new note(130.183f, 130.264f, 5),
                       new note(130.722f, 130.875f, 7), new note(131.201f, 131.384f, 7), new note(131.669f, 131.771f, 7), new note(131.995f, 132.097f, 5),
                       new note(133.328f, 133.481f, 7), new note(133.847f, 133.959f, 7), new note(134.295f, 134.407f, 7), new note(134.631f, 134.753f, 5),
                       new note(135.995f, 136.138f, 9), new note(136.524f, 136.636f, 9), new note(136.972f, 137.084f, 9), new note(137.349f, 137.430f, 7),
                       new note(138.723f, 143.996f, 7), new note(143.996f, 146.643f, 9), new note(146.643f, 149.350f, 10),
                       new note(149.350f, 154.674f, 7), new note(154.674f, 157.351f, 9), new note(157.351f, 160.008f, 10),
                       new note(160.008f, 164.701f, 7), new note(164.701f, 165.281f, 9), new note(165.362f, 168.019f, 10), new note(168.019f, 169.383f, 14),
                       new note(176.010f, 177.343f, 7), new note(177.343f, 178.616f, 5), new note(178.687f, 179.959f, 9), new note(180.000f, 181.120f, 7),
                       new note(186.678f, 188.011f, 7), new note(188.011f, 189.294f, 5), new note(189.365f, 190.627f, 9), new note(190.667f, 191.788f, 7),
                       new note(191.992f, 192.195f, 7), new note(192.500f, 192.704f, 7), new note(192.979f, 193.081f, 7), new note(193.305f, 193.386f, 5),
                       new note(194.638f, 194.791f, 7), new note(195.147f, 195.259f, 7), new note(195.615f, 195.707f, 7), new note(195.961f, 196.043f, 5),
                       new note(197.315f, 197.427f, 9), new note(197.844f, 197.946f, 9), new note(198.282f, 198.384f, 9), new note(198.659f, 198.730f, 7),
                       new note(199.962f, 200.084f, 12), new note(200.471f, 200.542f, 12), new note(200.919f, 201.000f, 12), new note(201.336f, 201.407f, 10),
                       new note(202.680f, 202.853f, 7), new note(203.158f, 203.351f, 7), new note(203.636f, 203.748f, 7), new note(203.962f, 204.044f, 5),
                       new note(205.306f, 205.448f, 7), new note(205.815f, 205.927f, 7), new note(206.253f, 206.365f, 7), new note(206.609f, 206.711f, 5),
                       new note(207.973f, 208.105f, 9), new note(208.482f, 208.614f, 9), new note(208.950f, 209.052f, 9), new note(209.306f, 209.398f, 7),
                       new note(210.630f, 210.742f, 12), new note(211.128f, 211.220f, 12), new note(211.576f, 211.658f, 12), new note(211.984f, 212.065f, 10),
                       new note(213.337f, 217.480f, 7), new note(213.337f, 217.480f, 10), new note(217.979f, 218.325f, 9), new note(217.979f, 218.325f, 12), new note(218.681f, 220.880f, 10), new note(218.681f, 220.880f, 14), new note(221.348f, 223.191f, 9), new note(221.348f, 223.191f, 12),  new note(223.354f, 223.710f, 9), new note(223.354f, 223.710f, 12),
            }),
        new song(
            "cads",
            new note[] { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5)}),

        new song(
            "Lofi",
            new note[]{new note(10.105f, 11.330f, 12), new note(11.354f, 12.644f, 10), new note(12.651f, 13.829f, 14), new note(13.881f, 15.017f, 12),
                       new note(15.170f, 16.360f, 12), new note(16.391f, 17.622f, 10), new note(17.712f, 18.841f, 14), new note(18.940f, 20.040f, 12),
                       new note(20.214f, 21.442f, 12), new note(21.459f, 22.750f, 10), new note(22.759f, 23.961f, 14), new note(24.040f, 25.037f, 12),
                       new note(25.304f, 26.442f, 12), new note(26.540f, 27.828f, 10), new note(27.821f, 28.951f, 14), new note(29.063f, 29.786f, 12),
                       new note(30.330f, 30.678f, 7),  new note(30.797f, 31.179f, 7), new note(31.272f, 32.584f, 5),  new note(32.856f, 33.168f, 5),  new note(33.333f, 33.623f, 5),  new note(33.807f, 35.171f, 3), new note(35.388f, 35.699f, 5), new note(35.859f, 36.097f, 5), new note(36.324f, 37.738f, 2), new note(37.898f, 38.713f, 2), new note(38.837f, 39.851f, 0),
                       new note(40.438f, 40.784f, 7),  new note(40.901f, 41.282f, 7), new note(41.378f, 42.692f, 5),  new note(42.964f, 43.274f, 5),  new note(43.438f, 43.729f, 5),  new note(43.909f, 45.277f, 3), new note(45.495f, 45.807f, 5), new note(45.964f, 46.203f, 5), new note(46.425f, 47.848f, 2), new note(48.002f, 48.819f, 2), new note(48.943f, 49.955f, 0),
                       new note(50.525f, 51.753f, 12), new note(51.775f, 53.065f, 10), new note(53.074f, 54.251f, 14), new note(54.298f, 55.438f, 12),
                       new note(55.589f, 56.783f, 12), new note(56.810f, 58.041f, 10), new note(58.131f, 59.261f, 14), new note(59.359f, 60.462f, 12),
                       new note(60.652f, 61.110f, 3),new note(61.115f, 61.613f, 7), new note(61.589f, 62.939f, 5), new note(63.137f, 63.569f, 5), new note(63.643f, 64.165f, 7), new note(64.165f, 65.554f, 3), new note(65.704f, 66.143f, 3), new note(66.143f, 66.632f, 7 ), new note(66.644f, 68.054f, 5), new note(68.235f, 69.165f, 5),
                       new note(69.181f, 70.389f, 3), new note(70.784f, 71.225f, 3), new note(71.264f, 71.719f, 7), new note(71.705f, 73.079f, 5), new note(73.274f, 73.704f, 5), new note(73.770f, 74.236f, 7), new note(74.224f, 75.695f, 3), new note(75.814f, 76.278f, 3), new note(70.784f, 71.225f, 3), new note(76.289f, 76.721f, 7), new note(76.761f, 78.222f, 5), new note(78.340f, 79.218f, 5),  new note(79.312f, 80.234f, 3),
                       new note(80.921f, 81.270f, 7),  new note(81.324f, 81.703f, 7), new note(81.799f, 83.109f, 5),  new note(83.381f, 83.695f, 5),  new note(83.858f, 84.148f, 5),  new note(84.332f, 85.697f, 3), new note(85.914f, 86.224f, 5), new note(86.384f, 86.626f, 5), new note(86.846f, 88.267f, 2), new note(88.427f, 89.239f, 2), new note(89.362f, 90.379f, 0),
                       new note(91.027f, 91.376f, 7),  new note(91.428f, 91.812f, 7), new note(91.903f, 93.217f, 5),  new note(93.486f, 93.274f, 5),  new note(93.961f, 94.257f, 5),  new note(94.436f, 95.803f, 3), new note(96.019f, 96.332f, 5), new note(96.491f, 96.728f, 5), new note(96.952f, 98.371f, 2), new note(98.531f, 99.344f, 2), new note(99.468f, 100.482f, 0),
                       new note(101.135f, 101.481f, 7),  new note(101.532f, 101.916f, 7), new note(102.009f, 103.321f, 5),  new note(103.590f, 103.903f, 5),  new note(104.071f, 104.362f, 5),  new note(104.544f, 105.910f, 3), new note(106.125f, 106.435f, 5), new note(106.598f, 106.836f, 5), new note(107.060f, 108.477f, 2), new note(108.635f, 109.452f, 2), new note(109.577f, 110.588f, 0),
                       new note(111.160f, 112.384f, 12), new note(112.403f, 113.698f, 10), new note(113.703f, 114.879f, 14), new note(114.931f, 116.069f, 12),
                       new note(116.221f, 117.412f, 12), new note(117.445f, 118.673f, 10), new note(118.764f, 119.893f, 14), new note(119.990f, 121.092f, 12),
            }),
    };

    public struct note
    {
        public float start;
        public float end;
        public int key;
        public float dynamics;
        public GameObject keyCube;
        public note(float iStart, float iEnd, int iKey, float iDynamics = 0)
        {
            start = iStart;
            end = iEnd;
            key = iKey;
            dynamics = iDynamics;
            keyCube = null;
        }
    }

    struct song
    {
        public string name;
        public note[] notes;
        public song(string iName, note[] iNotes)
        {
            name = iName;
            notes = iNotes;
        }
    }


    public static note[] LoadSong(int songIndex)
    {
        return songs[songIndex].notes;
    }
    public static note[] LoadSong(string songName)
    {
        int songIndex = 0;
        for (int i = 0; i < songs.Length; i++) {
            if (songs[i].name == songName)
            {
                songIndex = i;
                i = songs.Length;
            }
        }
        return songs[songIndex].notes;
    }
}
