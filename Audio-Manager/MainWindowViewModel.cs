using Audio_Manager.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio_Manager
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<AudioDeviceControl> _audioDevices
            = new ObservableCollection<AudioDeviceControl>();

        public MainWindowViewModel()
        {
            RefreshAudioDevices();
        }

        private void RefreshAudioDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            var newDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
                                    .Select(device => new AudioDeviceControl(device))
                                    .ToList();

            AudioDevices = new ObservableCollection<AudioDeviceControl>(newDevices);
        }

    }
}
