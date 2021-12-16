using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Threading;

namespace BatchRename.Lib
{
    public class BackupConfig
    {
        public int BackupInterval { get; set; }
        public string Extension { get; set; }
        public string Directory { get; set; }
    }

    public class BackupService<T>
    {
        public Action OnBackup;
        public Action OnBackuped;
        public Func<T> OnBeforeBackup;

        public string FileName { get; set; }
        public string FilePath => $"{_config.Directory}\\{FileName}.{_config.Extension}";

        private BackupConfig _config { get; set; }
        private DispatcherTimer _dispatcherTimer { get; set; }
        private bool _isBackup { get; set; } = false;

        private IPersister _persister;

        public BackupService(BackupConfig config)
        {
            _config = config;
            _persister = new JsonPersister();
        }

        public bool CheckExistBackupFile()
        {
            return File.Exists(FilePath);
        }

        public void StartBackup()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Backup_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, _config.BackupInterval);
            _dispatcherTimer.Start();
        }

        public void StopBackup()
        {
            _dispatcherTimer.Tick -= new EventHandler(Backup_Tick);
            _dispatcherTimer.Stop();
            DeleteBackupFile();
        }

        public T LoadBackupFile()
        {
            T result = (T)_persister.Load(FilePath);

            if (result == null)
                throw new Exception("Invalid autosaved file");

            return result;
        }

        private void Backup_Tick(object sender, EventArgs e)
        {
            if (_isBackup)
                return;

            T data = OnBeforeBackup.Invoke();

            if (data == null)
                throw new Exception("Invalid backup data");

            DeleteBackupFile();
            SaveAsync(data);
        }

        private void DeleteBackupFile()
        {
            _persister.Delete(FilePath);
        }

        private async void SaveAsync(T data)
        {
            OnBackup?.Invoke();
            _isBackup = true;

            await _persister.SaveAsync(FilePath, data);

            _isBackup = false;
            OnBackuped?.Invoke();
        }
    }
}
