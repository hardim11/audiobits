using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CSCore;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.Streams;
using CSCore.Win32;
using System.Runtime.InteropServices;
using CSCore.SoundOut;
using CSCore.Codecs;
using System.Collections.ObjectModel;




namespace audiobits
{
    public partial class FormMain : Form
    {

        //for the track bar
        private bool _stopSliderUpdate;




        private const CaptureMode captureMode = CaptureMode.LoopbackCapture;

//        private MMDevice _selectedDevice;
        private WasapiCapture _soundIn;
//        private IWriteable _writer;
//        private IWaveSource _finalSource;
        private IWaveSource _waveSource;
//        SoundInSource _soundInSource;

        private readonly ObservableCollection<MMDevice> _outputDevices = new ObservableCollection<MMDevice>();
        private readonly ObservableCollection<MMDevice> _inputDevices = new ObservableCollection<MMDevice>(); 
        private ISoundOut _soundOut;

        DummyRef dummyMask = new DummyRef();


        public FormMain()
        {
            InitializeComponent();


            RefreshDevices();


            SetBitDepth(15);
        }


        private void PickFolder(TextBox txtBox)
        {
            string Folder = txtBox.Text;
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Folder;
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = dlg.SelectedPath;
            }
        }

        private void PickFileSave(TextBox txtBox, string Filter = "Xml Files|*.xml")
        {
            string FileSave = txtBox.Text;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = FileSave;
            dlg.InitialDirectory = Path.GetDirectoryName(FileSave);
            dlg.Filter = Filter;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = dlg.FileName;
            }
        }

        private void PickFileOpen(TextBox txtBox, string Filter = "Xml Files|*.xml")
        {
            string FileOpen = txtBox.Text;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = FileOpen;
            dlg.InitialDirectory = Path.GetDirectoryName(FileOpen);
            dlg.Filter = Filter;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = dlg.FileName;
            }
        }

        private void buttonPickAudioFile_Click(object sender, EventArgs e)
        {
            PickFileOpen(this.textBoxAudioFile, "MP3|*.mp3|WAV|*.wav|All Files|*.*");
        }

        private static WaveFormat WaveFormatFromBlob(Blob blob)
        {
            if (blob.Length == 40)
                return (WaveFormat)Marshal.PtrToStructure(blob.Data, typeof(WaveFormatExtensible));
            return (WaveFormat)Marshal.PtrToStructure(blob.Data, typeof(WaveFormat));
        }


        private void RefreshDevices()
        {
            //input drop down
            _inputDevices.Clear();
            using (var deviceEnumerator = new MMDeviceEnumerator())
            using (var deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
            {
                foreach (var device in deviceCollection)
                {
                    _inputDevices.Add(device);
                }
            }
            comboBoxInputDevice.DataSource = _inputDevices;
            comboBoxOutputDevice.DisplayMember = "FriendlyName";
            comboBoxOutputDevice.ValueMember = "DeviceID";


            //output drop down
            _outputDevices.Clear();
            using (MMDeviceEnumerator mmdeviceEnumerator = new MMDeviceEnumerator())
            {
                using (
                    MMDeviceCollection mmdeviceCollection = mmdeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
                {
                    foreach (var device in mmdeviceCollection)
                    {
                        _outputDevices.Add(device);
                    }
                }
            }

            comboBoxOutputDevice.DataSource = _outputDevices;
            comboBoxOutputDevice.DisplayMember = "FriendlyName";
            comboBoxOutputDevice.ValueMember = "DeviceID";

            comboBoxOutputDevice.SelectedIndex = 2;
        }


        public void OpenSoundOut(MMDevice device)
        {
            _soundOut = new WasapiOut() { Latency = 100, Device = device };
            _soundOut.Initialize(_waveSource);
            if (PlaybackStopped != null) _soundOut.Stopped += PlaybackStopped;
        }


        private void CleanupPlayback()
        {
            if (_soundOut != null)
            {
                _soundOut.Dispose();
                _soundOut = null;
            }
            if (_waveSource != null)
            {
                _waveSource.Dispose();
                _waveSource = null;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {


        }

        public void Play()
        {
            if (_soundOut != null)
                _soundOut.Play();
        }

        public void Pause()
        {
            if (_soundOut != null)
                _soundOut.Pause();
        }

        public void Stop()
        {
            if (_soundOut != null)
                _soundOut.Stop();

            if (_soundIn != null)
            {
                _soundIn.Stop();
                _soundIn.Dispose();
                _soundIn = null;
//                _finalSource.Dispose();

//                if (_writer is IDisposable)
//                    ((IDisposable)_writer).Dispose();

                //                buttonStart.Enabled = false;
                //                buttonStart.Enabled = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Stop();
            CleanupPlayback();
            if (radioButtonSourceFile.Checked)
            {
                string filename = this.textBoxAudioFile.Text;
                if (!File.Exists(filename))
                {
                    MessageBox.Show("Sorry - cannot locate the specified file \"" + filename + "\"");
                    return;
                }

                _waveSource =
                CodecFactory.Instance.GetCodec(filename)
                    .ToSampleSource()
                    .ToWaveSource(16)
                    .AppendSource(x => new FilterBitDepth(x, ref dummyMask))
;

                OpenSoundOut((MMDevice)comboBoxOutputDevice.SelectedItem);
                Play();
            }
            else
            {

                MessageBox.Show("sorry, not yet written the line in stuff");
                return;

                MMDevice SelectedDevice = (MMDevice)comboBoxInputDevice.SelectedItem;
                if (SelectedDevice == null)
                    return;

                _soundIn = new WasapiCapture(true, AudioClientShareMode.Shared, 30);
                _soundIn.Device = SelectedDevice;
                //important: always initialize the soundIn instance before creating the
                //SoundInSource. The SoundInSource needs the WaveFormat of the soundIn,
                //which gets determined by the soundIn.Initialize method.


//_soundIn = new WasapiLoopbackCapture();
                _soundIn.Initialize();

                //wrap a sound source around the soundIn instance
                //in order to prevent playback interruptions, set FillWithZeros to true
                //otherwise, if the SoundIn does not provide enough data, the playback stops
                _waveSource = new SoundInSource(_soundIn) { FillWithZeros = true };

                OpenSoundOut((MMDevice)comboBoxOutputDevice.SelectedItem);
                Play();
            }


        }


        public event EventHandler<PlaybackStoppedEventArgs> PlaybackStopped;

        public PlaybackState PlaybackState
        {
            get
            {
                if (_soundOut != null)
                    return _soundOut.PlaybackState;
                return PlaybackState.Stopped;
            }
        }

        public TimeSpan Position
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetPosition();
                return TimeSpan.Zero;
            }
            set
            {
                if (_waveSource != null)
                    _waveSource.SetPosition(value);
            }
        }

        public TimeSpan Length
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetLength();
                return TimeSpan.Zero;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBoxAudioFile.Text = @"\\192.168.1.251\d\media\mp3\Royksopp - Only This Moment.mp3";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (_stopSliderUpdate)
            {
                double perc = trackBar1.Value / (double)trackBar1.Maximum;
                TimeSpan position = TimeSpan.FromMilliseconds(WavePlayerLength.TotalMilliseconds * perc);
                WavePlayerPosition = position;
            }
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _stopSliderUpdate = true;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _stopSliderUpdate = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan position = WavePlayerPosition;
            TimeSpan length = WavePlayerLength;
            if (position > length) { length = position; }

            lblPosition.Text = String.Format(@"{0:mm\:ss} / {1:mm\:ss}", position, length);

            if (!_stopSliderUpdate &&
                length != TimeSpan.Zero && position != TimeSpan.Zero)
            {
                double perc = position.TotalMilliseconds / length.TotalMilliseconds * trackBar1.Maximum;
                trackBar1.Value = (int)perc;
            }
        }


        public TimeSpan WavePlayerPosition
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetPosition();
                return TimeSpan.Zero;
            }
            set
            {
                if (_waveSource != null)
                    _waveSource.SetPosition(value);
            }
        }

        public TimeSpan WavePlayerLength
        {
            get
            {
                if (_waveSource != null)
                    return _waveSource.GetLength();
                return TimeSpan.Zero;
            }
        }

        private void numericUpDownBitDepth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarBitDepth_ValueChanged(object sender, EventArgs e)
        {
            //calculate the mask?
            int bits = this.trackBarBitDepth.Value;
            SetBitDepth(bits);
        }

        private void SetBitDepth(int bits)
        {
            dummyMask.Mask = FilterBitDepth.SetBitMask(bits);
            this.labelBitDepth.Text = bits.ToString() + " Bit" + (bits == 1 ? "" : "s") + " = " + Convert.ToString(dummyMask.Mask, 2);
        }
    }


    public class DummyRef
    {
        public short Mask { get; set; }
    }

    /// <summary>
    /// a filter which will do the bit reduction (by bitwise AND'ing a mask)
    /// </summary>
    public class FilterBitDepth : WaveAggregatorBase
    {
        private readonly object _lockObject = new object();
        private IWaveSource _source;
        private DummyRef _mask;

        public FilterBitDepth(IWaveSource source, ref DummyRef Mask)
            : base(source)
        {
            _source = source;
            _mask = Mask;

            //this is nice but we're going to assume 16 bit always for now
            //bear in mind that the input will be converted to 16 bit by the source so this should be fine
            int BitDepth = _source.WaveFormat.BitsPerSample;

            if (BitDepth != 16)
            {
                throw new Exception("Code is rubbish and can only cope with 16 bit audio - sorry");
            }
        }

        public static short SetBitMask(int ActiveBits)
        {
            int BitDepth = 16; //cludge really


            //correct for 2's compliment
            ActiveBits++;

            short mask = (short)
                (((int)Math.Pow(2, BitDepth) - 1) ^ ((int)Math.Pow(2, (BitDepth - ActiveBits)) - 1));

            Console.WriteLine(mask.ToString());
            Console.WriteLine(Convert.ToString(mask, 2));

            return mask;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = base.Read(buffer, offset, count);
            lock (_lockObject)
            {
                for (int i = 0; i < read; i = i + 2)
                {
                    //get sample as a SHORT (hmm assumption there that always 16bit)
                    short sample = BitConverter.ToInt16(buffer, i);
                    //apply the bitwise mask
                    sample = (short)(sample & _mask.Mask);
                    //create a byte version of the short
                    byte[] byteWrite = BitConverter.GetBytes(sample);
                    //write back 
                    buffer[i] = byteWrite[0];
                    buffer[i + 1] = byteWrite[1];
                }
            }

            return read;
        }
    }


    public enum CaptureMode
    {
        Capture,
        LoopbackCapture
    }
}
