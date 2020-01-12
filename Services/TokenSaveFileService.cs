using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using I_Like_Music.Views;

namespace I_Like_Music.Services
{
   public class TokenSaveFileService
   {
       public string result = "";
       public  async void SaveTokenToFile(string nameFile, string token)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenFile = await storageFolder.CreateFileAsync(nameFile,
                Windows.Storage.CreationCollisionOption.ReplaceExisting); 
            await FileIO.WriteTextAsync(TokenFile, token);
        }

       public async void CreateTokenFile()
       {
           var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
           var TokenFile = await storageFolder.CreateFileAsync(Login.Token,
               Windows.Storage.CreationCollisionOption.ReplaceExisting);
        }
        public   async Task <String> ReadTokenFormFile (String nameFile)
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenFile =
                await storageFolder.CreateFileAsync(nameFile, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(TokenFile);
        }

        public async Task<String> ReadTokenFormFile()
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenSaveAsync =
                await storageFolder.CreateFileAsync(Login.Token, Windows.Storage.CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(TokenSaveAsync);
        }

        public async Task<String> GetToken()
        {
            var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var TokenSaveAsync =
                await storageFolder.CreateFileAsync(Login.Token, Windows.Storage.CreationCollisionOption.OpenIfExists);
            result = await FileIO.ReadTextAsync(TokenSaveAsync);
            Debug.WriteLine(result);

            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
