using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongScript : MonoBehaviour
{
    note[] songOne = { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5) };
    song singSong = new song("hat", new note[] { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4) });
    static song[] songs = {
        new song(
            "TestSong",
            new note[] { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5)}),
        new song(
            "allKeys",
            new note[] { new note(0, 1, 0), new note(1, 2, 1), new note(2, 3, 2), new note(3, 4, 3), new note(4, 5, 4), new note(5, 6, 5), new note(6, 7, 6), new note(7, 8, 7), new note(8, 9, 8), new note(9, 10, 9), new note(10, 11, 10), new note(11, 12, 11), new note(12, 13, 12),
                new note(13, 14, 13), new note(14, 15, 14), new note(15, 16, 15), new note(16, 17, 16), new note(17, 18, 17), new note(18, 19, 18), new note(19, 20, 19), new note(20, 21, 20), new note(21, 22, 21), new note(22, 23, 22), new note(23, 24, 23), new note(24, 25, 24)}),
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
                       new note(117.377f, 117.540f, 7),

                       new note(53.324f, 53.644f, 12),   new note(53.644f, 53.976f, 15), new note(54.000f, 54.234f, 12), new note(54.247f, 54.468f, 10), new note(54.370f, 54.763f, 7), new note(54.726f, 54.886f, 10), new note(55.034f, 55.230f, 5), new note(55.366f, 55.476f, 7),
                       new note(56.288f, 56.485f, 7),    new note(56.620f, 56.731f, 7), new note(56.792f, 56.904f, 10), new note(56.965f, 57.137f, 12), new note(57.370f, 57.500f, 12), new note(57.690f, 57.850f, 12), new note(58.022f, 58.170f, 12),
                       new note(59.412f, 59.805f, 12),   new note(59.928f, 60.371f, 10), new note(60.333f, 60.838f, 7), new note(62.056f, 62.572f, 12), new note(62.500f, 62.954f, 10), new note(63.000f, 63.692f, 7),
                       new note(64.688f, 64.909f, 3),    new note(64.872f, 65.032f, 5), new note(65.000f, 65.106f, 7), new note(65.180f, 65.512f, 5), new note(65.684f, 65.991f, 3),
                       new note(67.295f, 67.492f, 3),    new note(67.500f, 67.652f, 5), new note(67.639f, 67.738f, 7), new note(67.836f, 68.070f, 5), new note(68.389f, 68.648f, 3),
                       new note(69.988f, 70.148f, 3),    new note(70.148f, 70.259f, 5), new note(70.283f, 70.382f, 7), new note(70.480f, 70.701f, 5), new note(71.058f, 71.316f, 3),
                       new note(72.669f, 72.854f, 3),    new note(72.854f, 72.977f, 5), new note(73.000f, 73.087f, 7), new note(73.161f, 73.419f, 5), new note(73.678f, 73.936f, 3), new note(74.182f, 74.674f, 2),
                       new note(74.723f, 74.768f, 12),   new note(74.879f, 74.998f, 12), new note(75.074f, 75.156f, 7), new note(75.309f, 75.451f, 12), new note(75.624f, 75.731f, 7), new note(75.981f, 76.088f, 10), new note(76.501f, 76.587f, 12),
                       new note(77.301f, 77.367f, 12),   new note(77.479f, 74.555f, 12), new note(77.662f, 77.815f, 7), new note(77.958f, 78.065f, 12), new note(78.284f, 78.376f, 7), new note(78.671f, 78.753f, 10), new note(79.145f, 79.247f, 12),
                       new note(80.042f, 80.103f, 12),   new note(80.210f, 80.327f, 12), new note(80.403f, 80.495f, 7), new note(80.643f, 80.780f, 12), new note(80.949f, 81.071f, 7), new note(81.326f, 81.422f, 10), new note(81.835f, 81.927f, 12),
                       new note(82.630f, 82.696f, 12),   new note(82.808f, 82.885f, 12), new note(82.992f, 83.139f, 7), new note(83.287f, 83.339f, 12), new note(83.618f, 83.710f, 7), new note(84.011f, 84.092f, 10), new note(84.474f, 84.576f, 12),
                       new note(83.305f, 87.980f, 0),    new note(88.046f, 90.619f, 5), new note(90.665f, 93.345f, 0), new note(93.345f, 95.734f, 5),
                       new note(96.020f, 96.315f, 17),   new note(96.549f, 97.018f, 17), new note(97.000f, 97.278f, 15), new note(97.329f, 97.747f, 17), new note(97.884f, 98.343f, 17), new note(98.333f, 98.618f, 15), new note(98.674f, 99.046f, 17), new note(99.209f, 99.647f, 17), new note(99.662f, 99.938f, 15),
                       new note(99.973f, 100.294f, 17),  new note(100.513f, 101.079f, 17), new note(101.007f, 101.227f, 15), new note(101.318f, 101.660f, 17), new note(101.853f, 102.414f, 17), new note(102.347f, 102.572f, 15), new note(102.663f, 102.938f, 17), new note(103.198f, 103.662f, 17), new note(103.667f, 104.019f, 15),
                       new note(104.00f, 104.333f, 17),  new note(104.518f, 104.971f, 17), new note(105.000f, 105.364f, 15), new note(105.323f, 105.680f, 17), new note(105.883f, 106.316f, 17),
                       new note(106.649f, 106.989f, 12), new note(106.989f, 107.312f, 15), new note(107.312f, 107.584f, 12), new note(107.559f, 107.806f, 10), new note(107.709f, 108.107f, 7), new note(108.033f, 108.232f, 10), new note(108.342f, 108.570f, 5), new note(108.688f, 108.802f, 7),
                       new note(109.614f, 109.828f, 7),  new note(109.920f, 110.082f, 7), new note(110.126f, 110.251f, 10), new note(110.295f, 150.482f, 12), new note(110.674f, 110.854f, 12), new note(111.001f, 111.185f, 12), new note(111.336f, 111.520f, 12),
                       new note(111.990f, 112.318f, 12), new note(112.318f, 112.651f, 15), new note(112.651f, 112.913f, 12), new note(112.891f, 113.141f, 10), new note(113.042f, 113.439f, 7), new note(113.369f, 113.564f, 10), new note(113.675f, 113.895f, 5), new note(114.017f, 54.133f, 7),
                       new note(114.943f, 115.167f, 7),  new note(115.249f, 115.414f, 7), new note(115.458f, 115.587f, 10), new note(115.631f, 115.815f, 12), new note(116.000f, 116.187f, 12), new note(116.330f, 116.518f, 12), new note(116.672f, 116.852f, 12),
                       new note(117.378f, 117.556f, 7),  new note(117.849f, 118.059f, 7), new note(118.334f, 118.452f, 7), new note(118.665f, 118.754f, 5),
                       new note(120.000f, 120.155f, 7),  new note(120.512f, 120.639f, 7), new note(120.960f, 121.067f, 7), new note(121.310f, 121.420f, 5),
                       new note(122.663f, 122.806f, 9),  new note(123.189f, 123.310f, 9), new note(123.639f, 123.755f, 9), new note(124.013f, 124.097f, 7),
                       new note(125.326f, 125.465f, 12), new note(125.833f, 125.921f, 12), new note(126.278f, 126.370f, 12), new note(126.690f, 126.764f, 10),
                       new note(127.992f, 128.116f, 7),  new note(128.500f, 128.635f, 7), new note(128.964f, 129.077f, 7), new note(129.312f, 129.410f, 5),
                       new note(130.707f, 130.890f, 7),  new note(131.188f, 131.393f, 7), new note(131.666f, 131.783f, 7), new note(132.000f, 132.083f, 5),
                       new note(133.333f, 133.485f, 7),  new note(133.846f, 133.966f, 7), new note(134.295f, 134.406f, 7), new note(134.643f, 134.757f, 5),
                       new note(135.977f, 136.139f, 9),  new note(136.525f, 136.643f, 9), new note(136.972f, 137.085f, 9), new note(137.342f, 137.427f, 7),
                       new note(138.709f, 144.000f, 7),  new note(144.000f, 146.653f, 9), new note(146.619f, 149.362f, 10), new note(149.362f, 154.674f, 7), new note(154.674f, 157.360f, 9), new note(157.338f, 160.002f, 10),
                       new note(160.002f, 164.707f, 7),  new note(164.691f, 165.286f, 9), new note(165.343f, 168.023f, 10), new note(167.998f, 169.399f, 14), new note(169.279f, 169.579f, 12), new note(169.579f, 169.997f, 10), new note(169.943f, 170.668f, 9),
                       new note(170.655f, 170.984f, 12), new note(170.984f, 171.313f, 15), new note(171.313f, 171.579f, 12), new note(171.560f, 171.801f, 10), new note(171.712f, 172.108f, 7), new note(172.035f, 172.225f, 10), new note(172.342f, 172.566f, 5), new note(172.690f, 172.797f, 7),
                       new note(173.615f, 173.829f, 7),  new note(173.924f, 174.079f, 7), new note(174.129f, 174.250f, 10), new note(174.294f, 174.484f, 12), new note(174.670f, 174.854f, 12), new note(175.006f, 175.183f, 12), new note(175.338f, 175.518f, 12),
                       new note(175.993f, 177.360f, 7),  new note(177.360f, 178.628f, 5), new note(178.666f, 179.979f, 9), new note(179.992f, 181.131f, 7),
                       new note(181.318f, 181.657f, 12), new note(181.648f, 181.983f, 15), new note(181.972f, 182.251f, 12), new note(182.222f, 182.473f, 10), new note(182.374f, 182.777f, 7), new note(182.698f, 182.899f, 10), new note(183.007f, 183.237f, 5), new note(183.352f, 183.468f, 7),
                       new note(184.278f, 184.500f, 7),  new note(184.584f, 184.749f, 7), new note(184.792f, 174.921f, 10), new note(174.959f, 195.156f, 12), new note(195.337f, 195.525f, 12), new note(195.667f, 195.853f, 12), new note(196.000f, 196.189f, 12),
                       new note(186.660f, 188.026f, 7),  new note(188.019f, 189.295f, 5), new note(189.335f, 190.644f, 9), new note(190.653f, 191.799f, 7),
                       new note(192.037f, 192.108f, 12), new note(192.212f, 192.333f, 12), new note(192.401f, 192.496f, 7), new note(192.634f, 192.785f, 12), new note(192.951f, 193.065f, 7), new note(193.318f, 193.429f, 10), new note(193.826f, 193.930f, 12),
                       new note(194.634f, 194.700f, 12), new note(194.798f, 194.889f, 12), new note(194.993f, 195.146f, 7), new note(195.283f, 195.402f, 12), new note(195.614f, 195.714f, 7), new note(196.001f, 196.088f, 10), new note(196.474f, 196.583f, 12),
                       new note(197.370f, 197.442f, 12), new note(197.544f, 197.667f, 12), new note(197.734f, 197.831f, 7), new note(197.967f, 198.117f, 12), new note(198.283f, 198.399f, 7), new note(198.649f, 198.764f, 10), new note(199.160f, 199.261f, 12),
                       new note(199.966f, 200.035f, 12), new note(200.131f, 200.225f, 12), new note(200.324f, 200.483f, 7), new note(200.616f, 200.739f, 12), new note(200.946f, 200.047f, 7), new note(201.335f, 201.419f, 10), new note(201.807f, 201.919f, 12),
                       new note(202.714f, 208.003f, 7),  new note(208.003f, 210.657f, 9), new note(210.615f, 213.363f, 10), new note(213.354f, 218.678f, 7), new note(218.668f, 221.358f, 9), new note(221.337f, 223.666f, 10),
                       new note(203.986f, 204.323f, 12), new note(204.314f, 204.650f, 15), new note(204.640f, 204.918f, 12), new note(204.888f, 205.140f, 10), new note(205.043f, 205.440f, 7), new note(205.366f, 205.564f, 10), new note(205.676f, 205.901f, 5), new note(206.018f, 206.134f, 7),
                       new note(206.946f, 207.165f, 7),  new note(207.252f, 207.417f, 7), new note(207.461f, 207.588f, 10), new note(207.625f, 207.821f, 12), new note(208.003f, 208.189f, 12), new note(208.334f, 208.520f, 12), new note(208.668f, 208.850f, 12),
                       new note(209.320f, 209.657f, 12), new note(209.647f, 209.984f, 15), new note(209.972f, 210.251f, 12), new note(210.223f, 210.473f, 10), new note(210.376f, 210.774f, 7), new note(210.700f, 210.899f, 10), new note(211.009f, 211.234f, 5), new note(211.351f, 211.467f, 7),
                       new note(212.276f, 212.501f, 7),  new note(212.584f, 212.748f, 7), new note(212.792f, 212.924f, 10), new note(212.958f, 213.154f, 12), new note(213.337f, 213.522f, 12), new note(213.664f, 213.854f, 12), new note(214.001f, 214.187f, 12)}),
        new song(
            "cads",
            new note[] { new note(1, 3, 0), new note(4, 7, 0), new note(5, 7, 4), new note(6, 7, 5), new note(9, 13, 2), new note(14, 15, 0), new note(14, 15, 5)})
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
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].name == songName)
            {
                songIndex = i;
                i = songs.Length;
            }
        }
        return songs[songIndex].notes;
    }
}
