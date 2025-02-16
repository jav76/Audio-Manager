using CommunityToolkit.Mvvm.ComponentModel;
using NAudio.CoreAudioApi;

namespace Audio_Manager.Controls
{
    public partial class AudioDeviceControlViewModel : ObservableObject
    {

        private MMDevice _device;

        [ObservableProperty]
        private string? _deviceName;

        public AudioDeviceControlViewModel(MMDevice device)
        {
            _device = device;
            _deviceName = _device.FriendlyName;
        }
    }
}
