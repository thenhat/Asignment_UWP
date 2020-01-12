﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace I_Like_Music.Services
{
    public class FileHandleService
    {
        public static async Task<string> ReadFile(string fileName)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.CreateFileAsync(fileName,
                Windows.Storage.CreationCollisionOption.OpenIfExists);
            var result = await FileIO.ReadTextAsync(sampleFile);

            return result;
        }

        public static async void DeleteFile(string fileName)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.CreateFileAsync(fileName,
                Windows.Storage.CreationCollisionOption.OpenIfExists);
            await sampleFile.DeleteAsync();
        }

        public static async Task WriteToFile(string fileName, string content)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var sampleFile = await storageFolder.CreateFileAsync(fileName,
                Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, content);
        }

        public static async void WriteToFile(StorageFile file, string content)
        {
            await FileIO.WriteTextAsync(file, content);
        }
    }
}
