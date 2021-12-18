using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatchRename.Model;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Threading;

namespace BatchRename.Lib
{
    public class SaveLoadConfig
    {
        public bool AutoSave { get; set; }
        public int AutoSaveInterval { get; set; }
    }

    public class SaveLoadService<T>
    {
        public Func<T> OnBeforeSaving;

        public Action OnSave;
        public Action OnSaved;
        public Func<T> OnBeforeSave;

        public string Path { get; set; }

        private SaveLoadConfig _config { get; set; }
        private DispatcherTimer _timer { get; set; }
        private bool _isSaving { get; set; }

        private IPersister _persister { get; set; }

        public SaveLoadService(SaveLoadConfig config)
        {
            _config = config;
            _persister = new JsonPersister();
        }

        public void EnableAutoSave()
        {
            _config.AutoSave = true;

            if (_timer != null)
                _timer.Stop();

            if (_timer == null)
                _timer = new DispatcherTimer();

            _timer.Start();
            _timer.Interval = new TimeSpan(0, 0, _config.AutoSaveInterval);
            _timer.Tick += new EventHandler(AutoSave_Tick);
            _timer.Start();
        }

        public void StopAutoSave()
        {
            _config.AutoSave = false;
            _timer.Tick -= new EventHandler(AutoSave_Tick);
            _timer.Stop();
        }

        public void AutoSave_Tick(object sender, EventArgs e)
        {
            T data = OnBeforeSaving.Invoke();

            if (data == null)
                throw new Exception("Invalid data");

            DeleteAutoSaveFile();
            SaveAsync(data);
        }

        public T Load()
        {
            string text = File.ReadAllText(Path);

            T data = (T)JsonConvert.DeserializeObject(text);

            if (data == null)
                throw new InvalidCastException("Invalid data");

            return data;
        }

        public void Save(T data)
        {
            OnSave?.Invoke();
            _persister.Save(Path, data);
            OnSaved?.Invoke();
        }

        private void DeleteAutoSaveFile()
        {
            if (!File.Exists(Path))
                return;

            File.Delete(Path);
        }

        public async void SaveAsync(T data)
        {
            if (_isSaving)
                throw new InvalidOperationException("Saving");

            _isSaving = true;
            OnSave?.Invoke();

            await _persister.SaveAsync(Path, data);

            OnSaved?.Invoke();
            _isSaving = false;
        }
    }
}
