using System;
using NAudio.CoreAudioApi;

class Program
{
    static void Main()
    {
        // 変更したい音量を1から100の間で標準入力から指定
        Console.WriteLine("音量を1から100の間で指定してください。");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int volume) || volume < 1 || volume > 100)
        {
            Console.WriteLine("無効な入力です。1から100の間で指定してください。");
            return;
        }
        // 音量を0.01から1.0の間に変換
        float volumeLevel = volume / 100f;

        // デフォルトのオーディオデバイスを取得
        var deviceEnumerator = new MMDeviceEnumerator();
        var device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

        // 音量を50%に設定
        device.AudioEndpointVolume.MasterVolumeLevelScalar = volumeLevel; // 0.5f;

        // ミュートする
        // device.AudioEndpointVolume.Mute = true;

        Console.WriteLine($"音量を{volume}%に設定しました。");
    }
}
