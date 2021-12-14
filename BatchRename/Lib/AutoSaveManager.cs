using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Threading;

namespace BatchRename.Lib
{
    public class AutoSaveConfig
    {
        public int AutoSaveInterval { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string SaveDirectory { get; set; }
        public string FilePath => $"{SaveDirectory}\\{FileName}.{Extension}";
    }

    public class AutoSaveManager<T>
    {
        private T _store { get; set; }
        private AutoSaveConfig _config { get; set; }

        private DispatcherTimer _dispatcherTimer;

        public AutoSaveManager(AutoSaveConfig config, T store)
        {
            _config = config;
        }

        public bool CheckExistAutoSaveFile()
        {
            return File.Exists(_config.FilePath);
        }

        public void StartAutoSave()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(SaveCallback);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, _config.AutoSaveInterval);
            _dispatcherTimer.Start();
        }

        private void SaveCallback(object sender, EventArgs e)
        {
            SaveAutoSaveFile();
        }

        public void StopAutoSave()
        {
            _dispatcherTimer.Tick -= new EventHandler(SaveCallback);
            _dispatcherTimer.Stop();
        }

        public T LoadAutoSaveFile()
        {
            try
            {
                string text = File.ReadAllText(_config.FilePath);
                return JsonConvert.DeserializeObject<T>(text);
            }
            catch
            {
                throw;
            }
        }

        private async void SaveAutoSaveFile()
        {
            string text = JsonConvert.SerializeObject(_store);
            await File.WriteAllTextAsync(_config.FilePath, text);
        }
    }
}
