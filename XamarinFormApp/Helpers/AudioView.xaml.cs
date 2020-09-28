using Plugin.SimpleAudioPlayer;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormApp.Helpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AudioView : ContentPage
    {
        ISimpleAudioPlayer player;
        public AudioView()
        {
            InitializeComponent();
            var stream = GetStreamFromFile("Diminished.mp3");
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            player.Load(stream);

            InitControls();
        }
        void InitControls()
        {
            sliderVolume.Value = player.Volume;

            btnPlay.Clicked += BtnPlayClicked;
            btnPause.Clicked += BtnPauseClicked;
            btnStop.Clicked += BtnStopClicked;

            sliderVolume.ValueChanged += SliderVolumeValueChanged;
            sliderPosition.ValueChanged += SliderPostionValueChanged;

        }

        private void SliderPostionValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sliderPosition.Value != player.Duration)
                player.Seek(sliderPosition.Value);
        }

        private void SliderVolumeValueChanged(object sender, ValueChangedEventArgs e)
        {
            player.Volume = sliderVolume.Value;
        }

        private void BtnStopClicked(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void BtnPauseClicked(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void BtnPlayClicked(object sender, EventArgs e)
        {
            player.Play();

            sliderPosition.Maximum = player.Duration;
            sliderPosition.IsEnabled = player.CanSeek;

            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);
        }

        bool UpdatePosition()
        {
            lblPosition.Text = $"Postion: {(int)player.CurrentPosition} / {(int)player.Duration}";

            sliderPosition.ValueChanged -= SliderPostionValueChanged;
            sliderPosition.Value = player.CurrentPosition;
            sliderPosition.ValueChanged += SliderPostionValueChanged;

            return player.IsPlaying;
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;

            var stream = assembly.GetManifestResourceStream("XamarinFormApp." + filename);

            return stream;
        }

    }
}